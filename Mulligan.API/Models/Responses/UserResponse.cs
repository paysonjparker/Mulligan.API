﻿using Mulligan.API.Models.Domain;

namespace Mulligan.API.Models.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public float HandicapIndex { get; set; }
        public string? HomeCourseName { get; set; }
        public ICollection<ScoreResponse>? Scores { get; set; }
        public ICollection<PostResponse>? Posts { get; set; }
        public int? GolfCourseId { get; set; }
    }
}
