using System;

namespace Project.SGP.Helpers
{
    public class GetPath
    {
        public static string GetResourcePath(string file)
        {
            return $"{AppDomain.CurrentDomain.BaseDirectory}\\Resources\\{file}";
        }
    }
}
