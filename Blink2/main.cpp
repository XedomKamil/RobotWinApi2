#include <wiringPi.h>

// Pin diody LED — pin 0 w bibliotece wiringPi to BCM_GPIO 17.
// wykonuj¹c inicjowanie za pomoc¹ funkcji wiringPiSetupSys, musimy u¿ywaæ numeracji BCM
// wybieraj¹c inny numer pinu, u¿ywaj numeracji BCM, a tak¿e
// zaktualizuj polecenie Strony w³aœciwoœci - Zdarzenia kompilacji - Zdalne zdarzenie pokompilacyjne
// u¿ywaj¹ce eksportu na potrzeby konfiguracji dla funkcji wiringPiSetupSys
#define	LED	17

int main(void)
{
	wiringPiSetupSys();

	pinMode(LED, OUTPUT);

	while (true)
	{
		digitalWrite(LED, HIGH);  //W³¹czone
		delay(500); // ms
		digitalWrite(LED, LOW);	  //Wy³¹czone
		delay(500);
	}
	return 0;
}