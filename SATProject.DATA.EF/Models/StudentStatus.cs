using System;
using System.Collections.Generic;

namespace SATProject.DATA.EF.Models
{
    public partial class StudentStatus
    {
        public StudentStatus()
        {
            Students = new HashSet<Student>();
        }

        public int Ssid { get; set; }
        public string Ssname { get; set; } = null!;
        public string? Ssdescription { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
