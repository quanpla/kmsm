//Filename: sincosrad.h
//Author: gbajunkie
//Usage: Pre-calculated Sin and Cos and Radian Arrays, used for rotation of sprites
//Date: 31/05/2002

#ifndef SINCOS_H
#define SINCOS_H

const signed long SIN[360] = {	0, 1144, 2287, 3430, 4572, 5712, 6850, 7987, 9121, 10252,
							11380, 12505, 13626, 14742, 15855, 16962, 18064, 19161, 20252, 21336,
							22415, 23486, 24550, 25607, 26656, 27697, 28729, 29753, 30767, 31772,
							32768, 33754, 34729, 35693, 36647, 37590, 38521, 39441, 40348, 41243,
							42126, 42995, 43852, 44695, 45525, 46341, 47143, 47930, 48703, 49461,
							50203, 50931, 51643, 52339, 53020, 53684, 54332, 54963, 55578, 56175,
							56756, 57319, 57865, 58393, 58903, 59396, 59870, 60326, 60764, 61183,
							61584, 61966, 62328, 62672, 62997, 63303, 63589, 63856, 64104, 64332,
							64540, 64729, 64898, 65048, 65177, 65287, 65376, 65446, 65496, 65526,
							65536, 65526, 65496, 65446, 65376, 65287, 65177, 65048, 64898, 64729,
							64540, 64332, 64104, 63856, 63589, 63303, 62997, 62672, 62328, 61966,
							61584, 61183, 60764, 60326, 59870, 59396, 58903, 58393, 57865, 57319,
							56756, 56175, 55578, 54963, 54332, 53684, 53020, 52339, 51643, 50931,
							50203, 49461, 48703, 47930, 47143, 46341, 45525, 44695, 43852, 42995,
							42126, 41243, 40348, 39441, 38521, 37590, 36647, 35693, 34729, 33754,
							32768, 31772, 30767, 29753, 28729, 27697, 26656, 25607, 24550, 23486,
							22415, 21336, 20252, 19161, 18064, 16962, 15855, 14742, 13626, 12505,
							11380, 10252, 9121, 7987, 6850, 5712, 4572, 3430, 2287, 1144,
							0, -1144, -2287, -3430, -4572, -5712, -6850, -7987, -9121, -10252,
							-11380, -12505, -13626, -14742, -15855, -16962, -18064, -19161, -20252, -21336,
							-22415, -23486, -24550, -25607, -26656, -27697, -28729, -29753, -30767, -31772,
							-32768, -33754, -34729, -35693, -36647, -37590, -38521, -39441, -40348, -41243,
							-42126, -42995, -43852, -44695, -45525, -46341, -47143, -47930, -48703, -49461,
							-50203, -50931, -51643, -52339, -53020, -53684, -54332, -54963, -55578, -56175,
							-56756, -57319, -57865, -58393, -58903, -59396, -59870, -60326, -60764, -61183,
							-61584, -61966, -62328, -62672, -62997, -63303, -63589, -63856, -64104, -64332,
							-64540, -64729, -64898, -65048, -65177, -65287, -65376, -65446, -65496, -65526,
							-65536, -65526, -65496, -65446, -65376, -65287, -65177, -65048, -64898, -64729,
							-64540, -64332, -64104, -63856, -63589, -63303, -62997, -62672, -62328, -61966,
							-61584, -61183, -60764, -60326, -59870, -59396, -58903, -58393, -57865, -57319,
							-56756, -56175, -55578, -54963, -54332, -53684, -53020, -52339, -51643, -50931,
							-50203, -49461, -48703, -47930, -47143, -46341, -45525, -44695, -43852, -42995,
							-42126, -41243, -40348, -39441, -38521, -37590, -36647, -35693, -34729, -33754,
							-32768, -31772, -30767, -29753, -28729, -27697, -26656, -25607, -24550, -23486,
							-22415, -21336, -20252, -19161, -18064, -16962, -15855, -14742, -13626, -12505,
							-11380, -10252, -9121, -7987, -6850, -5712, -4572, -3430, -2287, -1144
};

const signed long COS[360] = {	65536, 65526, 65496, 65446, 65376, 65287, 65177, 65048, 64898, 64729,
								64540, 64332, 64104, 63856, 63589, 63303, 62997, 62672, 62328, 61966,
								61584, 61183, 60764, 60326, 59870, 59396, 58903, 58393, 57865, 57319,
								56756, 56175, 55578, 54963, 54332, 53684, 53020, 52339, 51643, 50931,
								50203, 49461, 48703, 47930, 47143, 46341, 45525, 44695, 43852, 42995,
								42126, 41243, 40348, 39441, 38521, 37590, 36647, 35693, 34729, 33754,
								32768, 31772, 30767, 29753, 28729, 27697, 26656, 25607, 24550, 23486,
								22415, 21336, 20252, 19161, 18064, 16962, 15855, 14742, 13626, 12505,
								11380, 10252, 9121, 7987, 6850, 5712, 4572, 3430, 2287, 1144,
								0, -1144, -2287, -3430, -4572, -5712, -6850, -7987, -9121, -10252,
								-11380, -12505, -13626, -14742, -15855, -16962, -18064, -19161, -20252, -21336,
								-22415, -23486, -24550, -25607, -26656, -27697, -28729, -29753, -30767, -31772,
								-32768, -33754, -34729, -35693, -36647, -37590, -38521, -39441, -40348, -41243,
								-42126, -42995, -43852, -44695, -45525, -46341, -47143, -47930, -48703, -49461,
								-50203, -50931, -51643, -52339, -53020, -53684, -54332, -54963, -55578, -56175,
								-56756, -57319, -57865, -58393, -58903, -59396, -59870, -60326, -60764, -61183,
								-61584, -61966, -62328, -62672, -62997, -63303, -63589, -63856, -64104, -64332,
								-64540, -64729, -64898, -65048, -65177, -65287, -65376, -65446, -65496, -65526,
								-65536, -65526, -65496, -65446, -65376, -65287, -65177, -65048, -64898, -64729,
								-64540, -64332, -64104, -63856, -63589, -63303, -62997, -62672, -62328, -61966,
								-61584, -61183, -60764, -60326, -59870, -59396, -58903, -58393, -57865, -57319,
								-56756, -56175, -55578, -54963, -54332, -53684, -53020, -52339, -51643, -50931,
								-50203, -49461, -48703, -47930, -47143, -46341, -45525, -44695, -43852, -42995,
								-42126, -41243, -40348, -39441, -38521, -37590, -36647, -35693, -34729, -33754,
								-32768, -31772, -30767, -29753, -28729, -27697, -26656, -25607, -24550, -23486,
								-22415, -21336, -20252, -19161, -18064, -16962, -15855, -14742, -13626, -12505,
								-11380, -10252, -9121, -7987, -6850, -5712, -4572, -3430, -2287, -1144,
								0, 1144, 2287, 3430, 4572, 5712, 6850, 7987, 9121, 10252,
								11380, 12505, 13626, 14742, 15855, 16962, 18064, 19161, 20252, 21336,
								22415, 23486, 24550, 25607, 26656, 27697, 28729, 29753, 30767, 31772,
								32768, 33754, 34729, 35693, 36647, 37590, 38521, 39441, 40348, 41243,
								42126, 42995, 43852, 44695, 45525, 46341, 47143, 47930, 48703, 49461,
								50203, 50931, 51643, 52339, 53020, 53684, 54332, 54963, 55578, 56175,
								56756, 57319, 57865, 58393, 58903, 59396, 59870, 60326, 60764, 61183,
								61584, 61966, 62328, 62672, 62997, 63303, 63589, 63856, 64104, 64332,
								64540, 64729, 64898, 65048, 65177, 65287, 65376, 65446, 65496, 65526
};

const signed long TAN[180] = {	0, 1144, 2289, 3435, 4583, 5734, 6888, 8047, 9210, 10380,
							11556, 12739, 13930, 15130, 16340, 17560, 18792, 20036, 21294, 22566,
							23853, 25157, 26478, 27818, 29179, 30560, 31964, 33392, 34846, 36327,
							37837, 39378, 40951, 42560, 44205, 45889, 47615, 49385, 51202, 53070,
							54991, 56970, 59009, 61113, 63287, 65536, 67865, 70279, 72785, 75391,
							78103, 80930, 83882, 86969, 90203, 93595, 97161, 100917, 104880, 109070,
							113512, 118230, 123255, 128622, 134369, 140542, 147196, 154393, 162207, 170727,
							180059, 190330, 201699, 214359, 228551, 244584, 262851, 283868, 308323, 337153,
							371673, 413778, 466313, 533748, 623533, 749080, 937208, 1250501, 1876705, 3754555,
							0/*don't use this value*/, -3754555, -1876705, -1250501, -937208, -749080, -623533, -533748, -466313, -413778,
							-371673, -337153, -308323, -283868, -262851, -244584, -228551, -214359, -201699, -190330,
							-180059, -170727, -162207, -154393, -147196, -140542, -134369, -128622, -123255, -118230,
							-113512, -109070, -104880, -100917, -97161, -93595, -90203, -86969, -83882, -80930,
							-78103, -75391, -72785, -70279, -67865, -65536, -63287, -61113, -59009, -56970,
							-54991, -53070, -51202, -49385, -47615, -45889, -44205, -42560, -40951, -39378,
							-37837, -36327, -34846, -33392, -31964, -30560, -29179, -27818, -26478, -25157,
							-23853, -22566, -21294, -20036, -18792, -17560, -16340, -15130, -13930, -12739,
							-11556, -10380, -9210, -8047, -6888, -5734, -4583, -3435, -2289, -1144
};

#endif