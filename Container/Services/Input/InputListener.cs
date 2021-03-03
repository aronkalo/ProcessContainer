using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Container.Services.Input.Keyboard;

namespace Container.Services.Input
{
    public class InputListener : IDisposable
    {
        private WinGlobalKeyboardHook _keyboardHook;
        public InputListener()
        {
            _keyboardHook = new WinGlobalKeyboardHook();
            _keyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, WinGlobalKeyboardHookEventArgs e)
        {
            Console.WriteLine(e.KeyboardData.VirtualCode);
            if (e.KeyboardData.VirtualCode != WinGlobalKeyboardHook.VkSnapshot)
                return;

            if (e.KeyboardState == WinGlobalKeyboardHook.KeyboardState.KeyDown)
            {
                e.Handled = true;
            }
        }

        public void Dispose()
        {
            _keyboardHook?.Dispose();
        }
    }
}


//class Program
//{
//    private delegate void LowLevelHookProcedure(int nCode, IntPtr wParam, IntPtr lParam);
//    private static LowLevelHookProcedure _hookProcedure;

//    static void Main(string[] args)
//    {
//        _hookProcedure += Proc;
//        SetCallback(_hookProcedure);
//        InitLogger();
//        while (true)
//        {
//            string st = Console.ReadLine();
//            Console.WriteLine(st);
//        }
//    }

//    private static void Proc(int nCode, IntPtr wParam, IntPtr lParam)
//    {
//        ;
//    }

//    [DllImport("Container.Win32.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
//    static extern void SetCallback(LowLevelHookProcedure proc);

//    [DllImport("Container.Win32.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
//    static extern void KeyboardLogger();

//    [DllImport("Container.Win32.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
//    static extern void InitLogger();

//    [DllImport("user32.dll", CharSet = CharSet.Auto,
//        CallingConvention = CallingConvention.StdCall, SetLastError = true)]
//    static extern IntPtr SetWindowsHookEx(int idHook, LowLevelHookProcedure lpfn, IntPtr hMod, int dwThreadId);

//    // Retrieves a module handle for the specified module.
//    // The module must have been loaded by the calling process.
//    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
//    private static extern IntPtr GetModuleHandle(string lpModuleName);
//}
