using System.Net.Http;
using System.Threading.Tasks;

namespace JokesApp.DataServices
{
    internal class DadJokesClass
    {
        string strJokeUrl = string.Empty;
        public DadJokesClass()
        {
            strJokeUrl = System.Windows.Application.Current.FindResource("strUrl").ToString();
        }

        internal async Task<string> GetARandomJoke()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, strJokeUrl);
                request.Headers.Add("Accept", " text/plain");
                request.Headers.Add("User-Agent", " JokesApp (https://github.com/kr-ambuj/repo)");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }                
        }

        internal async Task<string> GetJokesWithSearchString(string searchText)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{strJokeUrl}search?page=1&limit=30&term={searchText}");
                request.Headers.Add("Accept", " application/json");
                request.Headers.Add("User-Agent", " JokesApp (https://github.com/kr-ambuj/repo)");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }                
        }
    }
}
