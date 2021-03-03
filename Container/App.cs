using Container.Input.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    public class App
    {
        public async Task RunAsync(System.Threading.CancellationToken _cancellationToken)
        {
            using WindowsGlobalHook wGlobalHook = new WindowsGlobalHook();

        }
    }
}
