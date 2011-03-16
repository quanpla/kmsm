#ifndef _physics_h_
#define _physics_h_

#include "../common/gba.h"

#define THE_FIXED_POINT 16
#define Real2Fix(x) ((s32)((x) * ((s32)1 << 16)))
#define Int2Fix(x) ((x) << 16)
#define MultiplyFix(x, y) ((((x) >> 4) * ((y) >> 12)))
#define DivideFix(x, y) ( (  ((x)>0 && (y)>0 && (x) > (y)) || ((x)<0 && (y)<0 && -(x) > -(y)) || ((x)<0 && (y)>0 && -(x) > (y)) || ((x)>0 && (y)<0 && (x) > -(y)) ) ? ( ((x)/(y)) << 16 ) : ( (1<<16) / ((y)/(x)) )  )
#define Fix2Int(x) ((x) >> 16)

typedef struct _physicalCharacteristics_{
	s32 x; s32 y; s32 x0; s32 y0;
	s32 vx; s32 vy; s32 vx0; s32 vy0;
	s32 ax; s32 ay; s32 t;
} physChar;

void physCharSet(physChar *phys, s32 x0, s32 y0, s32 vx0, s32 vy0, s32 ax, s32 ay);
void physCharSetVector(physChar *phys, s32 x0, s32 y0, s32 v, u16 angle, s32 ax, s32 ay);

void physCharRefresh(physChar *phys, s32 t);

int getOrbitTangentAngle(physChar);

#endif // _physics_h_
