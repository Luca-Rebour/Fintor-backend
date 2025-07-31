using Application.DTOs.Categories;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases.Categories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Categories
{
    public class GetAllCategories : IGetAllCategories
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetAllCategories(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDTO>> Execute(Guid userId)
        {
            List<Category> categories = await _categoryRepository.GetAllAsync(userId);
            List<CategoryDTO> ret = _mapper.Map<List<CategoryDTO>>(categories);
            return ret;
        }
    }
}
