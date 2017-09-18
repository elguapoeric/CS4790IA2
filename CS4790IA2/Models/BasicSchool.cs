using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CS4790IA2.Models
{
    public class BasicSchool
    {
        public static List<Course> getAllCourses()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.courses.ToList();
        }

        public static Course getCourse(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Course course = db.courses.Find(id);

            return course;
        }

      /*  public static List<Course> getAllCourses()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.courses.ToList();
        }*/
    }


    [Table("Course")]
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Course Name")]
        public string courseName { get; set; }
        [Range(0,4, ErrorMessage = "What are you thinking????")]
        [DisplayName("Course Hours")]
        public int creditHours { get; set; }
        [DisplayName("Maximum Enrollment")]
        public int? maxEnrollment { get; set; }
    }

    [Table("Section")]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Section ID")]
        public int sectionID { get; set; }
        [DisplayName("Section Number")]
        public int sectionNumber { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Section Days")]
        public string sectionDays { get; set; }
        [DisplayName("Section Time")]
        public DateTime sectionTime { get; set; }
    }

    public class BasicSchoolDbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Section> sections { get; set; }
    }

}