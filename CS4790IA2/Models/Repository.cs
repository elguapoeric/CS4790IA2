using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790IA2.Models
{
    public class Repository
    {
        public static Course getCourse(int? id)
        {
            Course course = BasicSchool.getCourse(id);

            return course;
        }

        public static Section getSection(int? id) 
        {
            Section section = BasicSchool.getSection(id);
            return section;
        }
        public static CourseAndSections getCourseAndSections(int? id)
        {
            CourseAndSections courseSection = BasicSchool.getCourseAndSections(id);
            return courseSection;
        }

        public static List<Course> getAllCourses()
        {
            return BasicSchool.getAllCourses();
        }

        public static List<Section> getAllSections()
        {
            return BasicSchool.getAllSections();
        }

        public static void deleteCourse(Course course)
        {
            BasicSchool.deleteCourse(course);
        }
        public static void editCourse(Course course)
        {
            BasicSchool.editCourse(course);
        }

        public static void createCourse(Course course)
        {
            BasicSchool.createCourse(course);
        }


        public static void deleteSection(Section section)
        {
            BasicSchool.deleteSection(section);
        }
        public static void editSection(Section section)
        {
            BasicSchool.editSection(section);
        }

        public static void createSection(Section section)
        {
            BasicSchool.createSection(section);
        }

    }

    public class CourseAndSections
    {
        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }
}