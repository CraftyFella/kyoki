using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Common.Logging;

namespace ProcessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ProcessManagerService>(s =>
                {
                    s.ConstructUsing(() => new ProcessManagerService());
                    s.WhenStarted(_ => _.Start());
                    s.WhenStopped(_ => _.Stop());
                });

                x.SetDescription("Payments");
                x.SetDisplayName("Payments");
                x.SetServiceName("Payments");
                x.UseCommonLogging();
            });
        }
    }
}
