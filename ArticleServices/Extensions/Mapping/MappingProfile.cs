using ArticleServices.Model.Concrete;
using ArticleServices.Model.Dtos;
using AutoMapper;
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
            CreateMap<Author, AuthorDTO>().ReverseMap();

            //Dest = DTO Object, src = Main Object
            CreateMap<Article, ArticleDTO>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author)).ReverseMap();
            CreateMap<Article, AddArticleDTO>().ReverseMap();
        }
    }
}
