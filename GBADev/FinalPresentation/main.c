#include "../common/gba.h"
#include "../common/screenmode.h"
#include "../common/keypad.h"
#include "../common/interrupt.h"
#include "../common/timers.h"


#include "environment.h"
#include "physics.h"
#include "rocket.h"
#include "rlauncher.h"
#include "enemy.h"
#include "utils.h"
#include "sprites.h"

rlaunchertype launcher;
rockettype rockets[ROCKET_NUMBER_OF_ENTITY];
enemytype enemies[ENEMY_NUMBER_OF_ENTITY];

void interrupt_handler();

char msg[60];


vu16 waitReloadRocket = 0;
vu16 waitReloadRocketAngle = 0;
vu16 waitReloadRocketForce = 0;

vu8 LauncherGotHit = 0;

int main(void){
	REG_DISPCNT = MODE_4 | OBJ_ENABLE | OBJ_MAP_1D | BG2_ENABLE;
	
	while(1){
		LauncherGotHit = 0;
		testFinal();
	}
	return 0;
}

void interrupt_handler() {
	int i;
	
	REG_IME = 0;
	
	if (REG_IF & INT_KEYBOARD) 
	{
		if(!(*KEYS & KEY_LEFT)){
			setLauncherStat(&launcher, -1);
		}
		else if(!(*KEYS & KEY_RIGHT)){
			setLauncherStat(&launcher, 1);
		}
		
		if(!(*KEYS & KEY_UP)){
			if(!waitReloadRocketAngle){
				launcher.rocketAngle --;
				if(launcher.rocketAngle < 275){
					launcher.rocketAngle = 275;
				}
				waitReloadRocketAngle = KEYPAD_SENSITIVITY_HIGH;
			}
		}
		else if(!(*KEYS & KEY_DOWN)){
			if(!waitReloadRocketAngle){
				launcher.rocketAngle ++;
				if(launcher.rocketAngle > 355){
					launcher.rocketAngle = 355;
				}
				waitReloadRocketAngle = KEYPAD_SENSITIVITY_HIGH;
			}
		}
		if(!(*KEYS & KEY_A)){
			if(waitReloadRocket == 0){
				for (i = 0; i<ROCKET_NUMBER_OF_ENTITY; i++){
					if (!isRocketLaunched(rockets[i])){
						launchRocket(rockets + i, launcher.phys.x, launcher.phys.y, launcher.rocketVelocity, GRAVITATIONAL_ACCELERATE, WIND_SPEED, launcher.rocketAngle);
						waitReloadRocket = KEYPAD_SENSITIVITY_LOW;
						setLauncherRocketVelocity(&launcher, ROCKET_SPEED_MIN);
						break;
					}
				}
			}
		}
		REG_IF |= INT_KEYBOARD;

	}
	if (REG_IF & INT_TIMER0)
	{
		if (launcher.phys.vx)
			launcher.phys.t += OBJECT_TIME_UNIT;
		for (i = 0; i<ROCKET_NUMBER_OF_ENTITY; i++){
			if (isRocketLaunched(rockets[i])){
				rockets[i].phys.t += OBJECT_TIME_UNIT;
				if(!rockets[i].waitForNextFrame){
					if (rockets[i].curFrame < ROCKET_SPRITE_ANIM_NUM - 1)
						rockets[i].curFrame++;
					else
						rockets[i].curFrame = 0;
					setRocketAnimation(i, rockets[i].curFrame);
					rockets[i].waitForNextFrame = ENEMY_ANIMATION_RATE;
				}
				else{
					rockets[i].waitForNextFrame--;
				}
			}
		}
		for (i = 0; i<ENEMY_NUMBER_OF_ENTITY; i++){
			if (isEnemyWalked(enemies[i])){
				enemies[i].phys.t += OBJECT_TIME_UNIT;
				if(!enemies[i].waitForNextFrame){
					if (enemies[i].curFrame < ENEMY_SPRITE_ANIM_NUM - 1)
						enemies[i].curFrame++;
					else
						enemies[i].curFrame = 0;
					if(enemies[i].status & ENEMY_STAT_DIE){
						setEnemyDieAnimation(i, enemies[i].curFrame);
					}
					else{
						setEnemyAnimation(i, enemies[i].curFrame);
					}
					enemies[i].waitForNextFrame = ENEMY_ANIMATION_RATE;
				}
				else{
					enemies[i].waitForNextFrame--;
				}
			}
		}
		if((*KEYS & KEY_RIGHT) && (*KEYS & KEY_LEFT)){
			setLauncherStat(&launcher, 0);
		}
		if(!(*KEYS & KEY_B)){
			if(!waitReloadRocketForce){
				if(launcher.rocketVelocity < ROCKET_SPEED_MAX)
					setLauncherRocketVelocity(&launcher, launcher.rocketVelocity + ROCKET_SPEED_STEP);
				waitReloadRocketForce = KEYPAD_SENSITIVITY_MID;
			}
		}
		else{
			if(!waitReloadRocketForce){
				if(launcher.rocketVelocity > ROCKET_SPEED_MIN)
					setLauncherRocketVelocity(&launcher, launcher.rocketVelocity - ROCKET_SPEED_STEP);
				waitReloadRocketForce = KEYPAD_SENSITIVITY_MID;
			}
		}
		if (waitReloadRocket)
			waitReloadRocket--;
		if (waitReloadRocketAngle)
			waitReloadRocketAngle--;
		if (waitReloadRocketForce)
			waitReloadRocketForce--;
		REG_IF |= INT_TIMER0;
	}
	
	REG_IME = 1;
}


void testFinal(){
	GameStartScreen();

	int i, j;
	int rocketStat;
	for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
		initRocket(rockets + i);
		setRocketAngle(i, launcher.rocketAngle);
	}
	for (i=0; i < ENEMY_NUMBER_OF_ENTITY; i++){
		initializeEnemy(enemies + i);
		startEnemy(enemies + i);
	}
	for (i=0; i < ENEMY_NUMBER_OF_ENTITY; i++){
		enemies[i].status = 0;
	}
	
	i = 0;

	while(!LauncherGotHit){
		refreshLauncherStat(&launcher, launcher.phys.t + (1<<13));
		setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
		for (i = 0; i < ENEMY_NUMBER_OF_ENTITY; i++){
			refreshEnemyStat(enemies + i, enemies[i].phys.t);
			setEnemyLocation(i, Fix2Int(enemies[i].phys.x), Fix2Int(enemies[i].phys.y));
			if(!enemies[i].status){
				if(isEnemyHitPoint(enemies[i], Fix2Int(launcher.phys.x))){
					LauncherGotHit = 1;
					GameOverScreen();
					return;
				}
			}
		}
		
		for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
			if (!isRocketLaunched(rockets[i])){
				setRocketLocation(i, Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y)-4);
				setRocketAngle(i, launcher.rocketAngle);
			}
			else{
				refreshRocketStat(rockets + i, rockets[i].phys.t);
				if (rockets[i].status){
					if (rockets[i].status & ROCKET_HIT_GROUND){
						// Booming
						if (isRocketHit(rockets[i], Fix2Int(launcher.phys.x)) && rockets[i].phys.t > OBJECT_TIME_UNIT * 5){
							LauncherGotHit = 1;
							GameOverScreen();
							return;
						}
						for(j = 0; j < ENEMY_NUMBER_OF_ENTITY; j++){
							if (isRocketHit(rockets[i], Fix2Int(enemies[j].phys.x))){
								enemies[j].status |= ENEMY_STAT_DIE;
								killEnemy(enemies+j);
							}
						}
					}
					if (rockets[i].status & ROCKET_OUT_OF_SCREEN){
						initRocket(rockets + i);
						setRocketAngle(i, launcher.rocketAngle);
					}
				}
				else{
					if(Fix2Int(rockets[i].phys.y) > ROCKET_LIMIT_Y_TOP){
						setRocketLocation(i, Fix2Int(rockets[i].phys.x), Fix2Int(rockets[i].phys.y));
						setRocketAngle(i, rockets[i].angle);
					}
				}
			}
		}
		waitForVsync();
		refreshSprites();
	}
}

void GameOverScreen(void){
	setBG_GameOver();
	//REG_IME = 0;
	int i;
	for(i==0 ; i < 128; i++){
		hideSprite(i);
	}
	waitForVsync();
	refreshSprites();
	while(*KEYS & KEY_START);
}

void GameStartScreen(void){
	setBG_Start();
	initializeSprites();
	refreshSprites();
	
	REG_INTERUPT = (u32)interrupt_handler;
	REG_P1CNT = KEY_INTERRUPT | KEY_A | KEY_B | KEY_LEFT | KEY_RIGHT | KEY_UP | KEY_DOWN | KEY_INTERRUPT_OR;
	
	REG_TM0D = 41950;
	REG_TM0CNT = TIME_ENABLE | TIME_IRQ_ENABLE | TIME_FREQUENCY_SYSTEM;
	
	REG_IE |= INT_KEYBOARD | INT_TIMER0;
	REG_IME = 1;
	while(*KEYS & KEY_START);
	waitForVsync();
	setBG_Game();
	setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
	initializeLauncher(&launcher);
	waitForVsync();
	refreshSprites();
}
