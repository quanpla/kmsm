
#include "environment.h"
#include "rlauncher.h"
#include "utils.h"

char msg[50];
void initializeLauncher(rlaunchertype *launcher){
	physCharSetVector(&((*launcher).phys), Int2Fix(LAUNCHER_START_COORDINATE), Int2Fix(GROUND_COORDINATE), 0, 0, 0, 0);
	(*launcher).rocketAngle = 300;
}

void refreshLauncherStat(rlaunchertype *launcher, s32 t){
	if ((*launcher).phys.vx == 0)
		return;
	physCharRefresh(&((*launcher).phys), t);
	if ((*launcher).phys.x<LAUNCHER_LIMIT_X_LEFT){
		(*launcher).phys.x = LAUNCHER_LIMIT_X_LEFT;
		(*launcher).phys.vx0 = 0;
		(*launcher).phys.vx = 0;
		(*launcher).phys.t = 0;
	}
	else if((*launcher).phys.x>LAUNCHER_LIMIT_X_RIGHT){
		(*launcher).phys.x = LAUNCHER_LIMIT_X_RIGHT;
		(*launcher).phys.vx0 = 0;
		(*launcher).phys.vx = 0;
		(*launcher).phys.t = 0;
	}
}

void setLauncherStat(rlaunchertype *launcher, int direction){
	if (direction == 0){
		(*launcher).phys.vx0 = 0;
		(*launcher).phys.vx = 0;
		(*launcher).phys.x0 = (*launcher).phys.x;
		(*launcher).phys.t = 0;
	}
	else if (direction > 0 && (*launcher).phys.vx <= 0 && (*launcher).phys.x < LAUNCHER_LIMIT_X_RIGHT){
		(*launcher).phys.vx0 = LAUNCHER_SPEED;
		(*launcher).phys.vx = LAUNCHER_SPEED;
		(*launcher).phys.x0 = (*launcher).phys.x;
		(*launcher).phys.t = 0;
	}
	else if (direction < 0 && (*launcher).phys.vx >= 0 && (*launcher).phys.x > LAUNCHER_LIMIT_X_LEFT){
		(*launcher).phys.vx0 = -LAUNCHER_SPEED;
		(*launcher).phys.vx = -LAUNCHER_SPEED;
		(*launcher).phys.x0 = (*launcher).phys.x;
		(*launcher).phys.t = 0;
	}
	setLauncherDirection(direction);
	if (direction!=0)
		setLauncherAnimation(1);
	else
		setLauncherAnimation(0);
}
