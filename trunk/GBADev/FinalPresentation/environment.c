// background also
#include "./Images/background.c"
#include "./Images/background.raw.c"

#include "./Images/background_gameover.c"
#include "./Images/background_gameover.raw.c"

#include "./Images/background_start.c"
#include "./Images/background_start.raw.c"

void setBG_Game(void){
	setPalette(background_Palette);
	setBackground(background_Bitmap);
}

void setBG_Start(void){
	setPalette(background_start_Palette);
	setBackground(background_start_Bitmap);
}

void setBG_GameOver(void){
	setPalette(background_gameover_Palette);
	setBackground(background_gameover_Bitmap);
}
