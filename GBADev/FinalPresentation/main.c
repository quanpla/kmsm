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

int main(void){
	REG_DISPCNT = MODE_4 | OBJ_ENABLE | OBJ_MAP_1D | BG2_ENABLE;
	//test7();
	testFinal();
	while(1);
	return 0;
}

vu16 waitReloadRocket = 0;
vu16 waitReloadRocketAngle = 0;
vu16 waitReloadRocketForce = 0;

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
			}
		}
		for (i = 0; i<ENEMY_NUMBER_OF_ENTITY; i++){
			if (isEnemyWalked(enemies[i])){
				enemies[i].phys.t += OBJECT_TIME_UNIT;
				if (enemies[i].curFrame < ENEMY_SPRITE_ANIM_NUM - 1)
					enemies[i].curFrame++;
				else
					enemies[i].curFrame = 0;
				setEnemyAnimation(i, enemies[i].curFrame);
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
	initializeSprites();
	initializeLauncher(&launcher);
	setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
	waitForVsync();
	refreshSprites();
	
	REG_INTERUPT = (u32)interrupt_handler;
	REG_P1CNT = KEY_INTERRUPT | KEY_A | KEY_B | KEY_LEFT | KEY_RIGHT | KEY_UP | KEY_DOWN | KEY_INTERRUPT_OR;
	
	REG_TM0D = 41950;
	REG_TM0CNT = TIME_ENABLE | TIME_IRQ_ENABLE | TIME_FREQUENCY_SYSTEM;
	
	REG_IE |= INT_KEYBOARD | INT_TIMER0;
	REG_IME = 1;

	int i;
	int rocketStat;
	for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
		initRocket(rockets + i);
		setRocketAngle(i, launcher.rocketAngle);
	}
	for (i=0; i < ENEMY_NUMBER_OF_ENTITY; i++){
		initializeEnemy(enemies + i);
		startEnemy(enemies + i);
	}
	
	i = 0;

	while(1){
		refreshLauncherStat(&launcher, launcher.phys.t + (1<<13));
		setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
		for (i = 0; i < ENEMY_NUMBER_OF_ENTITY; i++){
			refreshEnemyStat(enemies + i, enemies[i].phys.t);
			setEnemyLocation(i, Fix2Int(enemies[i].phys.x), Fix2Int(enemies[i].phys.y));
		}
		
		for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
			if (!isRocketLaunched(rockets[i])){
				setRocketLocation(i, Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y)-4);
				setRocketAngle(i, launcher.rocketAngle);
			}
			else{
				rocketStat = refreshRocketStat(rockets + i, rockets[i].phys.t);
				if (rocketStat){
					if (rocketStat & ROCKET_HIT_GROUND){
					// Booming
					}
					if (rocketStat & ROCKET_OUT_OF_SCREEN){
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




void test7(){
	sprintf(msg, "%d\n", 15 % 4);
	print(msg);
}





void test6(){
	initializeSprites();
	initRocket(0);
	initRocket(1);
	initRocket(2);
	initRocket(3);
	
	launchRocket(rockets, Int2Fix(10), Int2Fix(10), Int2Fix(10), GRAVITATIONAL_ACCELERATE, WIND_SPEED, 45);
	launchRocket(rockets + 1, Int2Fix(50), Int2Fix(10), Int2Fix(10), GRAVITATIONAL_ACCELERATE, WIND_SPEED, 135);
	launchRocket(rockets + 2, Int2Fix(10), Int2Fix(50), Int2Fix(10), GRAVITATIONAL_ACCELERATE, WIND_SPEED, 225);
	launchRocket(rockets + 3, Int2Fix(50), Int2Fix(50), Int2Fix(10), GRAVITATIONAL_ACCELERATE, WIND_SPEED, 315);
	
	setRocketLocation(0, Fix2Int(rockets[0].phys.x), Fix2Int(rockets[0].phys.y));
	setRocketAngle(0, rockets[0].angle);
	setRocketLocation(1, Fix2Int(rockets[1].phys.x), Fix2Int(rockets[1].phys.y));
	setRocketAngle(1, rockets[1].angle);
	setRocketLocation(2, Fix2Int(rockets[2].phys.x), Fix2Int(rockets[2].phys.y));
	setRocketAngle(2, rockets[2].angle);
	setRocketLocation(3, Fix2Int(rockets[3].phys.x), Fix2Int(rockets[3].phys.y));
	setRocketAngle(3, rockets[3].angle);
	
	refreshSprites();
}




void test5(int x, int y, int v, int angle){
	initializeSprites();
	initRocket(0);

	launchRocket(rockets, Int2Fix(x), Int2Fix(y), Int2Fix(v), GRAVITATIONAL_ACCELERATE, WIND_SPEED, angle);
	
	setRocketLocation(0, Fix2Int(rockets[0].phys.x), Fix2Int(rockets[0].phys.y));
	setRocketAngle(0, rockets[0].angle);
	waitForVsync();
	refreshSprites();
	
	int rocketStat;
	rockets[0].phys.t += 1 << 15;
	while(1){
		rocketStat = refreshRocketStat(rockets, rockets[0].phys.t);
		sprintf(msg, "%d\n", rocketStat);
		print(msg);
		if (rocketStat){
			initRocket(0);
			launchRocket(rockets, Int2Fix(x), Int2Fix(y), Int2Fix(v), GRAVITATIONAL_ACCELERATE, WIND_SPEED, angle);
		}
		else{
			rockets[0].phys.t += 1 << 15;
		}
		setRocketLocation(0, Fix2Int(rockets[0].phys.x), Fix2Int(rockets[0].phys.y));
		setRocketAngle(0, rockets[0].angle);
		waitForVsync();
		refreshSprites();
	}
}

void test3(){
	initializeSprites();
	
	rlaunchertype launcher;
	initializeLauncher(&launcher);
	char msg[255];

	while(1){
		if(!(*KEYS & KEY_LEFT)){
			setLauncherStat(&launcher, -1);
		}
		else if(!(*KEYS & KEY_RIGHT)){
			setLauncherStat(&launcher, 1);
		}
		else {
			setLauncherStat(&launcher, 0);
		}
		refreshLauncherStat(&launcher, launcher.phys.t + 100);
		
		setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
		refreshSprites();
	}
	
//	sprintf(msg, "%d -- %d -- %d -- %d -- %d\n", Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y), Fix2Int(launcher.phys.vx0), Fix2Int(launcher.phys.vx), Fix2Int(launcher.phys.t));
//	print(msg);
}

void test0(){
	char msg[255];
	s32 test;
	test = DivideFix(2, 65526);
	sprintf(msg, "divide result %d == %d\n", test, Fix2Int(test));
	print(msg);
}

void test1(){

	char msg[255];
	rockettype rocket;
	initRocket(&rocket);
	launchRocket(&rocket, Int2Fix(10), Int2Fix(150), Int2Fix(10), Int2Fix(1), Int2Fix(0), 285);
	
	physChar testPhys;
	testPhys = rocket.phys;

	sprintf(msg, "x0 = %3d, y0 = %3d, x = %3d, y = %3d, vx0 = %3d, vy0 = %3d, vx = %3d, vy = %3d, ax = %3d, ay = %3d, t = %3d\n", Fix2Int(testPhys.x0), Fix2Int(testPhys.y0), Fix2Int(testPhys.x), Fix2Int(testPhys.y), Fix2Int(testPhys.vx0), Fix2Int(testPhys.vy0), Fix2Int(testPhys.vx), Fix2Int(testPhys.vy), Fix2Int(testPhys.ax), Fix2Int(testPhys.ay), Fix2Int(testPhys.t));
	print(msg);
	
	sprintf(msg, "angle = %3d\n", rocket.angle);
	print(msg);

	if (isRocketLaunched(rocket))
		refreshRocketStat(&rocket, 1);
	testPhys = rocket.phys;
	
	sprintf(msg, "x0 = %3d, y0 = %3d, x = %3d, y = %3d, vx0 = %3d, vy0 = %3d, vx = %3d, vy = %3d, ax = %3d, ay = %3d, t = %3d\n", Fix2Int(testPhys.x0), Fix2Int(testPhys.y0), Fix2Int(testPhys.x), Fix2Int(testPhys.y), Fix2Int(testPhys.vx0), Fix2Int(testPhys.vy0), Fix2Int(testPhys.vx), Fix2Int(testPhys.vy), Fix2Int(testPhys.ax), Fix2Int(testPhys.ay), Fix2Int(testPhys.t));
	print(msg);
	
	sprintf(msg, "angle = %3d\n", rocket.angle);
	print(msg);	
}

void test2(){
	initializeSprites();
	rockettype rocket;
	initRocket(&rocket);
	launchRocket(&rocket, 10, 120, 20, 1, 0, 280);
	
	setRocketLocation(0, Fix2Int(rocket.phys.x), Fix2Int(rocket.phys.y));
	setRocketAngle(0, rocket.angle);
	
	waitForVsync();
	refreshSprites();
	
	while(1);
	
	int i;
	physChar testPhys;
	for(i = 1; i < 50; i++){
	while(((*KEYS) & KEY_LEFT)){
	}
		if (isRocketLaunched(rocket)){
			refreshRocketStat(&rocket, Int2Fix(i));
			refreshRocketStat(&rocket, Int2Fix(i));
			refreshRocketStat(&rocket, Int2Fix(i));
			refreshRocketStat(&rocket, Int2Fix(i));
			refreshRocketStat(&rocket, Int2Fix(i));
			refreshRocketStat(&rocket, Int2Fix(i));
		}
		setRocketLocation(0, Fix2Int(rocket.phys.x), Fix2Int(rocket.phys.y));
		setRocketAngle(0, rocket.angle);
		sprintf(msg, "x0 = %3d, y0 = %3d, x = %3d, y = %3d, vx0 = %3d, vy0 = %3d, vx = %3d, vy = %3d, ax = %3d, ay = %3d, t = %3d\n", Fix2Int(testPhys.x0), Fix2Int(testPhys.y0), Fix2Int(testPhys.x), Fix2Int(testPhys.y), Fix2Int(testPhys.vx0), Fix2Int(testPhys.vy0), Fix2Int(testPhys.vx), Fix2Int(testPhys.vy), Fix2Int(testPhys.ax), Fix2Int(testPhys.ay), Fix2Int(testPhys.t));
		print(msg);
		
		sprintf(msg, "angle = %3d\n", rocket.angle);
		print(msg);	
		refreshSprites();
		if (Fix2Int(rocket.phys.y) > 160) break;
	}	
}
