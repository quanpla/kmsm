//enemy

#ifndef _enemy_h_
#define _enemy_h_

#include "../common/gba.h"
#include "physics.h"

#define ENEMY_EFFECTIVE_RADIUS_SQUARE 100 << 16
#define ROCKET_ANIMATION_SPEED_LEVEL 100
#define ROCKET_SPRITE_ANIM_REFRESH_RATE 4


typedef struct _rockettype_{
	// the "Physics" part: location, velocity, acceleration, ...
	physChar phys;
	// the show up part: animation num, etc.
	int angle;
	int curFrame;
	int waitForNextFrame;
} rockettype;

// Procedures
void initRocket(rockettype *rocket);
void launchRocket(rockettype *rocket, float x0, float y0, float v0, float gravity, float windForce, int angle); // launch it with init values
void refreshRocketStat(rockettype *rocket, int t); // refresh the launched rocket's status

// Function
#define isRocketLaunched(rocket) ((rocket).phys.t > -1)
int isRocketHit(rockettype rocket, int tx, int ty); // is rocket hit a point


#endif // _enemy_h_
