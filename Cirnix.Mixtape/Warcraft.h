#pragma once

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <stdlib.h>
#include <stdio.h>
#include <vector>
#include "Functions.h"
#include "Dream UI.h"
#include "Mana Bar.h"
#include "States.h"
#include "HotKeys.h"
#include "Warcraft Functions.h"

const HWND  hWnd      = FindWindow(TEXT("Warcraft III"), NULL);
const DWORD dwGameDll = (DWORD)GetModuleHandle(TEXT("Game.dll"));