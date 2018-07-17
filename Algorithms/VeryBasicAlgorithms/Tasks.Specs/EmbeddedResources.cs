namespace Tasks.Specs
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class EmbeddedResources
    {
        public static string Get(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string fullName = assembly.GetManifestResourceNames().First(r => r.Contains(resourceName));

            using (Stream stream = assembly.GetManifestResourceStream(fullName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static IEnumerable<string> GetLines(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string fullName = assembly.GetManifestResourceNames().First(r => r.Contains(resourceName));

            using (Stream stream = assembly.GetManifestResourceStream(fullName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
