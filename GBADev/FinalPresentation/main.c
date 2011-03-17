#include "../common/gba.h"
#include "../common/screenmode.h"
#include "../common/keypad.h"
#include "../common/interrupt.h"
#include "../common/timers.h"

#include "environment.h"
#include "physics.h"
#include "rocket.h"
#include "rlauncher.h"
#include "utils.h"
#include "sprites.h"

rlaunchertype launcher;
rockettype rockets[ROCKET_NUMBER_OF_ENTITY];
void interrupt_handler();

int main(void){
	REG_DISPCNT = MODE_4 | OBJ_ENABLE | OBJ_MAP_1D | BG2_ENABLE;
	
	REG_INTERUPT = (u32)interrupt_handler;
	REG_P1CNT = KEY_INTERRUPT | KEY_A | KEY_B | KEY_LEFT | KEY_RIGHT | KEY_UP | KEY_DOWN | KEY_INTERRUPT_OR;
	REG_TM0D = 41950;
	REG_TM0CNT = TIME_ENABLE | TIME_IRQ_ENABLE | TIME_FREQUENCY_SYSTEM;

	REG_IE |= INT_KEYBOARD | INT_TIMER0;
	REG_IME = 1;
	testFinal();
	while(1);
	return 0;
}

char msg[60];
vu16 waitReload = 0;

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
		
		if(!(*KEYS & KEY_A)){
			if(waitReload == 0){
				sprintf(msg, "key A pressed\n");
				print(msg);
				for (i = 0; i<ROCKET_NUMBER_OF_ENTITY; i++){
					if (!isRocketLaunched(rockets[i])){
						launchRocket(rockets + i, launcher.phys.x, launcher.phys.y, Int2Fix(10), Int2Fix(1), 0, launcher.rocketAngle);
						waitReload = 100;
						break;
					}
				}
			}
		}
	
		REG_IF |= INT_KEYBOARD;

	}
	else if (REG_IF & INT_TIMER0)
	{
		if((*KEYS & KEY_RIGHT) && (*KEYS & KEY_LEFT)){
			setLauncherStat(&launcher, 0);
		}
		if (launcher.phys.vx)
			launcher.phys.t += (1<<10);
		for (i = 0; i<ROCKET_NUMBER_OF_ENTITY; i++){
			if (isRocketLaunched(rockets[i])){
				rockets[i].phys.t += (1<<10);
			}
		}
		
		if (waitReload)
			waitReload--;
		
		REG_IF |= INT_TIMER1;
	}
	
	REG_IME = 1;
}


void testFinal(){
	initializeSprites();
	initializeLauncher(&launcher);
	setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
	waitForVsync();
	refreshSprites();
	
	int i;
	int rocketStat;
	for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
		initRocket(rockets + i);
		setRocketAngle(i, launcher.rocketAngle);
	}
	i = 0;
	while(1){
		refreshLauncherStat(&launcher, launcher.phys.t + (1<<13));
		setLauncherLocation(Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y));
		for (i=0; i < ROCKET_NUMBER_OF_ENTITY; i++){
			if (!isRocketLaunched(rockets[i])){
				setRocketLocation(i, Fix2Int(launcher.phys.x), Fix2Int(launcher.phys.y)-4);
				setRocketAngle(i, launcher.rocketAngle);
			}
			else{
				rocketStat = refreshRocketStat(rockets + i, rockets[i].phys.t);
				if (rocketStat & ROCKET_HIT_GROUND){
					// Booming
					if (rocketStat & ROCKET_OUT_OF_SCREEN){
						initRocket(rockets + i);
						setRocketAngle(i, launcher.rocketAngle);
					}
				}
				else{
					setRocketLocation(i, Fix2Int(rockets[i].phys.x), Fix2Int(rockets[i].phys.y));
					setRocketAngle(i, rockets[i].angle);
				}
			}
		}
		waitForVsync();
		refreshSprites();
		// process refreshing
		// handle intput
		// wait for V Sync
		// update
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
