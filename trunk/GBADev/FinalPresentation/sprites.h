// managing sprites
#ifndef _sprite_h_
#define _sprite_h_

#define ROCKET_SPRITE_ID 0
#define ROCKET_SPRITE_SIZE 16
#define ROCKET_SPRITE_ANIM_NUM 3

#define LAUNCHER_SPRITE_ID 1
#define LAUNCHER_SPRITE_SIZE 16
#define LAUNCHER_SPRITE_ANIM_NUM 2

#define ENEMY_SPRITE_ID 2
#define ENEMY_SPRITE_SIZE 16
#define ENEMY_SPRITE_ANIM_NUM 2

void initializeSprites(void);
void hideSprite(int spriteId);

void setRocketAnimation(int rocketId, int frameId);
void setRocketLocation(int rocketId, int x, int y);
void setRocketAngle(int rocketId, int angle);

void setLauncherAnimation(int frameId);
void setLauncherLocation(int x, int y);

void setEnemyAnimation(int enemyId, int frameId);
void setEnemyLocation(int enemyId, int x, int y);

#endif // _sprite_h_
