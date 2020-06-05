#pragma once
#include "Functions.h"

//struct waroffsetdata
//{
//	int offaddr;
//	int offdata;
//	bool newdataapp;
//	int offnewdata;
//	unsigned int FeatureFlag;
//};

//void HideDll(HMODULE hModule);

void Patch(DWORD dwBaseAddress, char *szData, int iSize);
//int __stdcall AddNewOffset_(int address, int data, unsigned int FeatureFlag = 0);
//int __stdcall UpdateNewDataOffest(int address);
//BOOL PlantDetourJMP(BYTE* source, const BYTE* destination, size_t length);

void SettingInitialize();
void SettingSet(char *szKey, char *szValue);
bool SettingGet(char *szKey);
bool FileExists(char *szFile);