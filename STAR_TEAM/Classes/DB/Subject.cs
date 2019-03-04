using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace STAR_TEAM
{
    public class Subject
    {
        [Key]
        public byte Sub_ID { get; set; }
        [Required]
        public string Sub_Name { get; set; }
        [Required]
        public string SDescreption_place { get; set; }
        [Required]
        public bool Is_Group { get; set; }
        [Required]
        public int Sub_Timebyweek { get; set; }
        [Required]
        public List<Class> Sub_ClassList { get; set; }
        [Required]
        public List<Teacher> Sub_TeachList { get; set; }
    }
}
