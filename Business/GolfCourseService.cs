﻿using Mulligan.API.Data;
using Mulligan.API.Models.DataTransferObjects.GolfCourseDto;
using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Business
{
    public class GolfCourseService
    {
        // Db Context
        private readonly MulliganDbContext _dbContext;

        /// <summary>
        /// Constrcutor with dbContext injection
        /// </summary>
        /// <param name="dbContext">DB Context</param>
        public GolfCourseService(MulliganDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new golf course to the golf course table
        /// </summary>
        /// <param name="addGolfCourseRequest">Golf course request</param>
        /// <returns></returns>
        public GolfCourse AddGolfCourse(AddGolfCourseRequest addGolfCourseRequest)
        {
            // Convert DTO to Domain Model
            var golfCourse = new GolfCourse
            {
                Name = addGolfCourseRequest.Name,
                Location = addGolfCourseRequest.Location,
                SlopeRating = addGolfCourseRequest.SlopeRating,
                CourseRating = addGolfCourseRequest.CourseRating,
                Yardage = addGolfCourseRequest.Yardage,
                Par = addGolfCourseRequest.Par,
            };

            _dbContext.GolfCourses.Add(golfCourse);
            _dbContext.SaveChanges();

            return golfCourse;
        }

        /// <summary>
        /// Gets all golf courses from the golf course table
        /// </summary>
        /// <returns>A list of golf courses</returns>
        public List<GolfCourse> GetAllGolfCourses()
        {
            var golfCourses = _dbContext.GolfCourses.ToList();

            var golfersDTO = new List<GolfCourse>();
            foreach (var golfCourse in golfCourses)
            {
                golfersDTO.Add(new GolfCourse
                {
                    Id = golfCourse.Id,
                    Name = golfCourse.Name,
                    Location = golfCourse.Location,
                    SlopeRating = golfCourse.SlopeRating,
                    CourseRating = golfCourse.CourseRating,
                    Yardage = golfCourse.Yardage,
                    Par = golfCourse.Par,
                });
            }

            return golfersDTO;
        }

        /// <summary>
        /// Gets a specific golf course by ID number
        /// </summary>
        /// <param name="id">ID of the golf course</param>
        /// <returns>A golf course object</returns>
        public GolfCourse GetGolfCourseById(Guid id)
        {
            var golfCourseDomainObject = _dbContext.GolfCourses.Find(id);

            if (golfCourseDomainObject != null)
            {
                var golfCourseDTO = new GolfCourse
                {
                    Id = golfCourseDomainObject.Id,
                    Name = golfCourseDomainObject.Name,
                    Location = golfCourseDomainObject.Location,
                    SlopeRating = golfCourseDomainObject.SlopeRating,
                    CourseRating = golfCourseDomainObject.CourseRating,
                    Yardage = golfCourseDomainObject.Yardage,
                    Par = golfCourseDomainObject.Par,
                };

                return golfCourseDTO;
            }

            return null;
        }

        /// <summary>
        /// Gets a golf course by a specific name from the database
        /// </summary>
        /// <param name="golfCourseName">Golf course name</param>
        /// <returns>A golf course object</returns>
        public GolfCourse GetGolfCourseByName(string golfCourseName)
        {
            var golfCourseDomainObject = _dbContext.GolfCourses.FirstOrDefault(golfCourse => golfCourse.Name.Equals(golfCourseName));

            if (golfCourseDomainObject != null)
            {
                var golfCourseDTO = new GolfCourse
                {
                    Id = golfCourseDomainObject.Id,
                    Name = golfCourseDomainObject.Name,
                    Location = golfCourseDomainObject.Location,
                    SlopeRating = golfCourseDomainObject.SlopeRating,
                    CourseRating = golfCourseDomainObject.CourseRating,
                    Yardage = golfCourseDomainObject.Yardage,
                    Par = golfCourseDomainObject.Par,
                };

                return golfCourseDTO;
            }

            return null;
        }

        public bool DeleteGolfCourse(Guid id)
        {
            var existingGolfCourse = _dbContext.GolfCourses.Find(id);

            if (existingGolfCourse != null)
            {
                _dbContext.GolfCourses.Remove(existingGolfCourse);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates an exisitng golf course in the database
        /// </summary>
        /// <param name="id">ID number of the golf course being updated</param>
        /// <param name="updateGolfCourseRequest">Update golf course request</param>
        /// <returns>The newly updated golf course object</returns>
        public GolfCourse UpdateGolfCourse(Guid id, UpdateGolfCourseRequest updateGolfCourseRequest)
        {
            var existingGolfCourse = _dbContext.GolfCourses.Find(id);

            if (existingGolfCourse != null)
            {
                existingGolfCourse.Name = updateGolfCourseRequest.Name;
                existingGolfCourse.Location = updateGolfCourseRequest.Location;
                existingGolfCourse.SlopeRating = updateGolfCourseRequest.SlopeRating;
                existingGolfCourse.CourseRating = updateGolfCourseRequest.CourseRating;
                existingGolfCourse.Yardage = updateGolfCourseRequest.Yardage;
                existingGolfCourse.Par = updateGolfCourseRequest.Par;

                _dbContext.SaveChanges();
                return existingGolfCourse;
            }

            return null;
        }
    }
}
