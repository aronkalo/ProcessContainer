#include "pch.h"
#include "win32hookapi.h"
#include "Windows.h"
#include <iostream>
#include <future>
HHOOK hKeyboardHook;
CSharpCallback csharpCallback;
LRESULT CALLBACK keyboardCallback(int nCode, WPARAM wParam, LPARAM lParam)
{
    csharpCallback(nCode, wParam, lParam);
    return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
}


void InitLogger() {
    std::thread(KeyboardMessageLoop).detach();
}

void SetCallback(CSharpCallback cb)
{
    csharpCallback = cb;
}

void KeyboardMessageLoop() {
    HINSTANCE hInstance = GetModuleHandle(NULL);
    hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, keyboardCallback, hInstance, NULL);
    MSG message;
    while (GetMessage(&message, NULL, 0, 0)) {
        TranslateMessage(&message);
        DispatchMessage(&message);
    }
    UnhookWindowsHookEx(hKeyboardHook);
}