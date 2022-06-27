#include <iostream>
#include <string>
#include <tchar.h>
#include <WinSock2.h>
#include <ctime>
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

int GetAverageCorrection(int averageCorrection[], int length);

string DefineError(string header, int code);


int _tmain(int argc, _TCHAR* argv[])
{
	try
	{
		cout << "Server's running" << endl;

		SOCKET serverSocket;
		WSADATA wsaData;

		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw DefineError("Startup: ", WSAGetLastError());

		if ((serverSocket = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw DefineError("Socket: ", WSAGetLastError());

		SOCKADDR_IN serverConfig;
		serverConfig.sin_family = AF_INET;
		serverConfig.sin_port = htons(2000);
		serverConfig.sin_addr.s_addr = INADDR_ANY;

		if (bind(serverSocket, (LPSOCKADDR)&serverConfig, sizeof(serverConfig)) == SOCKET_ERROR)
			throw DefineError("Bind Server: ", WSAGetLastError());

		SYNC receivedData, sentData("SYNC", 0);
		SYSTEMTIME systemTime;
		int averageResults[10];
		clock_t delta;
		int i = 1;
		const int MAX_ITERATION_COUNT = 10;

		for (int i = 0; i != MAX_ITERATION_COUNT; i++)
		{
			SOCKADDR_IN clientConfig;
			int clientConfigLength = sizeof(clientConfig);
			int average = 0;

			GetSystemTime(&systemTime);

			int recvBytes = recvfrom(serverSocket, (char*)&receivedData, sizeof(receivedData), NULL, (sockaddr*)&clientConfig, &clientConfigLength);

			if (recvBytes == SOCKET_ERROR)
				throw DefineError("Receive: ", WSAGetLastError());

			delta = clock();

			int correctionDelta = delta - receivedData.correction;
			sentData.correction = correctionDelta;
			averageResults[i] = correctionDelta;

			average = GetAverageCorrection(averageResults, i + 1);

			int sentBytes = sendto(serverSocket, (char*)&sentData, sizeof(sentData), 0, (sockaddr*)&clientConfig, sizeof(clientConfig));

			if (sentBytes == SOCKET_ERROR)
				throw DefineError("Send: ", WSAGetLastError());

			cout << "DataTime "
				<< systemTime.wMonth << "."
				<< systemTime.wDay << ".2021" << " " << endl
				<< systemTime.wHour + 3 << " Hours "
				<< systemTime.wMinute << " Minuts "
				<< systemTime.wSecond << " Seconds "
				<< systemTime.wMilliseconds << " MiliSeconds " << endl
				<< inet_ntoa(clientConfig.sin_addr) << " Correction = "
				<< sentData.correction << ", Average Correction = "
				<< average << endl << endl << endl;
		}

		if (closesocket(serverSocket) == SOCKET_ERROR)
			throw DefineError("close socket: ", WSAGetLastError());

		if (WSACleanup() == SOCKET_ERROR)
			throw DefineError("Cleanup: ", WSAGetLastError());
	}
	catch (string errorMessage)
	{
		cout << endl << errorMessage << endl;
	}

	system("pause");
}


int GetAverageCorrection(int averageCorrection[], int length)
{
	int value = 0;
	for (int i = 0; i < length; i++)
	{
		value += averageCorrection[i];
	}
	return value / length;
}

string DefineError(string header, int code)
{
	return header;
}
