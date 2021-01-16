#include "Warcraft.h"
#pragma execution_character_set("utf-8")

DWORD Storm503 = dwGameDll + 0xA5FF4; // A5FF4	// 6EB5BE
DWORD Storm578 = dwGameDll + 0xA5F94; // A5F94	// 6EB5A6

char *AsFormat   = "%0.02f";
char *MsFormat   = "%0.0f";
char buffer[4096];
char * bufferaddr = 0;
int saveeax = 0;
int saveebx = 0;
int saveecx = 0;
int saveedx = 0;
int saveesi = 0;
int saveedi = 0;
int saveebp = 0;
int saveesp = 0;


BOOL PlantDetourJMP(BYTE* source, const BYTE* destination, size_t length)
{
	DWORD oldProtection;
	BOOL bRet = VirtualProtect(source, length, PAGE_EXECUTE_READWRITE, &oldProtection);

	if (bRet == FALSE)
		return FALSE;

	source[0] = 0xE9;
	*(DWORD*)(source + 1) = (DWORD)(destination - source) - 5;

	for (unsigned int i = 5; i < length; i++)
		source[i] = 0x90;

	VirtualProtect(source, length, oldProtection, &oldProtection);
	FlushInstructionCache(GetCurrentProcess(), source, length);
	return TRUE;
}



//void __declspec(naked) GetHpRegen()
//{
//	_asm
//	{
//		LEA  EAX, [ESP+0x0D8]
//
//		PUSH EAX
//		PUSH ECX
//		PUSH ESI
//
//		ADD  ECX, 0x98
//		MOV  ECX, DWORD PTR DS:[ECX+8]
//		MOV  ESI, dwGameDll
//		MOV  EAX, GetRegen
//		MOV  ESI, DWORD PTR DS:[ESI+EAX]
//		MOV  EAX, DWORD PTR DS:[ESI+0x0C]
//		MOV  ECX, DWORD PTR DS:[ECX*8+EAX+4]
//		MOV  ECX, DWORD PTR DS:[ECX+0x7C]
//		MOV  HpRegen, ECX
//
//		POP  ESI
//		POP  ECX
//		POP  EAX
//
//		RETN
//	}
//}
//
//void __declspec(naked) GetMpRegen()
//{
//	_asm
//	{
//		ADD  ECX, 0x0B8
//
//		PUSH EAX
//		PUSH ECX
//		PUSH ESI
//
//		MOV  ECX, DWORD PTR DS:[ECX+8]
//		MOV  ESI, dwGameDll
//		MOV  EAX, GetRegen
//		MOV  ESI, DWORD PTR DS:[ESI+EAX]
//		MOV  EAX, DWORD PTR DS:[ESI+0x0C]
//		MOV  ECX, DWORD PTR DS:[ECX*8+EAX+4]
//		MOV  ECX, DWORD PTR DS:[ECX+0x7C]
//		MOV  MpRegen, ECX
//
//		POP  ESI
//		POP  ECX
//		POP  EAX
//
//		RETN
//	}
//}

BOOL __stdcall IsHero(int unitaddr)
{
	if (unitaddr > 0)
	{
		unsigned int ishero = *(unsigned int*)(unitaddr + 48);
		ishero = ishero >> 24;
		ishero = ishero - 64;
		return ishero < 0x19;
	}
	return FALSE;
}

int __stdcall PrintAttackSpeedAndOtherInfo(int addr, float * attackspeed, float * BAT, int * unitaddr)
{
	int retval = 0;
	__asm mov retval, eax;
	if (unitaddr > 0)
	{
		bufferaddr = buffer;
		float realBAT = *(float*)BAT;
		float fixedattackspeed = *(float*)attackspeed;
		float realattackspeed = fixedattackspeed;
		float maxattackspeed = *(float*)(dwGameDll + 0xD33DA4);
		if (fixedattackspeed > maxattackspeed)
			fixedattackspeed = maxattackspeed;

		if (realattackspeed < 0.0f) realattackspeed = 0.01f;
		if (fixedattackspeed < 0.0f) fixedattackspeed = 0.01f;

		float AttacksPerSec = 0.0f;
		float AttackReload = 0.0f;

		if (fixedattackspeed != 0.0f && realBAT != 0.0f)
		{
			AttacksPerSec = fixedattackspeed / realBAT;
			AttackReload = 1.0f / (fixedattackspeed / realBAT);
		}

		float AttackSpeedBonus = realattackspeed * 100.0f - 100.0f;

		if (/*IsNotBadUnit(*unitaddr) && */IsHero(*unitaddr))
		{
			float MaxAttacksPerSec = maxattackspeed / realBAT;
			float MaxAttackReload = 1.0f / (maxattackspeed / realBAT);
#pragma warning(push)
#pragma warning(disable: 4819)
			sprintf_s(buffer, sizeof(buffer), "%.1f/초 (주기: %.2f 초)|n공격 속도 보너스: %.0f%%|n한계 속도: %.1f/초 (주기: %.2f 초)|n", AttacksPerSec, AttackReload, AttackSpeedBonus, MaxAttacksPerSec, MaxAttackReload);
#pragma warning(pop)
		}
		else
		{
#pragma warning(push)
#pragma warning(disable: 4819)
			sprintf_s(buffer, sizeof(buffer), "%.3f/초 (주기: %.2f 초)|n공격 속도 보너스: %.0f%%", AttacksPerSec, AttackReload, AttackSpeedBonus);
#pragma warning(pop)
		}

		__asm
		{
			PUSH 0x200;
			PUSH bufferaddr;
			PUSH addr;
			CALL Storm503;
		}
	}

	return retval;
}

void __declspec(naked)  PrintAttackSpeedAndOtherInfoHook128f()
{
	__asm
	{
		mov saveeax, eax;
		mov eax, [esp + 0x10];
		cmp eax, 0;
		JE JUSTEND;
		add eax, 0x30;
		push eax;
		add eax, 0x128;
		push eax;
		add eax, 0x58;
		push eax;
		push ecx;
		call PrintAttackSpeedAndOtherInfo;
	JUSTEND:;
		mov eax, saveeax;
		ret 8;
	}
}

/*
void __declspec(naked) AsToInt()
{
	_asm
	{
		MOV  [EBP-8], EAX
		MOV  EAX, DWORD PTR DS:[ESP]
		MOV  [EBP-0xC], EAX
		MOV  EAX, [EBP-8]

		FLD  DWORD PTR SS:[ESP+0x78]
		SUB  ESP, 8
		FSTP QWORD PTR SS:[ESP]
		PUSH AsFormat
		PUSH 7
		PUSH EAX			// Text Push
		CALL Storm578

		ADD  ESP, 0x18

		CALL Storm503
		PUSH [EBP-0xC]

		RETN
	}
}
*/

void __declspec(naked) MsToInt()
{
	_asm
	{
		MOV	 [EBP-8], EAX
		MOV  EAX, DWORD PTR DS:[ESP]
		MOV  [EBP-0xC], EAX
		MOV  EAX, [EBP-8]

		FLD  DWORD PTR SS:[ESP+0x78]
		SUB  ESP, 8
		FSTP QWORD PTR SS:[ESP]
		PUSH MsFormat
		PUSH 7
		PUSH EAX
		CALL Storm578

		ADD  ESP, 0x18

		CALL Storm503
		PUSH [EBP-0xC]

		RETN
	}
}



//void __declspec(naked) ShowText()
//{
//	_asm
//	{
//		PUSH ECX
//		LEA  ECX, [ESP+0x30]
//		FLD  MpRegen
//		FLD  HpRegen
//		SUB  ESP, 0x10
//		FSTP QWORD PTR SS:[ESP]
//		FSTP QWORD PTR SS:[ESP+8]
//		PUSH ECX
//		PUSH HpMpFormat
//		PUSH 0x80
//		PUSH ECX
//		CALL Storm578;
//		ADD  ESP, 0x20
//		POP  ECX
//		MOV  EDI, [EBP+0x134]
//		RETN
//	}
//}

void DreamUiInit()
{
	DWORD dwOldProtection = NULL;
	//VirtualProtect((LPVOID)(dwGameDll + 0x339150), 100, PAGE_EXECUTE_READWRITE, &dwOldProtection);
	//*(BYTE *)(dwGameDll + 0x339150) = 0xE9;
	//*(DWORD *) (dwGameDll + 0x339151) = (DWORD)PrintAttackSpeedAndOtherInfoHook1285 - (dwGameDll + 0x339150) - 5;
	//VirtualProtect((LPVOID)(dwGameDll + 0x339150), 100, dwOldProtection, NULL);


	// Show AS & MS in Number
	if (SettingGet("Show AS & MS in Number"))
	{
		VirtualProtect((LPVOID)(dwGameDll + 0x3DEE20), 100, PAGE_EXECUTE_READWRITE, &dwOldProtection);
		*(DWORD *)(dwGameDll + 0x3DEE2B) = (DWORD)MsToInt - (dwGameDll + 0x3DEE2F);
		VirtualProtect((LPVOID)(dwGameDll + 0x3DEE20), 100, dwOldProtection, NULL);
		//*(DWORD *) (dwGameDll + 0x3DE0BB) = (DWORD)AsToInt - (dwGameDll + 0x3DE0BF);
		PlantDetourJMP((BYTE*)(dwGameDll + 0x3DDF60), (BYTE*)PrintAttackSpeedAndOtherInfoHook128f, 5);
	}

	// Show HP & MP Regen
	//if (SettingGet("Show HP & MP Regen"))
	//{
	//	VirtualProtect((LPVOID)(dwGameDll + 0x358000), 515000, PAGE_EXECUTE_READWRITE, &dwOldProtection);
	//	*(BYTE *)(dwGameDll + 0x358137) = 0xE8;
	//	*(DWORD *) (dwGameDll + 0x358138) = (DWORD)GetHpRegen - (dwGameDll + 0x35813C);
	//	*(BYTE *)(dwGameDll + 0x35813C) = 0x90;
	//	*(BYTE *)(dwGameDll + 0x35813D) = 0x90;
	//	*(BYTE *)(dwGameDll + 0x358322) = 0xE8;
	//	*(DWORD *) (dwGameDll + 0x358323) = (DWORD)GetMpRegen - (dwGameDll + 0x358327);
	//	*(BYTE *)(dwGameDll + 0x358327) = 0x90;
	//	VirtualProtect((LPVOID)(dwGameDll + 0x358000), 515000, dwOldProtection, NULL);
	//	VirtualProtect((LPVOID)(dwGameDll + 0x354B0C), 6, PAGE_EXECUTE_READWRITE, &dwOldProtection);
	//	*(BYTE *)(dwGameDll + 0x354B0C) = 0xE8;
	//	*(DWORD *) (dwGameDll + 0x354B0D) = (DWORD)ShowText - (dwGameDll + 0x354B11);
	//	*(BYTE *)(dwGameDll + 0x354B11) = 0x90;
	//	VirtualProtect((LPVOID)(dwGameDll + 0x354B0C), 6, dwOldProtection, NULL);
	//}
}