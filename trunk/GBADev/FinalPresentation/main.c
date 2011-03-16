#include "../common/gba.h"
#include "../common/screenmode.h"
#include "../common/keypad.h"

#include "physics.h"
#include "rocket.h"
#include "utils.h"
#include "sprites.h"

int main(void){
	REG_DISPCNT = MODE_4 | OBJ_ENABLE | OBJ_MAP_1D | BG2_ENABLE;
	
	char msg[255];
	sprintf(msg, "test\n");
	print(msg);

	test2();
	
	while(1){
		// process refreshing
		// handle intput
		// wait for V Sync
		// update
	}
	return 0;
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
		refreshSprites();
		if (Fix2Int(rocket.phys.y) > 160) break;
	}	
}