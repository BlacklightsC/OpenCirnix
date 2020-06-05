#include "Warcraft.h"
#pragma comment (lib, "Version.lib")

//DWORD GAME_GlobalClass = dwGameDll + 0xD326F0;		// AB4F80 D326F0
//DWORD GAME_PrintToScreen = dwGameDll + 0x3A8EB0;	// 2F8E40
//
//void TextPrint(char *szText, float fDuration)
//{
//	DWORD dwDuration = *((DWORD *)&fDuration);
//
//	__asm
//	{
//		PUSH	0xFFFFFFFF
//		PUSH	dwDuration
//		PUSH	szText
//		PUSH	0x0
//		PUSH	0x0
//		MOV		ECX, [GAME_GlobalClass]
//		MOV		ECX, [ECX]
//		CALL	GAME_PrintToScreen
//	}
//}
//
//void TextPrintEx(char *szText, ...)
//{
//	char szTextEx[8192] = {NULL};
//
//	va_list Args;
//	va_start(Args, szText);
//	vsprintf_s(szTextEx, szText, Args);
//	va_end(Args);
//
//	TextPrint(szTextEx);
//}

DWORD WarcraftVersion()
{
	DWORD dwHandle = NULL;
	DWORD dwLen    = GetFileVersionInfoSize(TEXT("Game.dll"), &dwHandle);

	LPVOID lpData = new char[dwLen];
	GetFileVersionInfo(TEXT("Game.dll"), dwHandle, dwLen, lpData);

	LPBYTE lpBuffer = NULL;
	UINT   uLen     = NULL;
	VerQueryValue(lpData, TEXT("\\"), (LPVOID *)&lpBuffer, &uLen);

	VS_FIXEDFILEINFO *Version = (VS_FIXEDFILEINFO *)lpBuffer;

	return LOWORD(Version->dwFileVersionLS);
}