#ifndef _rlauncher_h_
#define _rlauncher_h_

#include "physics.h"
#include "../common/gba.h"

#define LAUNCHER_STAT_DIE 1;

#define LAUNCHER_SPRITE_ANIM_REFRESH_RATE 4

typedef struct _rlaunchertype_{
	physChar phys;
	int rocketAngle;
	s32 rocketVelocity;
	int frictionMode; // only the fraction slow it down
	int curFrame; // show off, prepare for the frame number of animation
	int waitForNextFrame;
	int status;
} rlaunchertype;

//	procedures
void initializeLauncher(rlaunchertype *launcher);
void refreshLauncherStat(rlaunchertype *launcher, s32 t);
void setLauncherStat(rlaunchertype *launcher, int direction);
void setLauncherRocketVelocity(rlaunchertype *launcher, s32 v);
//	functions

#endif;
