using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebApp.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(25)]
        public string RoomName { get; set; }

        [Required]
        [Display(Name = "Seats Quantity")]
        public int SeatsQuantity { get; set; }

        public Rooms()
        {

        }

    }
}