using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace STAR_TEAM
{
    public class Teacher
    {
        [Key]
        public byte Teacher_ID { get; set; }
        [Required]
        public string Teach_Name { get; set; }
        [Required]
        public string Teach_Type { get; set; }
        public string Teach_Email { get; set; }
        public string Teach_Phone { get; set; }
        public string Teach_About { get; set; }

        [Required]
        public string TAvalabile_period { get; set; }
    }
}
