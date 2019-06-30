#include <wiringPi.h>
#include <iostream>
#include <libirimager/direct_binding.h>
#include <libirimager/IRDeviceParams.h>
#include <libirimager/IRDevice.h>
#include <libirimager/SimpleXML.h>
#include <libirimager/IRLogger.h>


using namespace std;
using namespace evo;
int main(void)
{
	IRLogger::setVerbosity(IRLOG_ERROR, IRLOG_OFF);
	IRDeviceParams params;
	IRDeviceParamsReader::readXML("14010049.xml", params);
	IRDevice* dev = NULL;
	dev = IRDevice::IRCreateDevice(params);
	if (dev)
	{
		cout << "Dziala";
	}
	getchar();
	//evo_irimager_daemon_launch();

	cout << "elo";
	//evo_irimager_usb_init()

	return 0;
}