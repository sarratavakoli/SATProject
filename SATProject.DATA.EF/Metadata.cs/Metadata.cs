using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATProject.DATA.EF.Models
{
   public class CourseMetadata
    {   
        public int CourseId { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "* Course Name is required.")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Description")]
        [Required(ErrorMessage = "* Course Description is required.")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "* Hours is required.")]
        [Display(Name = "Credit Hours")]
        public short CreditHours { get; set; }
        [StringLength(250)]
        public string Curriculum { get; set; }
        [StringLength(200)]
        public string Notes { get; set; }
        [Required(ErrorMessage = "* Active status is required.")]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }

    }

    public class EnrollmentMetadata
    {
        public int EnrollmentId { get; set; }
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "* Student Id is required.")]
        public int StudentId { get; set; }
        [Display(Name = "Scheduled Class ID")]
        [Required(ErrorMessage = "* Scheduled Class Id is required.")]
        public int ScheduledClassId { get; set; }
        [Display(Name = "Enrollment Date")]
        [Required(ErrorMessage = "* Enrollment Date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateOnly EnrollmentDate { get; set; }
    }

    public class ScheduledClassMetadata
    {
        public int ScheduledClassId { get; set; }
        [Required(ErrorMessage = "* Course Id is required.")]
        public int CourseId { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "* Start Date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateOnly StartDate { get; set; }
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "* End Date is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateOnly EndDate { get; set; }
        [Display(Name = "Instructor Name")]
        [Required(ErrorMessage = "* Instructor Name is required.")]
        [StringLength(40)]
        public string InstructorName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "* Location is required.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "* SSID is required.")]
        public int SSID { get; set; }
    }

    public class ScheduledClassStatusMetadata
    {
        public int SSID { get; set; }
        [StringLength(50)]
        [Display(Name = "Scheduled Class Status Name")]
        public string SCSName { get; set; }
    }

    public class StudentMetadata
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "* First Name is required.")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "* Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(15)]
        public string Major { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(25)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        [StringLength(25)]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [StringLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(60)]
        [Required(ErrorMessage = "* Email is required.")]
        public string Email { get; set; }
        [StringLength(100)]
        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }
        [Required(ErrorMessage = "* Status is required.")]
        [Display(Name = "Status")]
        public int SSID { get; set;}
    }

    public class StudentStatusMetadata
    {
        public int SSID { get; set; }
        [Required(ErrorMessage = "* Student Status Name is required.")]
        [StringLength(30)]
        [Display(Name = "Student Status Name")]
        public string SSName { get; set; }
        [StringLength(250)]
        [Display(Name = "Student Status Description")]
        public string SSDescription { get; set; }
    }
}
