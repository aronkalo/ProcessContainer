using Container.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    public class App
    {
        public async Task RunAsync()
        {
            await Task.Run(async () => 
            {
                using InputListener lis = new InputListener();
                await Task.Delay(100000);
            });
        }
    }
}
