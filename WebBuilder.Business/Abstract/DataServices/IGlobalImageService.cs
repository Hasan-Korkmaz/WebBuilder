using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Abstract.DataServices
{
    public interface IGlobalImageService: IDataService<GlobalImage, IGlobalImage>
    {
        public Task<IResult<GlobalImage>> GetByTagName(string tag);
    }
}
