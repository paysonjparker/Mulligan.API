﻿using Mulligan.API.Models.DomainModels;

namespace Mulligan.API.Models.DataTransferObjects.UserDto
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid GolfCourseId { get; set; }
    }
}
