using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Abstract
{
   public interface IGlobalTextDataDAL: IDataAccesLayer<GlobalTextData>
    {
        public string GetByTagName(string tag);
    }
}
