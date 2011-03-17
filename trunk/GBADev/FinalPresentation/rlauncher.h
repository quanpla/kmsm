#ifndef _rlauncher_h_
#define _rlauncher_h_

#define LAUNCHER_START_COORDINATE 10 // Start X coordinate of the rocket launcher
#define FRICTION_VALUE 5 // the accelerate of friction fource
#define LAUNCHER_SPEED Int2Fix(5);
#include "physics.h"

typedef struct _rlaunchertype_{
	physChar phys;
	int frictionMode; // only the fraction slow it down
	int curFrame; // show off, prepare for the frame number of animation
} rlaunchertype;

//	procedures
void initializeLauncher(rlaunchertype *launcher);
void refreshLauncherStat(rlaunchertype *launcher, s32 t);
void setLauncherStat(rlaunchertype *launcher, int direction);
//	functions

#endif;
