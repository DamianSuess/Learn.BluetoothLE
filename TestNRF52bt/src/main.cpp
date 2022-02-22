#include <Arduino.h>
#include <bluefruit.h>

unsigned int _counter = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  //// Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:

  digitalToggle(LED_RED);

  _counter++;
  Serial.print("PBJ001;c=");
  Serial.println(_counter);

  delay(250);
}