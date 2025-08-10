using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabaty.Core.Entity;

namespace Talabaty.Core.specifcation
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        // Constructor for getting all products
        public ProductWithBrandAndTypeSpecification() : base()
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
        }

        // Constructor for getting product by ID
        public ProductWithBrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            // Add the same includes for single product retrieval
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
        }
    }
}