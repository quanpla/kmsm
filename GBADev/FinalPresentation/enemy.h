//enemy

#ifndef _enemy_h_
#define _enemy_h_

#include "../common/gba.h"
#include "physics.h"

#define ENEMY_EFFECTIVE_RADIUS_SQUARE 10 << 16
#define ENEMY_START_COORDINATE 240

#define ENEMY_STAT_DIE 1
#define ENEMY_ANIMATION_RATE 100;

typedef struct _enemytype_{
	// the "Physics" part: location, velocity, acceleration, ...
	physChar phys;
	// the show up part: animation num, etc.
	int curFrame;
	int waitForNextFrame;
	int life;
	int status;
} enemytype;

// Procedures
void initializeEnemy(enemytype *enemy);
int refreshEnemyStat(enemytype *enemy, s32 t);
void startEnemy(enemytype *enemy);
void killEnemy(enemytype *enemy);

// Function
#define isEnemyKilled(enemy) ((enemy).life == 0)
#define isEnemyWalked(enemy) (((enemy).phys.vx0 != 0) || ((enemy).phys.vy0 != 0))
#define isEnemyHitPoint(enemy, x_test) ((Fix2Int((enemy).phys.x) <= x_test))

#endif // _enemy_h_
