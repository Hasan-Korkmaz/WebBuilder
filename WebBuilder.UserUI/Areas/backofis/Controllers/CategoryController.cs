using Entity.FrontDataTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Business.Concrete;
using WebBuilder.Core.Util;

namespace WebBuilder.UserUI.Areas.backofis.Controllers
{
    [Area("backofis")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController (ICategoryService categoryService)
        {   
            this.categoryService = categoryService;

        }
        #region Views
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.ViewActionType = Enums.ViewStatus.Insert;
            return View("CategoryInsertUpdateForm");
        }
        public ActionResult UpdateView(int id)
        {
           var categoryModel= this.categoryService.Get(x => x.Id == id);
            ViewBag.ViewActionType = Enums.ViewStatus.Update;
            return View("CategoryInsertUpdateForm", categoryModel);
        }
        #endregion

        #region Operations
        public  ApiResponse Select2 (string search)
        {
           var asyncList= this.categoryService.GetList(x => true).Result;
            ApiResponse apiResponse = new ApiResponse();
            apiResponse.Message = asyncList.Message;

            if (asyncList.Status==Enums.Status.Success)
            {
                if (!string.IsNullOrWhiteSpace(search))
                {
                    asyncList.Data.Where(x=> x.CategoryName.Contains(search)).Select(x => new Select2Model() { id = x.Id, text = x.CategoryName }).ToList();
                    apiResponse.StatusCode = 200;
                return apiResponse;
                }
                else
                {
                    
                    apiResponse.Data= asyncList.Data.Select(x => new Select2Model() { id = x.Id, text = x.CategoryName }).ToList();
                    return apiResponse;
                }
            }
            else
            {
                apiResponse.StatusCode = 200;
                return apiResponse;
            }
           
        
        }

        public async Task<ApiResponse> GetList()
        {
            //Yalnızca Kategori Tablosundaki verileri getirir dile bakmaz.
            var model = await categoryService.GetAllOnlyCategoriesAsync(x => true);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200, DataStatus = true };
            }
            else
            {
                return new ApiResponse { Message = model.Message, StatusCode = 500, DataStatus = false };
            }

        }
        #endregion

    }
}
