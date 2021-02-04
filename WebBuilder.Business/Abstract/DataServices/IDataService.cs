using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Abstract.DataServices
{
    public interface IDataService<T, DataProvider> : IService where T : BaseEntity where DataProvider : IDataAccesLayer<T>
    {
        string Language { get; set; }
        Task<IResult<T>> Add(T entity);
        Task<IResult<T>> Update(T entity);
        Task<IResult<T>> Delete(T entity);
        Task<IResult<T>> Get(Expression<Func<T, bool>> expression = null);
        Task<IResult<T>> DeleteExp(Expression<Func<T, bool>> expression = null);
        Task<IResult<List<T>>> GetList(Expression<Func<T, bool>> expression = null);
    }
}
