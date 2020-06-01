using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGVBooking.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Poster { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Trailer { get; set; }
        public string Rated { get; set; }
        public int Time { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PremiereDate { get; set; }

        public virtual ICollection<ShowTimes> ShowTimes { get; set; }
    }
}