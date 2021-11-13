using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebApp.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string MovieImage { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Required]
        public string Synopsis { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Length")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Duration { get; set; }

        public Movies()
        {

        }
    }
}