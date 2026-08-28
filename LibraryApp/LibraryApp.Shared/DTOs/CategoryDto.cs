using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Shared.DTOs
{
    public class CategoryDto
    {
        public class GetAllCategoryDto()
        {
            public int Id { get; set; }
            public string Nom { get; set; }
        }
    }
}
