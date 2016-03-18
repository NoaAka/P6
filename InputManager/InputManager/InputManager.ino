const int analogIn0 = A0;
const int analogIn1 = A1;
const int analogIn2 = A2;
const int analogIn3 = A3;
//const int digitalIn4 = D4;
//const int digitalIn5 = D5;

int sen0Val = 0;
int sen1Val = 0;
int sen2Val = 0;
int sen3Val = 0;
int sen4Val = 0;
int sen5Val = 0;

void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.flush();
  sen0Val=analogRead(analogIn0);
  sen1Val=analogRead(analogIn1);
  sen2Val=analogRead(analogIn2);
  sen3Val=analogRead(analogIn3);
  sen4Val=digitalRead(4);
  sen5Val=digitalRead(5);

  //Serial.print("Sensor 0 = ");
  Serial.print(sen0Val);
  Serial.print(",");
  //Serial.print("Sensor 1 = ");
  Serial.print(sen1Val);
  Serial.print(",");
  //Serial.print("Sensor 2 = ");
  Serial.print(sen2Val);
  Serial.print(",");
  //Serial.print("Sensor 3 = ");
  Serial.print(sen3Val);
  Serial.print(",");
  //Serial.print("Sensor 4 = ");
  Serial.print(sen4Val);
  Serial.print(",");
  //Serial.print("Sensor 5 = ");
  Serial.print(sen5Val);
  /*
  if(sen4Val>sen5Val){
    Serial.println("Left");
  }
  if(sen5Val>sen4Val){
    Serial.println("Right");
  }
  if(sen0Val>150){
    Serial.println("Shoot");
  }
  if(sen1Val>130){
    Serial.println("Up");
  }
  */
  Serial.println();

  delay(30);
  
}
