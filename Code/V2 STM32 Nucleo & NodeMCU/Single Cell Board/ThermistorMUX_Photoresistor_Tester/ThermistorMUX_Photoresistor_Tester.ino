const int thermMuxA = 5;
const int thermMuxB = 6;
const int thermMuxC = 7;
const int thermMuxEn = 8;
const int thermMuxOut = A2;

const int photoResOut = A3;

const int ledBypass = 9;
const int ledVoltSense = 10;
const int ledActive = 11;

//60 deg C value for Vishay NTCLE100E3223 thermistor
const int thermThreshold = 805;

void setup() {
  pinMode(thermMuxA, OUTPUT);
  pinMode(thermMuxB, OUTPUT);
  pinMode(thermMuxC, OUTPUT);
  pinMode(thermMuxEn, OUTPUT);
  pinMode(thermMuxEn, INPUT);

  pinMode(photoResOut, INPUT);

  pinMode(ledBypass, OUTPUT);
  pinMode(ledVoltSense, OUTPUT);
  pinMode(ledActive, OUTPUT);

  led_flash_all(100);
  led_flash_all(100);
  digitalWrite(ledActive, HIGH);

  digitalWrite(thermMuxEn, LOW);

  Serial.begin(9600);
  Serial.println("Initialized");
}

int thermMuxVal;
int photoResVal;

void loop() {

  photoResVal = analogRead(photoResOut);
  Serial.print("Light: ");
  Serial.print(photoResVal/1023.0);
  Serial.print("\t");
  
  for (int channel=0; channel<5; channel++)
  {
    thermMuxVal = read_mux(channel, 50);
    
    Serial.print("M");
    Serial.print(channel);
    Serial.print(": ");
    Serial.print(thermMuxVal);
    if (thermMuxVal >= thermThreshold)
      Serial.print(" OVERHEAT >60C ");
    Serial.print("\t");
  }

  Serial.println();
}

//Channels from 0-4, settling time is delay after writing address to MUX
int read_mux(int channel, int settlingTime)
{
  digitalWrite(thermMuxEn, LOW);
  delay(settlingTime);
  
  digitalWrite(thermMuxA, bool(channel & (1<<0)));
  digitalWrite(thermMuxB, bool(channel & (1<<1)));
  digitalWrite(thermMuxC, bool(channel & (1<<2)));

  delay(settlingTime);

  return(analogRead(thermMuxOut));
}

void led_flash_all(int dur)
{
  digitalWrite(ledBypass, HIGH);
  delay(dur);
  digitalWrite(ledBypass, LOW);
  
  digitalWrite(ledVoltSense, HIGH);
  delay(dur);
  digitalWrite(ledVoltSense, LOW);
  
  digitalWrite(ledActive, HIGH);
  delay(dur);
  digitalWrite(ledActive, LOW);
 
  delay(dur);
}
