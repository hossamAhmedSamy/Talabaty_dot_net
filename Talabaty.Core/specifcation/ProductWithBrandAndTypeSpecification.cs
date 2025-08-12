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
        public ProductWithBrandAndTypeSpecification(ProductSpecParams Params) 
            :base(P => (!Params.BrandId.HasValue || P.ProductBrandId == Params.BrandId)&&(!Params.TypeId.HasValue || P.ProductTypeId == Params.TypeId))
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
            if(!string.IsNullOrEmpty(Params.Sort))
            {
                switch(Params.Sort.ToLower())
                {
                    case "priceasc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    case "name":
                    case "nameasc":
                        AddOrderBy(P => P.Name);
                        break;
                    case "namedesc":
                        AddOrderByDesc(P => P.Name);
                        break;
                    default:
                        AddOrderBy(P => P.Name);
                        break;
                }
            }
            else
            {
                // Default sorting by name if no sort parameter is provided
                AddOrderBy(P => P.Name);
            }

            ApplyPaging(Params.PageSize * (Params.PageIndex - 1), Params.PageSize);
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