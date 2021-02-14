using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
   public interface IGlobalImage : IDataAccesLayer<GlobalImage>
    {
        public Task<GlobalImage> GetByTagName(string tag);
    }
}
