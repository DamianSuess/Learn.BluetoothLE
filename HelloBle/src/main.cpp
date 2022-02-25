#include <Arduino.h>
#include <bluefruit.h>

unsigned int _counter = 0;

void setup()
{
  pinMode(LED_BUILTIN, OUTPUT);

  // put your setup code here, to run once:
  Serial.begin(9600);
  //// Serial.begin(115200);
}

void loop()
{
  // put your main code here, to run repeatedly:

  // LED_RED = LED_BUILTIN = PIN_LED1
  digitalToggle(LED_RED);

  _counter++;
  Serial.print("PBJ001;c=");
  Serial.println(_counter);

  delay(250);
}