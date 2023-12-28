

using System;
using System.ComponentModel.DataAnnotations;

namespace SummitSchool.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
