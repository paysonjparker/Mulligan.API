﻿namespace Mulligan.API.Models.Responses
{
    public class ScoreResponse
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public float Differential { get; set; }
        public Guid UserId { get; set; }
        public Guid GolfCourseId { get; set; }
    }
}