#include "HotKeys.h"

void WINAPI HotKeys()
{
	bool bIsShown = false;

	while (true)
	{
		if (IsInGame() && !bIsShown)
		{
			TextPrint("|CFFFCD211Cirnix가 정상적으로 실행되었습니다.", 30.0f);

			bIsShown = true;
		}
		else if (!IsInGame() && bIsShown)
			bIsShown = false;
	}
}
