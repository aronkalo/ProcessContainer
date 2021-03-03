#pragma once
#include <Windows.h>
#include <stdio.h>
#define WINHOOK_API __declspec(dllimport)
typedef void(__stdcall* CSharpCallback)(int, WPARAM, LPARAM);

extern "C"
{
	WINHOOK_API void KeyboardMessageLoop();
	WINHOOK_API void InitLogger();
	WINHOOK_API void SetCallback(CSharpCallback cb);
}
