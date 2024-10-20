using System.Net.Http;
using System.Threading.Tasks;

namespace Project.Function
{
    public static class HTTPHelper
    {
        public static async Task<string> CallApiAsync(string apiUrl)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(apiUrl);
            
            if (!response.IsSuccessStatusCode)
            {
                return $"FAILURE: {response.StatusCode} - {apiUrl}";
            }

            return string.Empty;
        }
    }
}