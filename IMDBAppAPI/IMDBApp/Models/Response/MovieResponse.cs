﻿using IMDBApp.Models.Classes;
using System.Collections.Generic;

namespace IMDBApp.Models.Response
{
    public class MovieResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Plot { get; set; }
        public List<ActorResponse> Actors { get; set; }
        public List<GenreResponse> Genres { get; set; }
        public ProducerResponse Producer { get; set; }
        public string CoverImage { get; set; }

    }
}
