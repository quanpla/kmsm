@ECHO OFF
SET GFX2GBA=D:\GBADev\gfx2gba\gfx2gba.exe

%GFX2GBA% -pSprites -fsrc -t8 Launcher1.bmp Launcher2.bmp Rocket1.bmp Rocket2.bmp Rocket3.bmp Enemy1.bmp Enemy2.bmp
%GFX2GBA% -pBckgrnd -fsrc background2.bmp
