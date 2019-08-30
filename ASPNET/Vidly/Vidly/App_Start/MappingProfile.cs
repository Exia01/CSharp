using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile // deriving from profile
    {

        public MappingProfile()
        {

            //Domain to DTO
            Mapper.CreateMap<Models.Customer, Dtos.Customer>();
            Mapper.CreateMap<Dtos.Customer, Models.Customer>();
            Mapper.CreateMap<MembershipType, MemebershipTypeDto>();
        
        }

    }
}


//Mapper:https://stackoverflow.com/questions/47091869/create-map-using-automapper-6-1-1