#include "TCP.h"
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

TCP::TCP()
{

}

void TCP::error(char *msg) {
	perror(msg);
	//	exit(1);
}



int TCP::getData(int sockfd)		// ODCZYT DANYCH TCP
{
	char buffer[10];
	int n;
	try {

		if ((n = read(sockfd, buffer, strlen(buffer))) < 0)
			error(const_cast<char *>("ERROR reading from socket"));
	}
	catch (const std::exception&) {
		std::cout << "blAD ODCZYTU";
	}

	buffer[n] = '\0';
	return atoi(buffer);
}


void TCP::sendData(int sockfd, int x)	// WYSLANIE DANYCH TCP
{
	int n;
	char buffer[32];
	sprintf(buffer, "%d\n", x);

	if ((n = write(sockfd, buffer, strlen(buffer))) < 0)
		error(const_cast<char *>("ERROR writing to socket"));

	buffer[n] = '\0';
}


int TCP::sendData2(int sockfd, int x)	// WYSLANIE DANYCH TCP
{
	int n;
	char buffer[32];
	sprintf(buffer, "%d\n", x);

	if ((n = write(sockfd, buffer, strlen(buffer))) < 0)
		error(const_cast<char *>("ERROR writing to socket"));

	buffer[n] = '\0';
	return n;
}

