CFLAG = -c -O2
NOWARNING = -w
THUMBMODEL = -mthumb -mthumb-interwork
CC=arm-agb-elf-gcc
AS=arm-agb-elf-as
AR=arm-agb-elf-ar
INSTALL=cp

OLIST = main.o utils.o rlauncher.o rocket.o enemy.o physics.o sprites.o

all: Presentation.gba

Presentation.gba: Presentation.elf
	objcopy -O binary Presentation.elf Presentation.gba

Presentation.elf: $(OLIST)
	$(CC) -o Presentation.elf $(OLIST)

$(OLIST): %.o: %.c
	$(CC) $(CFLAG) $(NOWARNING) $<

clean:
	rm *.o
	rm *.elf
	rm *.gba