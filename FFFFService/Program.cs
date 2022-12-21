// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Runtime.Loader;
using FFFFPluginBase;
namespace FFFFService
{
    public class Program
    {
        private static Dictionary<string, IFFFFPlugin> Plugins = new Dictionary<string, IFFFFPlugin>();

        private static string PluginPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"Plugins"));

        public static void Main(string[] args)
        {
            Console.WriteLine("Application Started");
            LoadPlugins();
            foreach (var key in Plugins.Keys)
            {
                Plugins[key].MakePayment();
            }
        }

        public static void LoadPlugins()
        {
            foreach (var dll in Directory.GetFiles(PluginPath, "*.dll"))
            {
                AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(dll);
                Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                var FFFFPlugin = Activator.CreateInstance(assembly.GetTypes()[2]) as IFFFFPlugin;
                if (FFFFPlugin != null)
                {
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), FFFFPlugin);
                }
            }
        }
    }
   
}



