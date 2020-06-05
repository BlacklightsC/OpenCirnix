#include "Warcraft.h"

//void HideDll(HMODULE hModule)
//{
//	DWORD dwPEB_LDR_DATA = NULL;
//
//	_asm
//	{
//		pushad;
//		pushfd;
//		mov eax, fs:[30h]
//		mov eax, [eax+0Ch]
//		mov dwPEB_LDR_DATA, eax
//
//		//InLoadOrderModuleList:
//			mov esi, [eax+0Ch]
//			mov edx, [eax+10h]
//
//		LoopInLoadOrderModuleList:
//			lodsd
//			mov esi, eax
//			mov ecx, [eax+18h]
//			cmp ecx, hModule
//			jne SkipA
//			mov ebx, [eax]
//			mov ecx, [eax+4]
//			mov [ecx], ebx
//			mov [ebx+4], ecx
//			jmp InMemoryOrderModuleList
//
//		SkipA:
//			cmp edx, esi
//			jne LoopInLoadOrderModuleList
//
//		InMemoryOrderModuleList:
//			mov eax, dwPEB_LDR_DATA
//			mov esi, [eax+14h]
//			mov edx, [eax+18h]
//
//		LoopInMemoryOrderModuleList:
//			lodsd
//			mov esi, eax
//			mov ecx, [eax+10h]
//			cmp ecx, hModule
//			jne SkipB
//			mov ebx, [eax]
//			mov ecx, [eax+4]
//			mov [ecx], ebx
//			mov [ebx+4], ecx
//			jmp InInitializationOrderModuleList
//
//		SkipB:
//			cmp edx, esi
//			jne LoopInMemoryOrderModuleList
//
//		InInitializationOrderModuleList:
//			mov eax, dwPEB_LDR_DATA
//			mov esi, [eax+1Ch]
//			mov edx, [eax+20h]
//
//		LoopInInitializationOrderModuleList:
//			lodsd
//			mov esi, eax
//			mov ecx, [eax+08h]
//			cmp ecx, hModule
//			jne SkipC
//			mov ebx, [eax]
//			mov ecx, [eax+4]
//			mov [ecx], ebx
//			mov [ebx+4], ecx
//			jmp Finished
//
//		SkipC:
//			cmp edx, esi
//			jne LoopInInitializationOrderModuleList
//
//		Finished:
//			popfd;
//			popad;
//	}
//}

void Patch(DWORD dwBaseAddress, char *szData, int iSize)
{
	DWORD dwOldProtection = NULL;
	
	VirtualProtect((LPVOID)dwBaseAddress, iSize, PAGE_EXECUTE_READWRITE, &dwOldProtection);
	CopyMemory((LPVOID)dwBaseAddress, szData, iSize);
	VirtualProtect((LPVOID)dwBaseAddress, iSize, dwOldProtection, NULL);
}

//std::vector<waroffsetdata> offsetslist;
//
//int __stdcall AddNewOffset_(int address, int data, unsigned int FeatureFlag)
//{
//	for (unsigned int i = 0; i < offsetslist.size(); i++)
//	{
//		if (offsetslist[i].offaddr == address)
//		{
//			return 0;
//		}
//	}
//
//	waroffsetdata temp;
//	temp.offaddr = address;
//	temp.offdata = data;
//	temp.newdataapp = false;
//	temp.FeatureFlag = FeatureFlag;
//	offsetslist.push_back(temp);
//
//	return 1;
//}
//
//int __stdcall UpdateNewDataOffest(int address)
//{
//	for (auto & offdata : offsetslist)
//	{
//		if (offdata.offaddr == address)
//		{
//			offdata.newdataapp = true;
//			offdata.offnewdata = *(int*)address;
//			return 1;
//		}
//	}
//	return 0;
//}
//
//
//BOOL PlantDetourJMP(BYTE* source, const BYTE* destination, size_t length)
//{
//	DWORD oldProtection;
//	BOOL bRet = VirtualProtect(source, length, PAGE_EXECUTE_READWRITE, &oldProtection);
//
//	if (bRet == FALSE)
//		return FALSE;
//
//	source[0] = 0xE9;
//	*(DWORD*)(source + 1) = (DWORD)(destination - source) - 5;
//
//	for (unsigned int i = 5; i < length; i++)
//		source[i] = 0x90;
//
//	VirtualProtect(source, length, oldProtection, &oldProtection);
//	FlushInstructionCache(GetCurrentProcess(), source, length);
//	return TRUE;
//}

void SettingInitialize()
{
	if (FileExists(".\\Cirnix.ini"))
		return;
	
	SettingSet("Mana Bar", "0");
	SettingSet("Show AS & MS in Number", "0");
	//SettingSet("Show HP & MP Regen", "0");
}

void SettingSet(char *szKey, char *szValue)
{
	WritePrivateProfileString("Cirnix", szKey, szValue, ".\\Cirnix.ini");
}

bool SettingGet(char *szKey)
{
	return GetPrivateProfileInt("Cirnix", szKey, 0, ".\\Cirnix.ini") == 1;
}

bool FileExists(char *szFile)
{
  FILE *pFile;
  fopen_s(&pFile, szFile, "r");

  if (pFile != NULL)
  {
	  fclose(pFile);
	  return true;
  }

  return false;
}