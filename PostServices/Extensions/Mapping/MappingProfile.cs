using PostServices.Model.Concrete;
using PostServices.Model.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostServices.Model.Dtos.Methods.GET;
using PostServices.Model.Dtos.Methods.POST;
using MongoDB.Bson;

namespace PostServices.Extensions.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Before Mapping Configuration - Need to CreateMap for Nested Object Also
            CreateMap<Author, GET_AuthorDTO>();
            CreateMap<POST_AuthorDTO, Author>();

            CreateMap<Article, GET_ArticleDTO>();
            CreateMap<POST_ArticleDTO, Article>();

            CreateMap<ObjectId, string>().ConvertUsing(o => o.ToString());
            CreateMap<string, ObjectId>().ConvertUsing(s => ObjectId.Parse(s));

            //Dest = DTO Object, src = Main Object
            CreateMap<Post, GET_PostDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles));
            CreateMap<POST_PostDTO, Post>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Articles));
        }
    }
}
