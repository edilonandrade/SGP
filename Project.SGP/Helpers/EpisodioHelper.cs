using System;
using System.IO;

namespace Project.SGP.Helpers
{
    public static class EpisodioHelper
    {
        private static string Episodio;
        public static string GerarEpisodios(string textoNome)
        {
            var generateNames = DateTime.Now.ToString("hh_mm_ss");
            var names = textoNome + generateNames;

            Episodio = names;
            return names;
        }
    }
}
