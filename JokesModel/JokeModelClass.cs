using Newtonsoft.Json;
namespace JokesApp.JokesModel
{
    internal class JokeModelClass
    {
        [JsonProperty("current_page")]
        public long CurrentPage { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("next_page")]
        public long NextPage { get; set; }

        [JsonProperty("previous_page")]
        public long PreviousPage { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("search_term")]
        public string? SearchTerm { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("total_jokes")]
        public long TotalJokes { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }
    }

    internal partial class Result
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("joke")]
        public string? Joke { get; set; }
    }
}
