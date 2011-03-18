@ECHO OFF

SET GFX2GBA=gfx2gba.exe
SET BACKGROUNDOPTION=-pBCKGRND -fsrc
SET SPRITEOPTION=-pSPRITES -t8 -fsrc

REM Convert Sprites
%GFX2GBA% %SPRITEOPTION% Enemy*.bmp Rocket*.bmp Launcher*.bmp

REM Convert Backgrounds
%GFX2GBA% %BACKGROUNDOPTION% background2.bmp
