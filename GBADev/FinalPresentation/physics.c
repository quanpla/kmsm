#include "../common/gba.h"
#include "physics.h"
#include "utils.h"

void physCharSet(physChar *phys, s32 x0, s32 y0, s32 vx0, s32 vy0, s32 ax, s32 ay){
	(*phys).x = (x0);
	(*phys).y = (y0);
	(*phys).x0 = (x0);
	(*phys).y0 = (y0);
	(*phys).vx = (vx0);
	(*phys).vy = (vy0);
	(*phys).vx0 = (vx0);
	(*phys).vy0 = (vy0);
	(*phys).ax = (ax);
	(*phys).ay = (ay);
	(*phys).t = 0;
}

void physCharSetVector(physChar *phys, s32 x0, s32 y0, s32 v, u16 angle, s32 ax, s32 ay){
	extern const signed long SIN[];
	extern const signed long COS[];
	physCharSet(phys, x0, y0, MultiplyFix(v,COS[angle]), MultiplyFix(v, SIN[angle]), ax, ay);
}

void physCharRefresh(physChar *phys, s32 t){
	(*phys).t = t;
	
	(*phys).x = (*phys).x0;
	if ((*phys).vx0)
		(*phys).x += MultiplyFix((*phys).vx0, (*phys).t);
	if ((*phys).ax){
		(*phys).x += (MultiplyFix((*phys).ax, MultiplyFix((*phys).t, (*phys).t)) >> 1);
		(*phys).vx = (*phys).vx0 + MultiplyFix((*phys).ax, (*phys).t);
	}
	
	(*phys).y = (*phys).y0;
	if ((*phys).vy0)
		(*phys).y += MultiplyFix((*phys).vy0, (*phys).t);
	if ((*phys).ay){
		(*phys).y += (MultiplyFix((*phys).ay, MultiplyFix((*phys).t, (*phys).t)) >> 1);
		(*phys).vy = (*phys).vy0 + MultiplyFix((*phys).ay, (*phys).t);
	}
	
	
}

int getOrbitTangentAngle(physChar phys){
	extern const signed long TAN[];

	int angle;
	s32 dx = phys.vx0;
	if(phys.ax){
		dx += (phys.ax >> 1);
		if(phys.t)
			dx += MultiplyFix(phys.ax, phys.t);
	}
	
	s32 dy = phys.vy0;
	if(phys.ay){
		dy += (phys.ay >> 1);
		if(phys.t)
			dy += MultiplyFix(phys.ay, phys.t);
	}
	
	if( dx==0 ){
		angle = (dy>=0) ? 90 : 270;
	}
	else if( dy == 0 ){
		angle = (dx>=0) ? 0 : 180;
	}
	else{
		int isTan = 1;
		if (abs(dy) < abs(dx))
			isTan = 0;
		
		s32 val = (isTan) ? DivideFixNoCompare(abs(dy), abs(dx)) : DivideFixNoCompare(abs(dx), abs(dy));
		int lo = 43; int hi = 89, mid = 66;
		while (hi > lo + 1){
			mid = lo + ((hi - lo) >> 1);
			if (val > TAN[mid])
				lo = mid;
			else
				hi = mid;
		}
		if (isTan){
			if (dx > 0 && dy > 0)
				angle = mid;
			else if(dx < 0 && dy > 0)
				angle = 180 - mid;
			else if(dx < 0 && dy < 0)
				angle = mid + 180;
			else
				angle = 360 - mid;
		}
		else{
			if (dx > 0 && dy > 0)
				angle = 90 - mid;
			else if(dx < 0 && dy > 0)
				angle = mid + 90;
			else if(dx < 0 && dy < 0)
				angle = 270 - mid;
			else
				angle = 270 + mid;
		}
	}
	return angle;
}

void printPhysChar(physChar phys){
	char msg[50];
	sprintf(msg, "x=%d y=%d x0=%d y0=%d\nvx=%d vy=%d vx0=%d vy0=%d\nax=%d ay=%d t=%d\n", Fix2Int(phys.x), Fix2Int(phys.y), Fix2Int(phys.x0), Fix2Int(phys.y0), Fix2Int(phys.vx), Fix2Int(phys.vy), Fix2Int(phys.vx0), Fix2Int(phys.vy0), Fix2Int(phys.ax), Fix2Int(phys.ay), Fix2Int(phys.t));
	print(msg);
}
