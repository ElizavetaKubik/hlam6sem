#include <iostream>
#include <string>
#include <tchar.h>
#include <ctime>
#include <WinSock2.h>
#pragma comment(lib, "WS2_32.lib")
#pragma warning(disable: 4996)

using namespace std;

struct SYNC
{
	SYNC() {}

	SYNC(string command, int correction)
	{
		this->command = command;
		this->correction = correction;
	}

	string command;
	int correction;
};

string DefineError(string header, int code);

int main(int argc, char* argv[])
{
	try
	{
		cout << "Client's running" << endl;

		SOCKET clientSocket;
		WSADATA wsaData;

		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw DefineError("Startup: ", WSAGetLastError());

		if ((clientSocket = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw DefineError("Socket: ", WSAGetLastError());

		SOCKADDR_IN serverConfig;
		serverConfig.sin_family = AF_INET;
		serverConfig.sin_port = htons(2000);
		serverConfig.sin_addr.s_addr = inet_addr("127.0.0.1");

		SYSTEMTIME systemTime;
		SYNC receivedData, sentData("SYNC", 0);
		const int TC = atoi(argv[1]);

		int serverConfigLength = sizeof(serverConfig);
		int maxCorrection = INT_MIN;
		int minCorrection = INT_MAX;
		int averageCorrection = 0;
		const int MAX_ITERATION_COUNT = 10;


		int sentBytes = sendto(clientSocket, (char*)&sentData, sizeof(sentData), 0, (sockaddr*)&serverConfig, sizeof(serverConfig));
		
		if (sentBytes == SOCKET_ERROR)
			throw DefineError("Send: ", WSAGetLastError());
		
		int receivedBytes = recvfrom(clientSocket, (char*)&receivedData, sizeof(receivedData), 0, (sockaddr*)&serverConfig, &serverConfigLength);

		if (receivedBytes == SOCKET_ERROR)
			throw DefineError("Receive: ", WSAGetLastError());

		sentData.correction += receivedData.correction;


		for (int i = 0; i < MAX_ITERATION_COUNT; i++)
		{
			GetSystemTime(&systemTime);
			
			sendto(clientSocket, (char*)&sentData, sizeof(sentData), 0, (sockaddr*)&serverConfig, sizeof(serverConfig));
			recvfrom(clientSocket, (char*)&receivedData, sizeof(receivedData), 0, (sockaddr*)&serverConfig, &serverConfigLength);
			
			if (maxCorrection < receivedData.correction)
				maxCorrection = receivedData.correction;

			if (minCorrection > receivedData.correction)
				minCorrection = receivedData.correction;

			cout << " DataTime " << systemTime.wMonth 
				<< "." << systemTime.wDay 
				<< ".2021" << endl << " Hours " 
				<< systemTime.wHour + 3 
				<< ":" << systemTime.wMinute 
				<< ":" << systemTime.wSecond 
				<< ":" << systemTime.wMilliseconds << " " << endl 
				<< i + 1 << " " << sentData.correction 
				<< " curvalue = " << receivedData.correction
				<< " max correction / min correction: " 
				<< maxCorrection << "/" << minCorrection << endl << endl << endl;

			sentData.correction += receivedData.correction + TC;
			averageCorrection += receivedData.correction;

			Sleep(TC);
		}

		cout << "Average correction: " << averageCorrection / MAX_ITERATION_COUNT << endl;

		if (closesocket(clientSocket) == SOCKET_ERROR)
			throw DefineError("Closesocket: ", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw DefineError("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMessage)
	{
		cout << endl << errorMessage << endl;
	}
}

string DefineError(string header, int code)
{
	return header;
}