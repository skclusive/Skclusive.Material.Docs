using WebWindows.Blazor;
using System;

namespace Skclusive.Material.Docs.Native.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("Blazor Material", "wwwroot/index.html");
        }
    }
}
