﻿using Mulligan.API.Models.Domain;

namespace Mulligan.API.Models.Responses
{
    public class GolfCourseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string? Subdivision { get; set; }
        public string Country { get; set; }
        public int Yardage { get; set; }
        public int Par { get; set; }
        public int SlopeRating { get; set; }
        public float CourseRating { get; set; }
        public ICollection<ScoreResponse>? Scores { get; set; }
        public ICollection<UserResponse>? Users { get; set; }
    }
}
