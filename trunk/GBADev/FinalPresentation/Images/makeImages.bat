@ECHO OFF

SET GFX2GBA=gfx2gba.exe
SET BACKGROUNDOPTION=-fsrc
SET SPRITEOPTION=-pSPRITES -t8 -fsrc

REM Convert Sprites
%GFX2GBA% %SPRITEOPTION% Enemy*.bmp Rocket*.bmp Launcher*.bmp

REM Convert Backgrounds
%GFX2GBA% %BACKGROUNDOPTION% -pbackground background.bmp
%GFX2GBA% %BACKGROUNDOPTION% -pbackground_gameover background_gameover.bmp
%GFX2GBA% %BACKGROUNDOPTION% -pbackground_start background_start.bmp
