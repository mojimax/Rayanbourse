using Application.Contracts.Persistence.Base;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence.Products
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
