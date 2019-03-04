using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace STAR_TEAM
{
    public class Class
    {
        [Key]
        public byte Class_ID { get; set; }
        [Required]
        public string Class_Name { get; set; }
        [Required]
        public bool Class_IsCreadet { get; set; }
        [Required]
        public string Class_Group { get; set; }
        [Required]
        public string CAvalabile_period { get; set; }
    }
}
