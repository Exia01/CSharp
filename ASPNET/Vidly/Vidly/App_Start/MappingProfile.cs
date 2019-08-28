using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile // deriving from profile
    {

        public MappingProfile()
        {
            Mapper.CreateMap<Models.Customer, Dtos.Customer>();
            Mapper.CreateMap<Dtos.Customer, Models.Customer>();
            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }

    }
}


//Mapper:https://stackoverflow.com/questions/47091869/create-map-using-automapper-6-1-1