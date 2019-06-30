#include <wiringPi.h>
#include <iostream>
#include <libirimager/direct_binding.h>
#include <libirimager/IRDeviceParams.h>
#include <libirimager/IRDevice.h>
#include <libirimager/SimpleXML.h>
#include <libirimager/IRLogger.h>
#include "libirimager/IRDaemon.h"

#include "TCP.h"
#include "UART.h"

using namespace std;
using namespace evo;

#define DIRECT_DAEMON_PORT 1337

IRDaemon* _daemon = NULL;
int main(void)
{
	//IRLogger::setVerbosity(IRLOG_ERROR, IRLOG_OFF);
	//IRDeviceParams params;
	//IRDeviceParamsReader::readXML("14010049.xml", params);
	//IRDevice* dev = NULL;
//	dev = IRDevice::IRCreateDevice(params);
	//if (dev)
//	{
//		cout << "Dziala";
//	}


	//cout << evo_irimager_usb_init("14010049.xml", 0, 0);
//	cout << evo_irimager_tcp_init("192.168.0.249", 1337);

	/*
	cout << "\nIR DAEMON: ";
	cout << evo_irimager_daemon_launch();
	cout << "\n";
	cout << "\nIR DAEMON: ";
	cout << evo_irimager_daemon_is_running();
	*/
	UART _uart;
	_uart.sendSerial(55);
	
	


	IRLogger::setVerbosity(evo::IRLOG_ERROR, evo::IRLOG_OFF, "daemon.log");

	IRDeviceParams params;
	IRDeviceParamsReader::readXMLC("14010049.xml", params);
	IRDeviceParams_Print(params);
	_daemon = new IRDaemon();

	_daemon->run(&params, DIRECT_DAEMON_PORT);
	
	_daemon->exit();
	_daemon->~IRDaemon();

	getchar();
	return 0;
}