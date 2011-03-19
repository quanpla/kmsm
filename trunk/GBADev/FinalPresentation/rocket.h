
/*
	Rocket Objects
	QuanPhan - 20111203
*/

#ifndef _rocket_h_
#define _rocket_h_

#include "../common/gba.h"
#include "physics.h"

#define ROCKET_EFFECTIVE_RADIUS 10
#define ROCKET_SPRITE_ANIM_REFRESH_RATE 2

#define ROCKET_HIT_GROUND (1)
#define ROCKET_OUT_OF_SCREEN (1 << 1)

typedef struct _rockettype_{
	// the "Physics" part: location, velocity, acceleration, ...
	physChar phys;
	// the show up part: animation num, etc.
	int angle;
	int curFrame;
	int waitForNextFrame;
	int status;
} rockettype;

// Procedures
void initRocket(rockettype *rocket);
void launchRocket(rockettype *rocket, s32 x0, s32 y0, s32 v0, s32 gravity, s32 windForce, int angle); // launch it with init values
void refreshRocketStat(rockettype *rocket, s32 t); // refresh the launched rocket's status

// Function
#define isRocketLaunched(rocket) ((rocket).phys.t > -1)
#define isRocketHit(rocket, x_test) ( ((Fix2Int((rocket).phys.x)) > ((x_test) - ROCKET_EFFECTIVE_RADIUS)) && ( (Fix2Int((rocket).phys.x)) < ((x_test) + ROCKET_EFFECTIVE_RADIUS)) )

#endif // _rocket_h_
