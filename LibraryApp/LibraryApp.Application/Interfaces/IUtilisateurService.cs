using LibraryApp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Application.Interfaces
{
    public interface IUtilisateurService
    {
        Task<List<UtilisateurDto>> GetAll();
    }
}
