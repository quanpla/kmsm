// gba.h by eloist 

#ifndef GBA_HEADER
#define GBA_HEADER

#undef MUSIC
#define MUSIC

typedef unsigned char u8;
typedef unsigned short u16;
typedef unsigned long u32;

typedef signed char s8;
typedef signed short s16; 
typedef signed long s32;

typedef unsigned char byte;
typedef unsigned short hword;
typedef unsigned long word;

typedef volatile unsigned  char vu8;
typedef volatile unsigned  short vu16;
typedef volatile unsigned  long vu32;

typedef volatile signed char vs8;
typedef volatile signed short vs16;
typedef volatile signed long vs32;

 typedef void (*fp)(void);

#define NULL 0


#define IN_EWRAM __attribute__ ((section (".ewram")))
#define IN_IWRAM __attribute__ ((section (".iwram")))
//#define IN_IWRAM_FAR __attribute__((section(".iwram"),long_call))

#define RGB16(r,g,b)  ((r)+(g<<5)+(b<<10))

#define FIXED s32
#define PI 3.14159
#define RADIAN(n) 		(((float)n)/(float)180*PI)

#define OAMMem  	((u32*)0x7000000)
#define VideoBuffer 	((u16*)0x6000000)
#define OAMData		((u16*)0x6010000)
#define BGPaletteMem 	((u16*)0x5000000)
#define OBJPaletteMem 	((u16*)0x5000200)

#define REG_IFCHECKBUFF   *(vu16*)0x3007FF8
#define REG_INTERUPT   (*(u32*)0x3007FFC)
#define REG_DISPCNT    *(vu32*)0x4000000
#define REG_DISPCNT_L  *(vu16*)0x4000000
#define REG_DISPCNT_H  *(vu16*)0x4000002
#define REG_DISPSTAT   *(vu16*)0x4000004
#define REG_VCOUNT     *(vu16*)0x4000006
#define REG_BG0CNT     *(vu16*)0x4000008
#define REG_BG1CNT     *(vu16*)0x400000A
#define REG_BG2CNT     *(vu16*)0x400000C
#define REG_BG3CNT     *(vu16*)0x400000E
#define REG_BG0HOFS    *(vu16*)0x4000010
#define REG_BG0VOFS    *(vu16*)0x4000012
#define REG_BG1HOFS    *(vu16*)0x4000014
#define REG_BG1VOFS    *(vu16*)0x4000016
#define REG_BG2HOFS    *(vu16*)0x4000018
#define REG_BG2VOFS    *(vu16*)0x400001A
#define REG_BG3HOFS    *(vu16*)0x400001C
#define REG_BG3VOFS    *(vu16*)0x400001E
#define REG_BG2PA      *(vu16*)0x4000020
#define REG_BG2PB      *(vu16*)0x4000022
#define REG_BG2PC      *(vu16*)0x4000024
#define REG_BG2PD      *(vu16*)0x4000026
#define REG_BG2X       *(vu32*)0x4000028
#define REG_BG2X_L     *(vu16*)0x4000028
#define REG_BG2X_H     *(vu16*)0x400002A
#define REG_BG2Y       *(vu32*)0x400002C
#define REG_BG2Y_L     *(vu16*)0x400002C
#define REG_BG2Y_H     *(vu16*)0x400002E
#define REG_BG3PA      *(vu16*)0x4000030
#define REG_BG3PB      *(vu16*)0x4000032
#define REG_BG3PC      *(vu16*)0x4000034
#define REG_BG3PD      *(vu16*)0x4000036
#define REG_BG3X       *(vu32*)0x4000038
#define REG_BG3X_L     *(vu16*)0x4000038
#define REG_BG3X_H     *(vu16*)0x400003A
#define REG_BG3Y       *(vu32*)0x400003C
#define REG_BG3Y_L     *(vu16*)0x400003C
#define REG_BG3Y_H     *(vu16*)0x400003E
#define REG_WIN0H      *(vu16*)0x4000040
#define REG_WIN1H      *(vu16*)0x4000042
#define REG_WIN0V      *(vu16*)0x4000044
#define REG_WIN1V      *(vu16*)0x4000046
#define REG_WININ      *(vu16*)0x4000048
#define REG_WINOUT     *(vu16*)0x400004A
#define REG_MOSAIC     *(vu32*)0x400004C
#define REG_MOSAIC_L   *(vu32*)0x400004C
#define REG_MOSAIC_H   *(vu32*)0x400004E
#define REG_BLDMOD     *(vu16*)0x4000050
#define REG_COLV      *(vu16*)0x4000052
#define REG_COLY      *(vu16*)0x4000054
#define REG_SG10       *(vu32*)0x4000060
#define REG_SG10_L     *(vu16*)0x4000060
#define REG_SG10_H     *(vu16*)0x4000062
#define REG_SG11       *(vu16*)0x4000064
#define REG_SG20       *(vu16*)0x4000068
#define REG_SG21       *(vu16*)0x400006C
#define REG_SG30       *(vu32*)0x4000070
#define REG_SG30_L     *(vu16*)0x4000070
#define REG_SG30_H     *(vu16*)0x4000072
#define REG_SG31       *(vu16*)0x4000074
#define REG_SG40       *(vu16*)0x4000078
#define REG_SG41       *(vu16*)0x400007C
#define REG_SGCNT0     *(vu32*)0x4000080
#define REG_SGCNT0_L   *(vu16*)0x4000080
#define REG_SGCNT0_H   *(vu16*)0x4000082
#define REG_SGCNT1     *(vu16*)0x4000084
#define REG_SGBIAS     *(vu16*)0x4000088
#define REG_SGWR0      *(vu32*)0x4000090
#define REG_SGWR0_L    *(vu16*)0x4000090
#define REG_SGWR0_H    *(vu16*)0x4000092
#define REG_SGWR1      *(vu32*)0x4000094
#define REG_SGWR1_L    *(vu16*)0x4000094
#define REG_SGWR1_H    *(vu16*)0x4000096
#define REG_SGWR2      *(vu32*)0x4000098
#define REG_SGWR2_L    *(vu16*)0x4000098
#define REG_SGWR2_H    *(vu16*)0x400009A
#define REG_SGWR3      *(vu32*)0x400009C
#define REG_SGWR3_L    *(vu16*)0x400009C
#define REG_SGWR3_H    *(vu16*)0x400009E
#define REG_SGFIFOA    ((vu32*)0x40000A0)
#define REG_SGFIFOA_L  *(vu16*)0x40000A0
#define REG_SGFIFOA_H  *(vu16*)0x40000A2
#define REG_SGFIFOB    ((vu32*)0x40000A4)
#define REG_SGFIFOB_L  *(vu16*)0x40000A4
#define REG_SGFIFOB_H  *(vu16*)0x40000A6
#define REG_DMA0SAD     *(vu32*)0x40000B0
#define REG_DMA0SAD_L   *(vu16*)0x40000B0
#define REG_DMA0SAD_H   *(vu16*)0x40000B2
#define REG_DMA0DAD     *(vu32*)0x40000B4
#define REG_DMA0DAD_L   *(vu16*)0x40000B4
#define REG_DMA0DAD_H   *(vu16*)0x40000B6
#define REG_DMA0CNT     *(vu32*)0x40000B8
#define REG_DMA0CNT_L   *(vu16*)0x40000B8
#define REG_DMA0CNT_H   *(vu16*)0x40000BA
#define REG_DMA1SAD     *(vu32*)0x40000BC
#define REG_DMA1SAD_L   *(vu16*)0x40000BC
#define REG_DMA1SAD_H   *(vu16*)0x40000BE
#define REG_DMA1DAD     *(vu32*)0x40000C0
#define REG_DMA1DAD_L   *(vu16*)0x40000C0
#define REG_DMA1DAD_H   *(vu16*)0x40000C2
#define REG_DMA1CNT     *(vu32*)0x40000C4
#define REG_DMA1CNT_L   *(vu16*)0x40000C4
#define REG_DMA1CNT_H   *(vu16*)0x40000C6
#define REG_DMA2SAD     *(vu32*)0x40000C8
#define REG_DMA2SAD_L   *(vu16*)0x40000C8
#define REG_DMA2SAD_H   *(vu16*)0x40000CA
#define REG_DMA2DAD     *(vu32*)0x40000CC
#define REG_DMA2DAD_L   *(vu16*)0x40000CC
#define REG_DMA2DAD_H   *(vu16*)0x40000CE
#define REG_DMA2CNT     *(vu32*)0x40000D0
#define REG_DMA2CNT_L   *(vu16*)0x40000D0
#define REG_DMA2CNT_H   *(vu16*)0x40000D2
#define REG_DMA3SAD     *(vu32*)0x40000D4
#define REG_DMA3SAD_L   *(vu16*)0x40000D4
#define REG_DMA3SAD_H   *(vu16*)0x40000D6
#define REG_DMA3DAD     *(vu32*)0x40000D8
#define REG_DMA3DAD_L   *(vu16*)0x40000D8
#define REG_DMA3DAD_H   *(vu16*)0x40000DA
#define REG_DMA3CNT     *(vu32*)0x40000DC
#define REG_DMA3CNT_L   *(vu16*)0x40000DC
#define REG_DMA3CNT_H   *(vu16*)0x40000DE
#define REG_TM0D       *(vu16*)0x4000100
#define REG_TM0CNT     *(vu16*)0x4000102
#define REG_TM1D       *(vu16*)0x4000104
#define REG_TM1CNT     *(vu16*)0x4000106
#define REG_TM2D       *(vu16*)0x4000108
#define REG_TM2CNT     *(vu16*)0x400010A
#define REG_TM3D       *(vu16*)0x400010C
#define REG_TM3CNT     *(vu16*)0x400010E
#define REG_SCD0       *(vu16*)0x4000120
#define REG_SCD1       *(vu16*)0x4000122
#define REG_SCD2       *(vu16*)0x4000124
#define REG_SCD3       *(vu16*)0x4000126
#define REG_SCCNT      *(vu32*)0x4000128
#define REG_SCCNT_L    *(vu16*)0x4000128
#define REG_SCCNT_H    *(vu16*)0x400012A
#define REG_P1         *(vu16*)0x4000130
#define REG_P1CNT      *(vu16*)0x4000132
#define REG_R          *(vu16*)0x4000134
#define REG_HS_CTRL    *(vu16*)0x4000140
#define REG_JOYRE      *(vu32*)0x4000150
#define REG_JOYRE_L    *(vu16*)0x4000150
#define REG_JOYRE_H    *(vu16*)0x4000152
#define REG_JOYTR      *(vu32*)0x4000154
#define REG_JOYTR_L    *(vu16*)0x4000154
#define REG_JOYTR_H    *(vu16*)0x4000156
#define REG_JSTAT      *(vu32*)0x4000158
#define REG_JSTAT_L    *(vu16*)0x4000158
#define REG_JSTAT_H    *(vu16*)0x400015A
#define REG_IE         *(vu16*)0x4000200
#define REG_IF         *(vu16*)0x4000202
#define REG_WSCNT      *(vu16*)0x4000204
#define REG_IME        *(vu16*)0x4000208
#define REG_PAUSE      *(vu16*)0x4000300

#define BIT0 1
#define BIT1 (1<<1)
#define BIT2 (1<<2)
#define BIT3 (1<<3)
#define BIT4 (1<<4)
#define BIT5 (1<<5)
#define BIT6 (1<<6)
#define BIT7 (1<<7)
#define BIT8 (1<<8)
#define BIT9 (1<<9)
#define BIT10 (1<<10)
#define BIT11 (1<<11)
#define BIT12 (1<<12)
#define BIT13 (1<<13)
#define BIT14 (1<<14)
#define BIT15 (1<<15)
#define BIT16 (1<<16)
#define BIT17 (1<<17)
#define BIT18 (1<<18)
#define BIT19 (1<<19)
#define BIT20 (1<<20)
#define BIT21 (1<<21)
#define BIT22 (1<<22)
#define BIT23 (1<<23)
#define BIT24 (1<<24)
#define BIT25 (1<<25)
#define BIT26 (1<<26)
#define BIT27 (1<<27)
#define BIT28 (1<<28)
#define BIT29 (1<<29)
#define BIT30 (1<<30)
#define BIT31 (1<<31)

#define MOS_BG_HOR(n) (n)
#define MOS_BG_VER(n) (n<<4)
#define MOS_OBJ_HOR(n) (n<<8)
#define MOS_OBJ_VER(n) (n<<12)

#define SetMosaic(bh,bv,oh,ov) ((bh)+(bv<<4)+(oh<<8)+(ov<<12))

//extern void dprint(const char *sz) 
//{
//  asm volatile("
//    mov r2, %0
//    ldr r0, =0xc0ded00d
//    mov r1, #0
//    and r0, r0, r0
//  " :
//  /* No output */ :
//  "r" (sz) :
//  "r0", "r1", "r2");
//}

#endif
