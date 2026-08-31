using AutoMapper;
using LibraryApp.Domain.Entities;
using LibraryApp.Shared.DTOs;
using static LibraryApp.Shared.DTOs.AuteurDto;
using static LibraryApp.Shared.DTOs.CategoryDto;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Livre, GetAllLivresDto>()
                .ForMember(t => t.LivreId, m => m.MapFrom(s => s.Id))
                .ForMember(t => t.NomEditeur, m => m.MapFrom(s => s.Editeur.Nom))
                .ForMember(t => t.AuteurId, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Id))
                .ForMember(t => t.NomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Nom))
                .ForMember(t => t.PrenomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Prenom))
                .ForMember(t => t.CategoryIds, m => m.MapFrom(s => s.Categories.Select(c => c.Id)));
                

            CreateMap<Categorie, GetAllCategoryDto>()
                .ForMember(t => t.Id, m => m.MapFrom(s => s.Id))
                .ForMember(t => t.Nom, m => m.MapFrom(s => s.Nom));

            CreateMap<Auteur, GetAuteurInfosDto>();

            CreateMap<Emprunt, EmpruntDto>()
                .ForMember(t => t.UserId, m => m.MapFrom(s =>s.Utilisateur.Id))
                .ForMember(t => t.NomUtilisateur, m => m.MapFrom(s => s.Utilisateur.Nom))
                .ForMember(t => t.TitreLivre, m => m.MapFrom(s => s.Livre != null ? s.Livre.Titre : ""));

            CreateMap<Livre, GetLivreInfosDto>()
                .ForMember(t => t.LivreId, m => m.MapFrom(s => s.Id))
                .ForMember(t => t.NomEditeur, m => m.MapFrom(s => s.Editeur.Nom))
                .ForMember(t => t.NomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Nom))
                .ForMember(t => t.PrenomAuteur, m => m.MapFrom(s => s.Auteurs.FirstOrDefault().Prenom));

            CreateMap<Utilisateur, UtilisateurDto>();

        }
    }
}
