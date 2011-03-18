
/*
	Rocket Objects
	QuanPhan - 20111203
*/

#ifndef _rocket_h_
#define _rocket_h_

#include "../common/gba.h"
#include "physics.h"

#define ROCKET_EFFECTIVE_RADIUS_SQUARE 10 << 16
#define ROCKET_ANIMATION_SPEED_LEVEL 100
#define ROCKET_SPRITE_ANIM_REFRESH_RATE 4

#define ROCKET_HIT_GROUND (1)
#define ROCKET_OUT_OF_SCREEN (1 << 1)

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
void launchRocket(rockettype *rocket, s32 x0, s32 y0, s32 v0, s32 gravity, s32 windForce, int angle); // launch it with init values
int refreshRocketStat(rockettype *rocket, s32 t); // refresh the launched rocket's status

// Function
#define isRocketLaunched(rocket) ((rocket).phys.t > -1)
int isRocketHit(rockettype rocket, int tx, int ty); // is rocket hit a point

#endif // _rocket_h_
