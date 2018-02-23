using System.Net;
using Newtonsoft.Json;

namespace MusicaAPI.Classes
{
    public class ConversorJson
    {
        public static T Baixar<T>(string url) where T : new()
        {
            using (var wC = new WebClient())
            {
                var json = string.Empty;
                
                try
                {
                    json = wC.DownloadString(url);
                }
                catch (System.Exception) { }

                // Verifica se a string não está vazia.
                return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : new T();
            }
        }
    }
}