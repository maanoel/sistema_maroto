using LojaVirtual.Model;
using LojaVirtual.Model.Context;
using LojaVirtual.Repository.Generic;

namespace LojaVirtual.Repository.Implementations
{
    public class ProductRepositoryImpl : GenericRepository<Product>, IProductRepository
    {
        public ProductRepositoryImpl(MySQLContext context) : base(context)
        {

        }
    }
}
