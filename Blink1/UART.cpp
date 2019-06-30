#include "UART.h"
#include <wiringPi.h>
#include <stdio.h>
#include <string.h>
#include <errno.h>
#include <iostream>
#include <stdlib.h>
#include <fcntl.h>

#include <netinet/tcp.h>



#include <string.h>
#include <unistd.h>
#include <cstdlib>

#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <netdb.h>
#include <string.h>
#include <fstream>

#include <pthread.h>
#include <sys/time.h>
#include <fstream>
#include <vector>
#include <list>
#include <signal.h>
#include <ctime>
#include <chrono>
#include <unistd.h>

#include <wiringSerial.h>

UART::UART()
{
	std::cout << "Jestem w konstruktorze!!!!!!!\n";
	///////////////////////// INICJALIZACJA PORTU UART //////////////////////////////////////
	if ((this->fd = serialOpen("/dev/ttyAMA0", 9600)) < 0)
	{
		fprintf(stderr, "Unable to open serial device: %s\n", strerror(errno));
		//return 1;
	}

	if (wiringPiSetup() == -1)
	{
		fprintf(stdout, "Unable to start wiringPi: %s\n", strerror(errno));
		// return 1;
	}

}

void UART::sendSerial(int dane)	// WYSLANIE POJEDYNCZEGO ZNAKU UART
{
	unsigned char c;
	c = dane;
	
	std::cout << "\nDane :";
	std::cout << dane;
	std::cout << "\n";
	std::cout << "Dane unsigned char :";
	std::cout << c << "\n" << "\n";

	//      printf ("Out: %3d\n", dane) ;
	//      fflush (stdout) ;
	serialPutchar(fd, dane);
}


int UART::readSerialSingle()		// ODCZYT POJEDYNCZEGO ZNAKU UART
{
	for (int i = 0; i < 1;)
	{
		int Data = serialGetchar(fd);
		//		printf ("Read: %3d\n", Data);
		//		fflush(stdout);
		i = 1;
		return Data;
	}
}

void UART::readSerialAll()		// ODCZYT WSZYSTKICH DANYCH Z UART
{
	
	while (serialDataAvail(fd))
	{
		printf("Read: %3d\n", serialGetchar(fd));
		fflush(stdout);
	}
}



double UART::odczyt_ramki_uart()		// ODCZYT CALEJ RAMKU UART Z ZLOZENIEM DZIESIETNYM
{
	//////////////////////////////// ODCZYT RAMKI	////////////////////////////////
	double x_d;
	int znak = readSerialSingle();
	int x0 = readSerialSingle();
	int x1 = readSerialSingle();
	int x2 = readSerialSingle();
	int x3 = readSerialSingle();
	int zn_double = readSerialSingle();	// ZAREZERWOWANY BIT NA PRZYSZLE ZMIANY
	int x_1 = readSerialSingle();
	int x_2 = readSerialSingle();
	////////////////////////////////////// ZLOZENIE LICZBY DZIESIETNEJ ///////////////////////
	if (zn_double = 11)
	{
		if (znak == 1) { x_d = (x3)+(x2 * 10) + (x1 * 100) + (x0 * 1000) + (x_1 / 10.0) + (x_2 / 100.0); }
		else { x_d = -((x3)+(x2 * 10) + (x1 * 100) + (x0 * 1000) + (x_1 / 10.0) + (x_2 / 100.0)); }
	}
	// 	else{
	//		if (znak == 1){x_d = (x3)+(x2*10)+(x1*100)+(x0*1000);}
	//        	else{x_d=- ((x3) + (x2*10) + (x1*100)+(x0*1000)) ; }
	//	 }
	return x_d;	// ZWROCENIE LICZBY DZIESIETNEJ
}