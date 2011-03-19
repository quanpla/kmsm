#ifndef _environment_h_
#define _environment_h_

#define AXIS_ZERO_POINT_X 10
#define AXIS_ZERO_POINT_Y 150

#define ROCKET_NUMBER_OF_ENTITY 4 // support 4 rockets
#define ENEMY_NUMBER_OF_ENTITY 4 // support 4 enemies


#define GROUND_COORDINATE 140 // Y coordinate of the ground

#define LAUNCHER_START_COORDINATE 10 // Start X coordinate of the rocket launcher
#define LAUNCHER_SPEED Int2Fix(5);
#define LAUNCHER_LIMIT_X_LEFT Int2Fix(0)
#define LAUNCHER_LIMIT_X_RIGHT Int2Fix(100)

#define ROCKET_LIMIT_X_LEFT 0
#define ROCKET_LIMIT_X_RIGHT Int2Fix(240)
#define ROCKET_SPEED_MIN Int2Fix(10)
#define ROCKET_SPEED_MAX Int2Fix(31)
#define ROCKET_SPEED_STEP Int2Fix(1)
#define ROCKET_LIMIT_Y_TOP -16

#define OBJECT_TIME_UNIT (1 << 10)

#define GRAVITATIONAL_ACCELERATE (7 << 15)
#define WIND_SPEED 0

#define KEYPAD_SENSITIVITY_HIGH 1
#define KEYPAD_SENSITIVITY_MID 50
#define KEYPAD_SENSITIVITY_LOW 100

void setBG_Game(void);
void setBG_Start(void);
void setBG_GameOver(void);

#endif