#pragma once
#pragma comment(lib, "winmm.lib")

#include <Windows.h>

#ifdef __cplusplus
#define EXPORT extern "C" __declspec (dllexport)
#else
#define EXPORT __declspec (dllexport)
#endif

EXPORT BOOLEAN StartDiag();
EXPORT BOOLEAN SetData(DOUBLE*);