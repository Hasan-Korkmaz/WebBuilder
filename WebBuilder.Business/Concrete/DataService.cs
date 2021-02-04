using Data.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Core.Model.Result;

namespace WebBuilder.Business.Concrete
{
    public class DataService<TEntity, TDataProvider> : IDataService<TEntity, TDataProvider> where TEntity : BaseEntity where TDataProvider : IDataAccesLayer<TEntity>
    {
        internal TDataProvider _dataProvider;
        private string _language;
        public string Language { get { return _language; } set { _dataProvider.Language = value; _language = value; } }

        public DataService(TDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;
        }
        public virtual async Task<IResult<TEntity>> Add(TEntity entity)
        {
            var result = new Result<TEntity>();
            try
            {
                await _dataProvider.AddAsync(entity);
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Ekleme işlemi başarılı bir şekilde gerçekleştirildi.";

            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Ekleme işlemi yapılırken bir servis hatası oluştu.";
            }
            return result;
        }
        public virtual async Task<IResult<TEntity>> Delete(TEntity entity)
        {
            var result = new Result<TEntity>();
            try
            {
                entity.DeletedDate = DateTime.Now;
                await _dataProvider.DeleteAsync(entity);
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Silme işlemi başarılı bir şekilde gerçekleştirildi.";

            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Silme işlemi yapılırken bir servis hata oluştu.";
            }
            return result;
        }
        public virtual async Task<IResult<TEntity>> Update(TEntity entity)
        {
            var result = new Result<TEntity>();
            try
            {
                entity.UpdatedDate = DateTime.Now;
                await _dataProvider.UpdateAsync(entity);
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Güncelleme işlemi başarılı bir şekilde gerçekleştirildi.";

            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Güncelleme işlemi yapılırken bir hata oluştu";
            }
            return result;
        }
        public virtual async Task<IResult<TEntity>> Get(Expression<Func<TEntity, bool>> expression = null)
        {
            var result = new Result<TEntity>();
            try
            {
                TEntity dbObject = await _dataProvider.Get(expression);
                if (dbObject != null)
                {
                    result.Data = dbObject;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = "Kayıt bulundu.";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message = " Kriterlere göre kayıt bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Arama işlemi yapılırken bir hata oluştu";
            }
            return result;
        }
        public virtual async Task<IResult<List<TEntity>>> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            var result = new Result<List<TEntity>>();
            try
            {
                List<TEntity> dbObject = await _dataProvider.GetAllAsync(expression);
                if (dbObject != null && dbObject.Count > 0)
                {
                    result.Data = dbObject;
                    result.Status = Core.Util.Enums.Status.Success;
                    result.Message = dbObject.Count + " kayıt bulundu listeleniyor.";
                }
                else
                {
                    result.Status = Core.Util.Enums.Status.Empty;
                    result.Message =  "Kriterlere göre kayıt bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = " Arama işlemi yapılırken bir hata oluştu";
            }
            return result;
        }

        public virtual async Task<IResult<TEntity>> DeleteExp(Expression<Func<TEntity, bool>> expression )
        {
        
            var result = new Result<TEntity>();
            try
            {
               
                await _dataProvider.DeleteExpression(expression);
                result.Status = Core.Util.Enums.Status.Success;
                result.Message = "Silme işlemi başarılı bir şekilde gerçekleştirildi.";

            }
            catch (Exception ex)
            {
                result.Status = Core.Util.Enums.Status.Error;
                result.Message = "Silme işlemi yapılırken bir servis hata oluştu.";
            }
            return result;
        
    }
    }
}
