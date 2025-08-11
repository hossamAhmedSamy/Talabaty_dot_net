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
        public ProductWithBrandAndTypeSpecification(string sort) : base()
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "PriceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default:
                        AddOrderBy(P => P.Name);

                        break;
                }
            }
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