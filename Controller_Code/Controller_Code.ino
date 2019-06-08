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
}

String data = "";

void loop() 
{
  data += "B1 ";
  data += analogRead(A1);
  data += " B2 ";
  data += analogRead(A2); 
  data += " B3 ";
  data += analogRead(A3); 
  data += " B4 ";
  data += analogRead(A4); 
  data += " B5 ";
  data += analogRead(A5); 
  
  Serial.println(data);

  data = "";
  
  /*
  Serial.print("B1: ");
  Serial.print(analogRead(A1));
  Serial.print("\t\tB2: ");
  Serial.print(analogRead(A2));
  Serial.print("\t\tB3: ");
  Serial.print(analogRead(A3));
  Serial.print("\t\tB4: ");
  Serial.print(analogRead(A4));
  Serial.print("\t\tB+: ");
  Serial.print(analogRead(A5));
  Serial.println();
  */

  delay(100);
}
