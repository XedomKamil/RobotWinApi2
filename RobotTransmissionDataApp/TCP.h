#pragma once
#ifndef TCP_H
#define TCP_H
class TCP 
{

public:
	TCP();
	int getData(int sockfd);
	void TCP::error(char *msg);
	void sendData(int sockfd, int x);
	int sendData2(int sockfd, int x);
};

#endif