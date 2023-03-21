using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, strJokeUrl);
            request.Headers.Add("User-Agent", "");
            request.Headers.Add("Accept", " application/json");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
