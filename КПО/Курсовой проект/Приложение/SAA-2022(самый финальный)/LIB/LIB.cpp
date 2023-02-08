#include <iostream>
#include <ctime>
extern "C"
{

	
	__int16 __stdcall random()
	{
		srand(time(NULL));
		__int16 r = rand();
		return r;
	}
	__int16 __stdcall lenght(char* str)
	{
		if (str == nullptr)
			return 0;
		int len = 0;
		for (int i = 0; i < 256; i++)
			if (str[i] == '\0')
			{
				len = i;
				break;
			}
		return len;
	}
	__int16 __stdcall outnum(__int16 value)
	{
		std::cout << value;
		return 0;
	}
	int __stdcall outstr(char* ptr)
	{
		if (ptr == nullptr)
		{
			std::cout << std::endl;
			return 0;
		}
		for (int i = 0; ptr[i] != '\0'; i++)
			std::cout << ptr[i];
		return 0;
	}
	__int16 __stdcall outnumline(__int16 value)
	{
		std::cout << value << std::endl;
		return 0;
	}
	__int16 __stdcall outstrline(char* ptr)
	{
		if (ptr == nullptr)
		{
			std::cout << std::endl;
			return 0;
		}
		for (int i = 0; ptr[i] != '\0'; i++)
			std::cout << ptr[i];
		std::cout << std::endl;
		return 0;
	}
	__int16 __stdcall system_pause()
	{
		system("pause");
		return 0;
	}
}