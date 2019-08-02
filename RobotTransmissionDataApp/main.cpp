#include <wiringPi.h>

#include "TCP.h"
#include "UART.h"

TCP tcp;
UART uart;
int main(void)
{
	uart.sendSerial(22);
	return 0;
}