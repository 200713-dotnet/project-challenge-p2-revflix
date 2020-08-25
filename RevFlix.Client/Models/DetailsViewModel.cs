using System.Collections.Generic;

namespace RevFlix.Client.Models
{
    public class DetailsViewModel
    {
        public string description { get; set; }
        public List<string> directors { get; set; }
        public List<string> genres { get; set; }
        public string imdb_Rating { get; set; }
        public List<string> stars { get; set; }
        public string status { get; set; }
        public string status_message { get; set; }
        public string youtube_Trailer_Key { get; set; }
        public string year { get; set; }
        public string title { get; set; }
        public string imdb_id { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }

    }
}
