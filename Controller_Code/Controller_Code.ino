#include <avr/io.h>
#include <avr/interrupt.h>

#define PANEL_SHUTOFF     5
#define PACK_SHUTOFF      6

void setup() 
{
  // Set the Timer Mode to CTC
  TCCR0A |= (1 << WGM01);

  // Set the value that you want to count to
  OCR0A = 0xF9;

  TIMSK0 |= (1 << OCIE0A);    //Set the ISR COMPA vect

  sei();         //enable interrupts

  TCCR0B |= (1 << CS02);
  // set prescaler to 256 and start the timer
  
  Serial.begin(9600);
}

void loop() 
{
  //Serial.println("Normal");
}

ISR (TIMER0_COMPA_vect)  // timer0 overflow interrupt
{
  Serial.println("Interrupt");
}
