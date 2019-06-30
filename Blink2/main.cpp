#include <wiringPi.h>

// Pin diody LED � pin 0 w bibliotece wiringPi to BCM_GPIO 17.
// wykonuj�c inicjowanie za pomoc� funkcji wiringPiSetupSys, musimy u�ywa� numeracji BCM
// wybieraj�c inny numer pinu, u�ywaj numeracji BCM, a tak�e
// zaktualizuj polecenie Strony w�a�ciwo�ci - Zdarzenia kompilacji - Zdalne zdarzenie pokompilacyjne
// u�ywaj�ce eksportu na potrzeby konfiguracji dla funkcji wiringPiSetupSys
#define	LED	17

int main(void)
{
	wiringPiSetupSys();

	pinMode(LED, OUTPUT);

	while (true)
	{
		digitalWrite(LED, HIGH);  //W��czone
		delay(500); // ms
		digitalWrite(LED, LOW);	  //Wy��czone
		delay(500);
	}
	return 0;
}