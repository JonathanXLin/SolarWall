# 1 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino"
# 1 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino"
/*********

  Adapted from Rui Santos

  Complete project details at http://randomnerdtutorials.com  

*********/
# 6 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino"
// Load Wi-Fi library
# 8 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino" 2
# 9 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino" 2
# 10 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino" 2

// Replace with your network credentials
const char* ssid = "ATTW6YS4I2";
const char* password = "c%qi=ijne=t+";

// Set web server port number to 80
WiFiServer server(80);

// Variable to store the HTTP request
String header;

// Auxiliary variables to store the current output state
String pack_enable_state = "off";
String panel_enable_state = "off";

// Assign output variables to GPIO pins
const int pack_enable_pin = 10;
const int panel_enable_pin = 9;

//Timer for I2C requests
Ticker timer_I2C;

// Current time
unsigned long currentTime = millis();

// Previous time
unsigned long previousTime = 0;

// Define timeout time in milliseconds (example: 2000ms = 2s)
const long timeoutTime = 2000;

void setup() {
  // Initialize serial
  Serial.begin(115200);

  // Initialize I2C
  Wire.begin(D1, D2);

  // Initialize the output variables as outputs
  pinMode(pack_enable_pin, 0x01);
  pinMode(panel_enable_pin, 0x01);

  // Set outputs to LOW
  digitalWrite(pack_enable_pin, 0x0);
  digitalWrite(panel_enable_pin, 0x0);

  // Connect to Wi-Fi network with SSID and password
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  // Initialize I2C timer
  timer_I2C.attach(1, pack_data_request);

  // Print local IP address and start web server
  Serial.println("");
  Serial.println("WiFi connected.");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  server.begin();
}

void loop(){
  WiFiClient client = server.available(); // Listen for incoming clients

  if (client) { // If a new client connects,
    Serial.println("New Client."); // print a message out in the serial port
    String currentLine = ""; // make a String to hold incoming data from the client
    currentTime = millis();
    previousTime = currentTime;
    while (client.connected() && currentTime - previousTime <= timeoutTime) { // loop while the client's connected
      currentTime = millis();
      if (client.available()) { // if there's bytes to read from the client,
        char c = client.read(); // read a byte, then
        Serial.write(c); // print it out the serial monitor
        header += c;
        if (c == '\n') { // if the byte is a newline character
          // if the current line is blank, you got two newline characters in a row.
          // that's the end of the client HTTP request, so send a response:
          if (currentLine.length() == 0) {
            // HTTP headers always start with a response code (e.g. HTTP/1.1 200 OK)
            // and a content-type so the client knows what's coming, then a blank line:
            client.println("HTTP/1.1 200 OK");
            client.println("Content-type:text/html");
            client.println("Connection: close");
            client.println();

            // turns the GPIOs on and off
            if (header.indexOf("GET /5/on") >= 0) {
              Serial.println("GPIO 5 on");
              pack_enable_state = "on";
              digitalWrite(pack_enable_pin, 0x1);
            } else if (header.indexOf("GET /5/off") >= 0) {
              Serial.println("GPIO 5 off");
              pack_enable_state = "off";
              digitalWrite(pack_enable_pin, 0x0);
            } else if (header.indexOf("GET /4/on") >= 0) {
              Serial.println("GPIO 4 on");
              panel_enable_state = "on";
              digitalWrite(panel_enable_pin, 0x1);
            } else if (header.indexOf("GET /4/off") >= 0) {
              Serial.println("GPIO 4 off");
              panel_enable_state = "off";
              digitalWrite(panel_enable_pin, 0x0);
            }

            // Display the HTML web page
            client.println("<!DOCTYPE html><html>");
            client.println("<head><meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">");
            client.println("<link rel=\"icon\" href=\"data:,\">");
            // CSS to style the on/off buttons 
            // Feel free to change the background-color and font-size attributes to fit your preferences
            client.println("<style>html { font-family: Helvetica; display: inline-block; margin: 0px auto; text-align: center;}");
            client.println(".button { background-color: #195B6A; border: none; color: white; padding: 16px 40px;");
            client.println("text-decoration: none; font-size: 30px; margin: 2px; cursor: pointer;}");
            client.println(".button2 {background-color: #77878A;}</style></head>");

            // Web Page Heading
            client.println("<body><h1>SolarWall P2</h1>");

            // Display pack enable state, and ON/OFF buttons for master state
            client.println("<p>Pack Enable</p>");
            // If pack enable state is off, it displays the ON button       
            if (pack_enable_state=="off") {
              client.println("<p><a href=\"/5/on\"><button class=\"button\">ON</button></a></p>");
            } else {
              client.println("<p><a href=\"/5/off\"><button class=\"button button2\">OFF</button></a></p>");
            }

            // Display panel enable state, and ON/OFF buttons for GPIO 4  
            client.println("<p>Panel Enable</p>");
            // If the panel enable is off, it displays the ON button       
            if (panel_enable_state=="off") {
              client.println("<p><a href=\"/4/on\"><button class=\"button\">ON</button></a></p>");
            } else {
              client.println("<p><a href=\"/4/off\"><button class=\"button button2\">OFF</button></a></p>");
            }

            // Display cell voltages
            /*

            client.println("<p>Cell 1: " + String(cell_1_voltage, 3) + "V </p>");

            client.println("<p>Cell 2: " + String(cell_2_voltage, 3) + "V </p>");

            client.println("<p>Cell 3: " + String(cell_3_voltage, 3) + "V </p>");

            client.println("<p>Cell 4: " + String(cell_4_voltage, 3) + "V </p>");

            client.println("<p>Cell 5: " + String(cell_5_voltage, 3) + "V </p>");

            */
# 161 "c:\\Users\\Jonathan\\Documents\\GitHub\\SolarWall\\Code\\V2 STM32 Nucleo & NodeMCU\\P1\\NodeMCU\\NodeMCU.ino"
            client.println("</body></html>");

            // The HTTP response ends with another blank line
            client.println();
            // Break out of the while loop
            break;
          } else { // if you got a newline, then clear currentLine
            currentLine = "";
          }
        } else if (c != '\r') { // if you got anything else but a carriage return character,
          currentLine += c; // add it to the end of the currentLine
        }
      }
    }
    // Clear the header variable
    header = "";
    // Close the connection
    client.stop();
    Serial.println("Client disconnected.");
    Serial.println("");
  }
}

// Requests data through I2C from Arduino
void pack_data_request()
{
  //Polls I2C data
  Wire.requestFrom(1, 10);

  byte pack_data[10] = {0};
  Wire.readBytes(pack_data, 10);

  for (int i=0; i<10; i++)
    Serial.print(pack_data[i]);
  Serial.println();

  timer_I2C.attach(1, pack_data_request);
}
