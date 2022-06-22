using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SATProject.DATA.EF.Metadata.cs
{

    #region Course
    [ModelMetadataType(typeof(CourseMetadata))]

    public class CourseMetadata { }



    #endregion

    #region Enrollment

    [ModelMetadataType(typeof(EnrollmentMetadata))]

    public class EnrollmentMetadata { }


    #endregion

    #region ScheduledClass

    [ModelMetadataType(typeof(ScheduledClassMetadata))]

    public class ScheduledClassMetadata { }

    #endregion

    #region ScheduledClassStatus

    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]

    public class ScheduledClassStatusMetadata { }

    #endregion

    #region Student

    [ModelMetadataType(typeof(StudentMetadata))]

    public class StudentMetadata { }


    #endregion

    #region StudentStatus

    [ModelMetadataType(typeof(StudentStatusMetadata))]

    public class SentStudentMetadata { }



    #endregion



}
