using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Services.Input.Keyboard
{
    class WinGlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public WinGlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }
        public WinGlobalKeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

        public WinGlobalKeyboardHookEventArgs(
            WinGlobalKeyboardHook.LowLevelKeyboardInputEvent keyboardData,
            WinGlobalKeyboardHook.KeyboardState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }
    }
}
