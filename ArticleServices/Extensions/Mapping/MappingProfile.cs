using ArticleServices.Model.Concrete;
using ArticleServices.Model.Dto.Methods.DELETE;
using ArticleServices.Model.Dto.Methods.GET;
using ArticleServices.Model.Dto.Methods.POST;
using ArticleServices.Model.Dto.Methods.PUT;
using AutoMapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleServices.Extensions.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Before Mapping Configuration - Need to CreateMap for Nested Object Also
            CreateMap<Article, GET_ArticleDTO>();
            CreateMap<POST_ArticleDTO, Article>();
            CreateMap<PUT_ArticleDTO, Article>();
            CreateMap<DELETE_ArticleDTO, Article>();
            CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            CreateMap<string, ObjectId>().ConvertUsing(s => ObjectId.Parse(s));
        }
    }
}
