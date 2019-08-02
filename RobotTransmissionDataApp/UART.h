#pragma once

#ifndef UART_H
#define UART_H
class UART {
public:
	UART();
	void sendSerial(int dane);
	int readSerialSingle();
	void readSerialAll();
	double odczyt_ramki_uart();

private:
	int fd;

};

#endif