using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebApp.Models
{
    public class Sessions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Session Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SessionDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Session Start")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SessionStart { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Session End")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime SessionEnd { get; set; }

        [Required]
        [Display(Name = "Ticket Price")]
        public double TicketPrice { get; set; }

        [ForeignKey("AnimationTypes")]
        [Display(Name = "Animation Type")]
        public int AnimationTypesFK { get; set; }
        public AnimationTypes AnimationTypes { get; set; }

        [ForeignKey("AudioTypes")]
        [Display(Name = "Audio Type")]
        public int AudioTypesFK { get; set; }
        public AudioTypes AudioTypes { get; set; }

        [ForeignKey("Movies")]
        [Display(Name = "Movie")]
        public int MoviesFK { get; set; }
        public Movies Movies { get; set; }

        [ForeignKey("Rooms")]
        [Display(Name = "Room")]
        public int RoomsFK { get; set; }
        public Rooms Rooms { get; set; }

        public Sessions()
        {

        }
    }
}
