using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabaty.Core.Entity
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public string ImageUrl { get; set; }
        // Navigation property to link to products
    }
}
