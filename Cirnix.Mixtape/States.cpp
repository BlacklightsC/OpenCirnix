#include "Warcraft.h"

bool IsChatBoxOpen()
{
	return *(bool *)(dwGameDll + 0xD04FEC);
}

bool IsInGame()
{
	return *(DWORD *)(dwGameDll + 0xD32318) == 4 && *(DWORD *)(dwGameDll + 0xD3231C) == 4;
}