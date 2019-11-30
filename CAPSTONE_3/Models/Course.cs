using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CAPSTONE_3.Models
{
    //Data Annotaion indicates Server Validation
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CourseId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateCreated { get; set; }

        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Instructor { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}