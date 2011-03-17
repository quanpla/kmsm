/***************\
* Sprite.h	*
*		*
\***************/

#ifndef SPRITE_H
#define SPRITE_H

//Atribute0 stuff
#define ROTATION_FLAG 		0x100
#define SIZE_DOUBLE			0x200
#define MODE_NORMAL     	0x0
#define MODE_TRANSPERANT	0x400
#define MODE_WINDOWED		0x800
#define MOSAIC				0x1000
#define COLOR_16			0x0000
#define COLOR_256			0x2000
#define SQUARE			0x0
#define TALL			0x4000
#define WIDE			0x8000

//Atribute1 stuff
#define ROTDATA(n)		((n) << 9)
#define HORIZONTAL_FLIP		0x1000
#define VERTICAL_FLIP		0x2000
#define SIZE_8			0x0
#define SIZE_16			0x4000
#define SIZE_32			0x8000
#define SIZE_64			0xC000

//atribute2 stuff

#define PRIORITY(n)		((n) << 10)
#define PALETTE(n)		((n) << 12)

void RotateSprite(int rotDataIndex, s32 angle, s32 x_scale,s32 y_scale);
void InitializeSprites(void) ;

/////structs/////

typedef struct tagOAMEntry
{
	u16 attribute0;
	u16 attribute1;
	u16 attribute2;
	u16 attribute3;
}OAMEntry,*pOAMEntry;

typedef struct tagRotData
{
		
	u16 filler1[3];
	u16 pa;

	u16 filler2[3];
	u16 pb;	
		
	u16 filler3[3];
	u16 pc;	

	u16 filler4[3];
	u16 pd;
}RotData,*pRotData;

u16* OAM = (u16*)0x7000000;
OAMEntry sprites[128];
pRotData rotData = (pRotData)sprites;



#endif
