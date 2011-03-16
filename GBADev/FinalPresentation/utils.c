#include "utils.h"
#include "../common/gba.h"
#include "../common/dma.h"

void memcpy16(u16* src, u16* dest, u16 numCount){
	REG_DMA3SAD = (u32) (src);
	REG_DMA3DAD = (u32) dest;
	REG_DMA3CNT = numCount | DMA_ENABLE | DMA_TIMING_IMMEDIATE | DMA_16 | DMA_SOURCE_INCREMENT | DMA_DEST_INCREMENT;
}

void setPalette(u16* pal_array){
	memcpy16(pal_array, BGPaletteMem, 256);
}

void setObjPalette(u16* pal_array){
	memcpy16(pal_array, OBJPaletteMem, 256);
}

void waitForVsync(){
	while((vu16)REG_VCOUNT != 160){}
}

void delay(int interval){
	int i, j;
	for(i = 0; i < interval; i++)
		for (j = 0; j < 10000; j++);
}

void print(char *s)
{
 asm volatile("mov r0, %0;"
			  "swi 0xff0000;"
			  : // no ouput
			  : "r" (s)
			  : "r0");
}



void setBackground(u16* image_array)
{
	int i;
	while ((volatile u16)REG_VCOUNT != 160);
	for (i = 0; i < 120 * 160; ++i){
		VideoBuffer[i] = image_array[i];
	}
}

