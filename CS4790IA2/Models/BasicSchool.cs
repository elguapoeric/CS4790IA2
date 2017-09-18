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

        public static void deleteCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Deleted;
            db.courses.Remove(course);
            db.SaveChanges();
        }

        public static void editCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void createCourse(Course course)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(course).State = EntityState.Added;
            db.courses.Add(course);
            db.SaveChanges();
        }

        public static List<Section> getAllSections()
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            return db.sections.ToList();
        }

        public static Section getSection(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            Section section = db.sections.Find(id);
            return section;
        }

        public static void deleteSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Deleted;
            db.sections.Remove(section);
            db.SaveChanges();
        }

        public static void editSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void createSection(Section section)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            db.Entry(section).State = EntityState.Added;
            db.sections.Add(section);
            db.SaveChanges();
        }
        public static CourseAndSections getCourseAndSections(int? id)
        {
            BasicSchoolDbContext db = new BasicSchoolDbContext();
            CourseAndSections courseSection = new CourseAndSections();
            courseSection.course = db.courses.Find(id);
            var sections = db.sections.Where(s => s.courseNumber == courseSection.course.courseNumber);
            courseSection.sections = sections.ToList();
            return courseSection;
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