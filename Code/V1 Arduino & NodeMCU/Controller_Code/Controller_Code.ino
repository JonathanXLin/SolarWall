#include <SoftwareSerial.h>
#include <stdio.h>

SoftwareSerial esp_serial(10, 11);  //RX, TX

void setup() 
{
  pinMode(A0, INPUT);
  pinMode(A1, INPUT);
  pinMode(A2, INPUT);
  pinMode(A3, INPUT);
  pinMode(A4, INPUT);
  pinMode(A5, INPUT);
  pinMode(A6, INPUT);

  Serial.begin(9600);
  esp_serial.begin(9600);
}

//Cell voltages right shifted by 3 and rounded up
int cell_voltage[5] = {};
//Data string with cell voltages to be sent
char uart_data[22] = "";
//Index of data string, used during conversion
int data_index = 0;

void loop() 
{
  data_index = 0;
  
  update_data();
  send_data();

  delay(100);
}

void update_data()
{
  cell_voltage[0] = (int)(analogRead(A1)/1024.0*5.05*1000);
  cell_voltage[1] = (int)(analogRead(A2)/1024.0*5.05*1000); 
  cell_voltage[2] = (int)(analogRead(A3)/1024.0*5.05*1000); 
  cell_voltage[3] = (int)(analogRead(A4)/1024.0*5.05*1000); 
  cell_voltage[4] = (int)(analogRead(A5)/1024.0*5.05*1000); 

  for (int cell_num=0; cell_num<5; cell_num++)
  {
    for (int int_digit=0; int_digit<4; int_digit++)
    {
      //Data string updated at appropriate indices for given cell
      
      uart_data[(data_index + 3)-int_digit] = cell_voltage[cell_num]%10;
      cell_voltage[cell_num] /= 10;
    }
    data_index += 4;
  }

  /*
  Serial.print(cell_voltage[0]);
  Serial.print(" ");
  Serial.print(cell_voltage[1]);
  Serial.print(" ");
  Serial.print(cell_voltage[2]);
  Serial.print(" ");
  Serial.print(cell_voltage[3]);
  Serial.print(" ");
  Serial.print(cell_voltage[4]);
  Serial.println();
  */
}

void send_data()
{
  esp_serial.write('<');
  esp_serial.write(uart_data, 20); 
  esp_serial.write('>');
}

void print_serial_monitor()
{
  for (int i=0; i<20; i++)
  {
    Serial.print((int)uart_data[i]);
  }
  Serial.println();
}
