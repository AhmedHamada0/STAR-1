using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace STAR_TEAM
{
    public class Place
    {
        [Key]
        public byte Place_ID { get; set; }
        [Required]
        public string Place_Name { get; set; }
        [Required]
        public string PDescribtion_place { get; set; }
    }
}
