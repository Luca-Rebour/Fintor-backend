using Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Categories
{
    public interface ICreateCategory
    {
        Task<CategoryDTO> ExecuteAsync(CreateCategoryDTO createCategoryDTO, Guid userId);
    }
}
