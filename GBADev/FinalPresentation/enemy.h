//enemy

#ifndef _enemy_h_
#define _enemy_h_

#include "../common/gba.h"
#include "physics.h"

#define ENEMY_EFFECTIVE_RADIUS_SQUARE 100 << 16
#define ROCKET_ANIMATION_SPEED_LEVEL 100
#define ROCKET_SPRITE_ANIM_REFRESH_RATE 4


typedef struct _enemytype_{
	// the "Physics" part: location, velocity, acceleration, ...
	physChar phys;
	// the show up part: animation num, etc.
	int curFrame;
	int waitForNextFrame;
	int life;
} enemytype;

// Procedures
void initEnemy(enemytype *enemy);
void moveEnemy(enemytype *enemy, s32 x0, s32 y0, s32 v0);
void refreshEnemyStat(enemytype *enemy, s32 t); // refresh the launched rocket's status

// Function
#define isRocketLaunched(rocket) ((rocket).phys.t > -1)
int isRocketHit(rockettype rocket, int tx, int ty); // is rocket hit a point


#endif // _enemy_h_
