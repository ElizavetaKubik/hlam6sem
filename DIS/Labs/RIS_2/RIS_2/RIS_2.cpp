#define _WINSOCK_DEPRECATED_NO_WARNINGS
#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include <iostream>
#include <string>
#include <tchar.h>
#include <ctime>
#include <fstream>
#include "Winsock2.h" // заголовок WS2_32.dll
#pragma comment(lib, "WS2_32.lib") // экспорт WS2_32.dll
using namespace std;

struct ClientInfo
{
	char ipAddress[15];
	char fileName[20];
	int clientID;
	enum Status
	{
		NOINIT,
		INIT,
		ENTER,
		LEAVE,
		WAIT
	} status;
};

ClientInfo InitClientInfo(
	char ipaddr[15],
	char resurce[20],
	int number
);
bool EnterClientInfo(
	ClientInfo& ca
);
bool LeaveClientInfo(
	ClientInfo& ca
);
bool CloseClientInfo(
	ClientInfo& ca
);

void WriteTenString(ClientInfo& s);
void ReadTenString(ClientInfo& s, int f);

string GetErrorMsgText(int code) // cформировать текст ошибки
{
	string msgText;
	switch (code) // проверка кода возврата
	{
	case WSAEINTR: msgText = "WSAEINTR"; break;
	case WSAEACCES: msgText = "WSAEACCES"; break;
	case WSAEFAULT: msgText = "WSAEFAULT"; break;
	case WSAEINVAL: msgText = "WSAEINVAL"; break;
	case WSAEMFILE: msgText = "WSAEMFILE"; break;
	case WSAEWOULDBLOCK: msgText = "WSAEWOULDBLOCK"; break;
	case WSAEINPROGRESS: msgText = "WSAEINPROGRESS"; break;
	case WSAEALREADY: msgText = "WSAEALREADY"; break;
	case WSAENOTSOCK: msgText = "WSAENOTSOCK"; break;
	case WSAEDESTADDRREQ: msgText = "WSAEDESTADDRREQ"; break;
	case WSAEMSGSIZE: msgText = "WSAEMSGSIZE"; break;
	case WSAEPROTOTYPE: msgText = "WSAEPROTOTYPE"; break;
	case WSAENOPROTOOPT: msgText = "WSAENOPROTOOPT"; break;
	case WSAEPROTONOSUPPORT: msgText = "WSAEPROTONOSUPPORT"; break;
	case WSAESOCKTNOSUPPORT: msgText = "WSAESOCKTNOSUPPORT"; break;
	case WSAEOPNOTSUPP: msgText = "WSAEOPNOTSUPP"; break;
	case WSAEPFNOSUPPORT: msgText = "WSAEPFNOSUPPORT"; break;
	case WSAEAFNOSUPPORT: msgText = "WSAEAFNOSUPPORT"; break;
	case WSAEADDRINUSE: msgText = "WSAEADDRINUSE"; break;
	case WSAEADDRNOTAVAIL: msgText = "WSAEADDRNOTAVAIL"; break;
	case WSAENETDOWN: msgText = "WSAENETDOWN"; break;
	case WSAENETUNREACH: msgText = "WSAENETUNREACH"; break;
	case WSAENETRESET: msgText = "WSAENETRESET"; break;
	case WSAECONNABORTED: msgText = "WSAECONNABORTED"; break;
	case WSAECONNRESET: msgText = "WSAECONNRESET"; break;
	case WSAENOBUFS: msgText = "WSAENOBUFS"; break;
	case WSAEISCONN: msgText = "WSAEISCONN"; break;
	case WSAENOTCONN: msgText = "WSAENOTCONN"; break;
	case WSAESHUTDOWN: msgText = "WSAESHUTDOWN"; break;
	case WSAETIMEDOUT: msgText = "WSAETIMEDOUT"; break;
	case WSAECONNREFUSED: msgText = "WSAECONNREFUSED"; break;
	case WSAEHOSTDOWN: msgText = "WSAEHOSTDOWN"; break;
	case WSAEHOSTUNREACH: msgText = "WSAEHOSTUNREACH"; break;
	case WSAEPROCLIM: msgText = "WSAEPROCLIM"; break;
	case WSASYSNOTREADY: msgText = "WSASYSNOTREADY"; break;
	case WSAVERNOTSUPPORTED: msgText = "WSAVERNOTSUPPORTED"; break;
	case WSANOTINITIALISED: msgText = "WSANOTINITIALISED"; break;
	case WSAEDISCON: msgText = "WSAEDISCON"; break;
	case WSATYPE_NOT_FOUND: msgText = "WSATYPE_NOT_FOUND"; break;
	case WSAHOST_NOT_FOUND: msgText = "WSAHOST_NOT_FOUND"; break;
	case WSATRY_AGAIN: msgText = "WSATRY_AGAIN"; break;
	case WSANO_RECOVERY: msgText = "WSANO_RECOVERY"; break;
	case WSANO_DATA: msgText = "WSANO_DATA"; break;
	case WSA_INVALID_HANDLE: msgText = "WSA_INVALID_HANDLE"; break;
	case WSA_INVALID_PARAMETER: msgText = "WSA_INVALID_PARAMETER"; break;
	case WSA_IO_INCOMPLETE: msgText = "WSA_IO_INCOMPLETE"; break;
	case WSA_IO_PENDING: msgText = "WSA_IO_PENDING"; break;
	case WSA_NOT_ENOUGH_MEMORY: msgText = "WSA_NOT_ENOUGH_MEMORY"; break;
	case WSA_OPERATION_ABORTED: msgText = "WSA_OPERATION_ABORTED"; break;
		//..........коды WSAGetLastError ..........................
	case WSASYSCALLFAILURE: msgText = "WSASYSCALLFAILURE"; break;
	default: msgText = "***ERROR***"; break;
	};
	return msgText;
};
string SetErrorMsgText(string msgText, int code)
{
	return msgText + GetErrorMsgText(code);
};
int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "Russian");
	ClientInfo s;
	try
	{
		int str = 0;
		int i = 0;
		s = InitClientInfo((char*)"127.0.0.1", (char*)"hello.txt", _wtoi(argv[1]));
		while (true)
		{
			cout << "Введите число" << endl;
			cout << "1 - Считать 10 строк\n";
			cout << "2 - Ввести 10 строк\n";
			cin >> i;
			EnterClientInfo(s);
			cout << "Критическая секция занята\n";
			if (i == 1)
			{
				ReadTenString(s, str);
				str += 10;
			}
			else if (i == 2)
			{
				WriteTenString(s);
			}
			else
			{
				cout << "Введите правильное число" << endl;
			}
			LeaveClientInfo(s);
		}
		CloseClientInfo(s);
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
		CloseClientInfo(s);
	}
	system("pause");
	return 0;
}
ClientInfo InitClientInfo(char ipaddr[15], char resurce[20], int number)
{
	ClientInfo result;
	strcpy(result.ipAddress, ipaddr);
	strcpy(result.fileName, resurce);
	result.clientID = number;
	result.status = result.INIT;
	SOCKET cC;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		SOCKADDR_IN serv; // параметры сокета сервера
		serv.sin_family = AF_INET; // используется IP-адресация
		serv.sin_port = htons(2000); // TCP-порт 2000
		serv.sin_addr.s_addr = inet_addr(result.ipAddress); // адрес сервера
		int lobuf = 0; //количество отправленных
		int libuf = 0;
		SOCKADDR_IN clnt; // параметры сокета клиента
		memset(&clnt, 0, sizeof(clnt)); // обнулить память
		int lc = sizeof(clnt);
		if ((lobuf = sendto(cC, (char*)&result, sizeof(result), NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) {
			throw SetErrorMsgText("send:", WSAGetLastError());
		}
		if ((libuf = recvfrom(cC, (char*)&result, sizeof(result), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR) {
			throw SetErrorMsgText("recvfrom:", WSAGetLastError());
		}
		if (closesocket(cC) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
		return result;
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
		return result;
	}
}
bool EnterClientInfo(ClientInfo& ca)
{
	SOCKET cC;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		SOCKADDR_IN serv; // параметры сокета сервера
		serv.sin_family = AF_INET; // используется IP-адресация
		serv.sin_port = htons(2000); // TCP-порт 2000
		serv.sin_addr.s_addr = inet_addr(ca.ipAddress); // адрес сервера
		int lobuf = 0; //количество отправленных
		int libuf = 0;
		SOCKADDR_IN clnt; // параметры сокета клиента
		memset(&clnt, 0, sizeof(clnt)); // обнулить память
		int lc = sizeof(clnt);
		int obuf = ca.ENTER;
		ClientInfo ibuf;
		while (ca.status != ca.ENTER)
		{
			ca.status = ca.ENTER;
			if ((lobuf = sendto(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) {
				throw SetErrorMsgText("send:", WSAGetLastError());
			}
			if ((libuf = recvfrom(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR) {
				throw SetErrorMsgText("recvfrom:", WSAGetLastError());
			}
			Sleep(2000);
		}
		if (closesocket(cC) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
		return true;
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
		return false;
	}
}
bool LeaveClientInfo(ClientInfo& ca)
{
	SOCKET cC;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		SOCKADDR_IN serv; // параметры сокета сервера
		serv.sin_family = AF_INET; // используется IP-адресация
		serv.sin_port = htons(2000); // TCP-порт 2000
		serv.sin_addr.s_addr = inet_addr(ca.ipAddress); // адрес сервера
		int lobuf = 0; //количество отправленных
		int libuf = 0;
		SOCKADDR_IN clnt; // параметры сокета клиента
		memset(&clnt, 0, sizeof(clnt)); // обнулить память
		int lc = sizeof(clnt);
		int obuf = ca.LEAVE;
		ClientInfo ibuf;
		while (ca.status != ca.LEAVE)
		{
			ca.status = ca.LEAVE;
			if ((lobuf = sendto(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) 
			{
				throw SetErrorMsgText("send:", WSAGetLastError());
			}
			if ((libuf = recvfrom(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR) 
			{
				throw SetErrorMsgText("recvfrom:", WSAGetLastError());
			}
			Sleep(2000);
		}
		if (closesocket(cC) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
		return true;

	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
		return false;
	}
}
bool CloseClientInfo(ClientInfo& ca)
{
	SOCKET cC;
	WSADATA wsaData;
	try
	{
		if (WSAStartup(MAKEWORD(2, 0), &wsaData) != 0)
			throw SetErrorMsgText("Startup:", WSAGetLastError());
		if ((cC = socket(AF_INET, SOCK_DGRAM, NULL)) == INVALID_SOCKET)
			throw SetErrorMsgText("socket:", WSAGetLastError());
		SOCKADDR_IN serv; // параметры сокета сервера
		serv.sin_family = AF_INET; // используется IP-адресация
		serv.sin_port = htons(2000); // TCP-порт 2000
		serv.sin_addr.s_addr = inet_addr(ca.ipAddress); // адрес сервера
		int lobuf = 0; //количество отправленных
		int libuf = 0;
		SOCKADDR_IN clnt; // параметры сокета клиента
		memset(&clnt, 0, sizeof(clnt)); // обнулить память
		int lc = sizeof(clnt);
		ClientInfo ibuf;
		ca.status = ca.NOINIT;
		if ((lobuf = sendto(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&serv, sizeof(serv))) == SOCKET_ERROR) {
			throw SetErrorMsgText("send:", WSAGetLastError());
		}
		if ((libuf = recvfrom(cC, (char*)&ca, sizeof(ca), NULL, (sockaddr*)&clnt, &lc)) == SOCKET_ERROR) {
			throw SetErrorMsgText("recvfrom:", WSAGetLastError());
		}
		if (closesocket(cC) == SOCKET_ERROR)
			throw SetErrorMsgText("closesocket:", WSAGetLastError());
		if (WSACleanup() == SOCKET_ERROR)
			throw SetErrorMsgText("Cleanup:", WSAGetLastError());
		return true;
	}
	catch (string errorMsgText)
	{
		cout << endl << errorMsgText;
		return false;
	}
	catch (const std::exception&)
	{
		return false;
	}

}
void WriteTenString(ClientInfo& s)
{
	std::ofstream ss(s.fileName, std::ios::app);
	for (int i = 0; i < 10; i++)
	{
		time_t rawtime;
		struct tm * timeinfo;
		time(&rawtime);
		timeinfo = localtime(&rawtime);
		if (ss.is_open())
		{
			ss << "Client: " << s.clientID << " " << asctime(timeinfo);
			cout << "Client: " << s.clientID << " " << asctime(timeinfo);
		}
		Sleep(1000);
	}
	ss.close();
}
void ReadTenString(ClientInfo& s, int f)
{
	std::ifstream file;
	file.open(s.fileName);
	int i = 0;
	while (file) 
	{
		std::string str;
		i++;
		if (f < i && i <= (f + 10))
		{
			std::getline(file, str);
			cout << str << std::endl;
			Sleep(1000);
		}
	}
	cout << "Reading completed\n";
	file.close();
}
