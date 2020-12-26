using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class ProductImage : BaseEntity
    {
        public string ImageURL { get; set; }
        public bool isMainImage { get; set; }
        public string ImageAltValue { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
