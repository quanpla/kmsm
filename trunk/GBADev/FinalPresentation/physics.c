#include "../common/gba.h"
#include "physics.h"

extern const signed long SIN[];
extern const signed long COS[];

void physCharSet(physChar *phys, s32 x0, s32 y0, s32 vx0, s32 vy0, s32 ax, s32 ay){
	(*phys).x = x0;
	(*phys).y =  y0;
	(*phys).x0 =  x0;
	(*phys).y0 =  y0;
	(*phys).vx =  vx0;
	(*phys).vy =  vy0;
	(*phys).vx0 =  vx0;
	(*phys).vy0 =  vy0;
	(*phys).ax =  ax;
	(*phys).ay =  ay;
	(*phys).t =  0;
}

void physCharSetVector(physChar *phys, s32 x0, s32 y0, s32 v, u16 angle, s32 ax, s32 ay){
	physCharSet(phys, x0, y0, MultiplyFix(v, COS[angle]), MultiplyFix(v, SIN[angle]), ax, ay);
}

void physCharRefresh(physChar *phys, s32 t){
	if (t==0)
		return;
	
	(*phys).t = t;
	(*phys).x = (*phys).x0;
	if((*phys).vx0)
		(*phys).x += MultiplyFix((*phys).vx0, (*phys).t);
	if((*phys).ax)
		(*phys).x += (MultiplyFix((*phys).ax, MultiplyFix((*phys).t, (*phys).t)) >> 1);

	(*phys).y = (*phys).y0;
	if((*phys).vy0)
		(*phys).y += MultiplyFix((*phys).vy0, (*phys).t);
	if((*phys).vy0)
		(*phys).y += (MultiplyFix((*phys).ay, MultiplyFix((*phys).t, (*phys).t)) >> 1);
	
	(*phys).vx = (*phys).vx0;
	if((*phys).ax)
		(*phys).vx += MultiplyFix((*phys).ax, (*phys).t);
	(*phys).vy = (*phys).vy0;
	if((*phys).ay)
		(*phys).vy += MultiplyFix((*phys).ay, (*phys).t);
}

int getOrbitTangentAngle(physChar phys){
	extern const double TAN[];

	int angle;
	s32 dx, dy;
	
	dx = phys.vx0;
	if (phys.ax)
		dx += (phys.ax >> 1) + MultiplyFix(phys.ax, phys.t);

	dy = phys.vy0;
	if (phys.ay)
		dy += (phys.ay >> 1) + MultiplyFix(phys.ay, phys.t);
		
	
	if( dx==0 ){
		angle = (dy >= 0) ? 90: 270;
	}
	else if( dy == 0 ){
		angle = (dx >= 0) ? 0: 180;
	}
	else{
		int lo = 0; int hi = 0, mid = 0;;
		s32 tangent = DivideFix(dy, dx);
		
		if (tangent < 0){
			lo = 91; hi = 179;
		}
		else{
			lo = 0; hi = 89;
		}
		
		while (hi > lo + 1){
			mid = lo + ((hi - lo) >> 1);
			if (tangent > TAN[mid])
				lo = mid;
			else
				hi = mid;
		}
		
		angle = lo;
		if (dy < 0)
			angle += 180;
	}
	return angle;
}
