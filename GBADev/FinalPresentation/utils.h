#include "../common/gba.h"

#ifndef _AGK_GBA_UTILS_H_
#define _AGK_GBA_UTILS_H_

void memcpy16(u16* src, u16* dest, u16 numCount);
void setPalette(u16* pal_array);
void setObjPalette(u16* pal_array);
void waitForVsync();
void delay(int interval);
void print(char *s);
void setBackground(u16* image_array);

#endif //_AGK_GBA_UTILS_H_