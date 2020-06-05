#include "Warcraft.h"

BOOL WINAPI DllMain(HMODULE hModule, DWORD dwReason, LPVOID lpReserved)
{
	if (dwReason == DLL_PROCESS_ATTACH)
	{
		DisableThreadLibraryCalls(hModule);
		//HideDll((HMODULE)dwGameDll);
		//HideDll(hModule);
		if (WarcraftVersion() == 7680)
		{
			SettingInitialize();
			DreamUiInit();
			ManaBarInit();
		}
	}

	return TRUE;
}