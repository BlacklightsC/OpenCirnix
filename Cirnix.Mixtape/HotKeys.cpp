#include "HotKeys.h"

void WINAPI HotKeys()
{
	bool bIsShown = false;

	while (true)
	{
		if (IsInGame() && !bIsShown)
		{
			TextPrint("|CFFFCD211Cirnix�� ���������� ����Ǿ����ϴ�.", 30.0f);

			bIsShown = true;
		}
		else if (!IsInGame() && bIsShown)
			bIsShown = false;
	}
}
