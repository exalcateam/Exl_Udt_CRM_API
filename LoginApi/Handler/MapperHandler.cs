using AutoMapper;
using LoginApi.Dto;
using LoginApi.Models;

namespace LoginApi.Handler
{
    public class MapperHandler : Profile

    {
        public MapperHandler()
        {
            CreateMap<UserLoginDto, UserLoginClass>();
        }
    }
}
