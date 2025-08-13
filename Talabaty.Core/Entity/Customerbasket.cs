using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Talabaty.Core.Entity
{
    public class Customerbasket
    {
        public Customerbasket(string id)
        {
            Id = id;    
        }
        public string Id { get; set; }
        [Required]
        public List<BasketIteam> BasketItems { get; set; }
    }
}
