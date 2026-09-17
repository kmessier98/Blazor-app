using LibraryApp.Domain.Entities;
using LibraryApp.Shared.Interfaces;

namespace LibraryApp.Application.Interfaces
{
    public interface ILivreRepository : IGenericInterface<Livre>
    {
        //Task EmprunterLivre(Livre entity, int membreId);
    }
}
