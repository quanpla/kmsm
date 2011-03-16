CFLAG = -c -O2
NOWARNING = -w
THUMBMODEL = -mthumb -mthumb-interwork
OLIST = dma.o

CC=arm-agb-elf-gcc
AS=arm-agb-elf-as
AR=arm-agb-elf-ar
INSTALL=cp

PCXLIST = $(patsubt %.pcx, %)

$(PCXLIST): %.c %.pcx
	gfx2gba -osrc 