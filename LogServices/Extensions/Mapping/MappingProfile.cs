using AutoMapper;
using LogServices.Model.Concrete;
using LogServices.Model.Dtos.Methods.GET;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogServices.Extensions.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Log, GET_LogDTO>().ReverseMap();

            CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            CreateMap<string, ObjectId>().ConvertUsing(s => ObjectId.Parse(s));
        }
    }
}
