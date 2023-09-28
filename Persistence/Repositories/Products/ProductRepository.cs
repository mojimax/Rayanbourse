using Application.Contracts.Persistence.Products;
using Domain.Products;
using Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Products
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(RayanbourseDbContext context) : base(context)
        {
        }
    }
}
