using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFlix.Models
{
    public enum Certificate { Universal, PG, Twelve, Eighteen}
    public enum Genre { action, adventure, animation, comedy, crime, drama, fantasy, family, horror, scifi, thriller }

    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public String Title { get; set; }

        public Certificate Cert { get; set; }
        public Genre Gen { get; set; }

        [Required]
		public DateTime ReleaseDate { get; set; }

        public int AvgRating { get; set; }

    }
}