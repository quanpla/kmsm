#ifndef _environment_h_
#define _environment_h_

#define AXIS_ZERO_POINT_X 10
#define AXIS_ZERO_POINT_Y 150

#define ROCKET_NUMBER_OF_ENTITY 4 // support 4 rockets
#define ENEMY_NUMBER_OF_ENTITY 4 // support 4 enemies


#define GROUND_COORDINATE 140 // Y coordinate of the ground

#define LAUNCHER_LIMIT_X_LEFT Int2Fix(0)
#define LAUNCHER_LIMIT_X_RIGHT Int2Fix(100)

#define ROCKET_LIMIT_X_LEFT 0
#define ROCKET_LIMIT_X_RIGHT Int2Fix(240)


#define GRAVITATIONAL_ACCELERATE Int2Fix(3)
#define WIND_SPEED 0
#endif