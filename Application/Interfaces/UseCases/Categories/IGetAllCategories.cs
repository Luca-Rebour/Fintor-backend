using Application.DTOs.Categories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UseCases.Categories
{
    public interface IGetAllCategories
    {
        Task<List<CategoryDTO>> Execute(Guid userId);
    }
}
