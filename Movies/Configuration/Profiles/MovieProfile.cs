using AutoMapper;
using Movies.Domain.Entities;
using Movies.Dtos;
using System;
using System.Linq;

namespace Movies.Configuration.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.MovieID))
                .ForMember(d => d.Genres, opt => opt.MapFrom(src => string.Join(',', src.MovieGenres.Select(mg => mg.Genre.Name))))
                .ForMember(d => d.AverageRating, opt => opt.MapFrom(src => Math.Round(src.AverageRating * 2, MidpointRounding.AwayFromZero) / 2));
        }
    }
}
