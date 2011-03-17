/*
	Rocket objects
*/
#include "../common/gba.h"
#include "rocket.h"
#include "physics.h"
extern const s32 SIN[];
extern const s32 COS[];
extern const s32 RAD[];

// Procedures
void initRocket(rockettype *rocket){
	(*rocket).phys.t = -1;
	(*rocket).waitForNextFrame = 0;
}

void launchRocket(rockettype *rocket, s32 x0, s32 y0, s32 v0, s32 gravity, s32 windForce, int angle){
	physCharSetVector(&((*rocket).phys), x0, y0, v0, angle, windForce, gravity);
	(*rocket).angle = angle;
} // launch it with init values

void refreshRocketStat(rockettype *rocket, s32 t){
	physCharRefresh(&((*rocket).phys), t);
	(*rocket).angle = getOrbitTangentAngle((*rocket).phys);
}

// Function

int isRocketHit(rockettype rocket, int tx, int ty){
	s32 dx = rocket.phys.x - Int2Fix(tx);
	s32 dy = rocket.phys.y - Int2Fix(ty);
	return ((MultiplyFix(dx, dx) + MultiplyFix(dy, dy)) <= ROCKET_EFFECTIVE_RADIUS_SQUARE);
}

