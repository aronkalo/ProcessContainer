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
