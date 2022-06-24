
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SATProject.DATA.EF.Models
{

    #region Course
    [ModelMetadataType(typeof(CourseMetadata))]

    public partial class Course { }



    #endregion

    #region Enrollment

    [ModelMetadataType(typeof(EnrollmentMetadata))]

    public partial class Enrollment { }


    #endregion

    #region ScheduledClass

    [ModelMetadataType(typeof(ScheduledClassMetadata))]

    public partial class ScheduledClass { }

    #endregion

    #region ScheduledClassStatus

    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]

    public partial class ScheduledClassStatus { }

    #endregion

    #region Student

    [ModelMetadataType(typeof(StudentMetadata))]

    public partial class Student {
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }


    #endregion

    #region StudentStatus

    [ModelMetadataType(typeof(StudentStatusMetadata))]

    public partial class StudentStatus{ }



    #endregion



}
