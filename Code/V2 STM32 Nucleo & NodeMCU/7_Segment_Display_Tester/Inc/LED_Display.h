#ifndef LED_DISPLAY_H_
#define LED_DISPLAY_H_

#include <stdint.h>
#include "stm32f4xx_hal.h"

//	LED segment definitions
#define LED_top_top				0
#define LED_top_left			1
#define LED_top_right			2
#define LED_middle				3
#define LED_bottom_left		4
#define LED_bottom_right	5
#define LED_bottom_bottom	6
#define LED_decimal				7

/* GPIO Pin identifier */
typedef struct
{
  GPIO_TypeDef *port;
  uint16_t      pin;
} GPIO_PIN;

//	Single digit's GPIO pins
typedef struct 
{
	GPIO_PIN segment[8];
}LED_Digit_Pins;

//	4 digit display's GPIO pins
typedef struct
{
	LED_Digit_Pins digit[4];
}LED_Display_Pins;

//Display 4 digit value
uint8_t LED_Display_Digits(LED_Display_Pins pins, uint32_t value, uint32_t decimal);

//Turn off all LEDs
void LED_Display_Clear(LED_Display_Pins pins);

#endif