using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PopcornWebApp.Models
{
    public class AudioTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public AudioTypes()
        {

        }
    }
}
