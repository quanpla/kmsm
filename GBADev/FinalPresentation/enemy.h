//enemy

#ifndef _enemy_h_
#define _enemy_h_

#include "../common/gba.h"
#include "physics.h"

#define ENEMY_EFFECTIVE_RADIUS_SQUARE 10 << 16
#define ENEMY_START_COORDINATE 240

#define ENEMY_STAT_HIT_LAUNCHER 1

typedef struct _enemytype_{
	// the "Physics" part: location, velocity, acceleration, ...
	physChar phys;
	// the show up part: animation num, etc.
	int curFrame;
	int waitForNextFrame;
	int life;
} enemytype;

// Procedures
void initializeEnemy(enemytype *enemy);
int refreshEnemyStat(enemytype *enemy, s32 t);
void startEnemy(enemytype *enemy);

// Function
#define isEnemyKilled(enemy) ((enemy).life == 0)
#define isEnemyWalked(enemy) ((enemy).phys.vx0 != 0)
#endif // _enemy_h_
