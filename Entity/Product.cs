using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Core.Util;

namespace Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Enums.UnitType UnitType{ get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public Category Category { get; set; }
        public Language Language{ get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }

    }
}
