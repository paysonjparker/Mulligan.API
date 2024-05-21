using AutoMapper;
using Mulligan.API.Models.Authentication;
using Mulligan.API.Models.Domain;
using Mulligan.API.Models.Requests.UserRequests;

namespace Mulligan.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

            // RegisterRequest -> User
            CreateMap<AddUserRequest, User>();

            // UpdateRequest -> User
            CreateMap<UpdateUserRequest, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));
        }

    }
}
