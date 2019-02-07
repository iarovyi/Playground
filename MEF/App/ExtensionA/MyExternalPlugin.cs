using Contract;

namespace ExtensionA
{
    public class MyExternalPlugin : IPlugin
    {
        public string GetName()
        {
            return "External plugin";
        }
    }
}
