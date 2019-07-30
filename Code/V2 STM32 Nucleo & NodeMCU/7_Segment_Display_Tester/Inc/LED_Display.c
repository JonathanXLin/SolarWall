#include "LED_Display.h"

/*
uint8_t LED_Display_Digits(LED_Display_Pins pins, uint32_t value, uint32_t decimal)
{
	uint8_t digit[4];
	
	for (int digitNum = 0; digitNum < 4; digitNum++)
	{
		digit[digitNum] = value%10;
		value /= 10;
	}
	
	for (int digitNum = 0; digitNum < 4; digitNum++)
	{
		switch (digit[digitNum])
		{

		}
	}
}
*/

void LED_Display_Clear(LED_Display_Pins pins);