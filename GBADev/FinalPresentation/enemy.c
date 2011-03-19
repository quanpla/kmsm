
#include "environment.h"
#include "enemy.h"
#include "utils.h"
#include "../common/timers.h"

char msg[50];
#define ENEMY_SPEED_LEVELS 4
int enemySpeed[] = {- (4 << 12), -(8 << 12), -(12 << 12), -(16 << 12)};

void initializeEnemy(enemytype *enemy){
	physCharSetVector(&((*enemy).phys), Int2Fix(ENEMY_START_COORDINATE), Int2Fix(GROUND_COORDINATE), 0, 0, 0, 0);
	(*enemy).life = 10;
	(*enemy).curFrame = 0;
}


void startEnemy(enemytype *enemy){
	(*enemy).phys.t = 0;
	(*enemy).phys.vx = enemySpeed[REG_TM0D%ENEMY_SPEED_LEVELS];
	(*enemy).phys.vx0 = enemySpeed[REG_TM0D%ENEMY_SPEED_LEVELS];
}

void killEnemy(enemytype *enemy){
	(*enemy).phys.t = 0;
	(*enemy).phys.x0 = (*enemy).phys.x;
	(*enemy).phys.y0 = (*enemy).phys.y;
	(*enemy).phys.vx = 0;
	(*enemy).phys.vx0 = 0;
	(*enemy).phys.vy = enemySpeed[ENEMY_SPEED_LEVELS - 1] << 3;
	(*enemy).phys.vy0 = enemySpeed[ENEMY_SPEED_LEVELS - 1] << 3;
}

int refreshEnemyStat(enemytype *enemy, s32 t){
	physCharRefresh(&((*enemy).phys), t);
	if(Fix2Int((*enemy).phys.y) < 16){
		(*enemy).status = 0;
		initializeEnemy(enemy);
		startEnemy(enemy);
	}
	return 0;
}
