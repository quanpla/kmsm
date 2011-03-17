
#include "environment.h"
#include "enemy.h"
#include "utils.h"

char msg[50];
int enemySpeed[] = {-Int2Fix(1), -Int2Fix(2), -Int2Fix(3), -Int2Fix(4)};

void initializeEnemy(enemytype *enemy){
	physCharSetVector(&((*enemy).phys), Int2Fix(ENEMY_START_COORDINATE), Int2Fix(GROUND_COORDINATE), 0, 0, 0, 0);
	(*enemy).life = 10;
	(*enemy).curFrame = 0;
}


void startEnemy(enemytype *enemy, int speed){
	(*enemy).phys.t = 0;
	(*enemy).phys.vx = enemySpeed[speed];
	(*enemy).phys.vx0 = enemySpeed[speed];
}

int refreshEnemyStat(enemytype *enemy, s32 t){
	physCharRefresh(&((*enemy).phys), t);
	return 0;
}
