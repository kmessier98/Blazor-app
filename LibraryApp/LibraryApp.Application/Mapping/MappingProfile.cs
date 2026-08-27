using AutoMapper;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static LibraryApp.Shared.DTOs.LivreDTO;

namespace LibraryApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Livre, GetAllLivresDto>()
                .ForMember(t => t.LivreId, m => m.MapFrom(s => s.Id))
                .ForMember(t => t.NomEditeur, m => m.MapFrom(s => s.Editeur.Nom))
                .ForMember(t => t.NomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Nom))
                .ForMember(t => t.PrenomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Prenom));

                
        }
    }
}
