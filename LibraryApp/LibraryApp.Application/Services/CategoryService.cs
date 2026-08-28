using AutoMapper;
using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using static LibraryApp.Shared.DTOs.CategoryDto;

namespace LibraryApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetAllCategoryDto>> GetAll()
        {
            var result = await _categoryRepository.GetAllAsync();

            var dto = _mapper.Map<List<GetAllCategoryDto>>(result);

            return dto;
        }
    }
}
