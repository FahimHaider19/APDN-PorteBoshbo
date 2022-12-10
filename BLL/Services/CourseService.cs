using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class CourseService
    {
        public List<CourseDTO> Get()
        {
            var courses = new List<CourseDTO>();
            var coursedb = DataAccessFactory.CourseDataAccess().GetAll();
            foreach (var course in coursedb)
            {
                courses.Add(new CourseDTO()
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                });
            }
            return courses;
        }
        public CourseDTO Get(int id)
        {
            var coursedb = DataAccessFactory.CourseDataAccess().Get(id);
            var course = new CourseDTO()
            {
                CourseId = coursedb.CourseId,
                CourseName = coursedb.CourseName
            };
            return course;
        }
        public bool Add(CourseDTO Course)
        {
            var coursedb = new Course()
            {
                CourseId = Course.CourseId,
                CourseName = Course.CourseName
            };
            return DataAccessFactory.CourseDataAccess().Add(coursedb);
        }
        public bool Update(CourseDTO Course)
        {
            var coursedb = DataAccessFactory.CourseDataAccess().Get(Course.CourseId);
            coursedb.CourseName = Course.CourseName;

            return DataAccessFactory.CourseDataAccess().Add(coursedb);
        }
        public bool Delete(int id)
        {
            return DataAccessFactory.CourseDataAccess().Remove(id);
        }
    }
}
