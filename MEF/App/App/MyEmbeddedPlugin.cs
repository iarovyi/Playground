using Contract;

namespace App
{
    public class MyEmbeddedPlugin : IPlugin
    {
        public string GetName()
        {
            return "Embedded plugin";
        }
    }
}
