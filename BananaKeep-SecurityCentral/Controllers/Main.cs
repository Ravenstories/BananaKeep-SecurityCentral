using System.Runtime.CompilerServices;

namespace BananaKeep_SecurityCentral.Controllers
{
    public static class Main
    {
        public static HomeController Home;
        public static void Initialize()
        {
            Home = new HomeController();
        }
    }
}
