#include <Wire.h>

// Cell voltage variables
double cell_voltage[5] = {1.234, 2.345, 3.456, 4.567, 5.678};

void setup() {
  Wire.begin(1);                /* join i2c bus with address 1 */
  Wire.onReceive(receiveEvent); /* register receive event */
  Wire.onRequest(requestEvent); /* register request event */
  Serial.begin(9600);           /* start serial for debug */

  //Flash LED on initialization
  pinMode(13, OUTPUT);
  digitalWrite(13, HIGH);
  delay(1000);
  digitalWrite(13, LOW);
}

void loop() {
  delay(100);
}

// function that executes whenever data is received from master
void receiveEvent(int howMany) {
  while (0 <Wire.available()) {
    char c = Wire.read();      /* receive byte as a character */
    Serial.print(c);           /* print the character */
  }
  Serial.println();             /* to newline */
}

// function that executes whenever data is requested from master
void requestEvent() {

  //Message to send
  byte data_array[10] = {0};
  int data_array_index = 0;

  //Load cell voltages
  for (int i=0; i<5; i++)
  {
    data_array[data_array_index] = int(cell_voltage[i] * 10);
    data_array_index++;
    data_array[data_array_index] = int(cell_voltage[i] * 1000) - (int(cell_voltage[i] * 10)*100);
    data_array_index++;
  }

  Wire.write(data_array, 10);  /*send string on request */
}