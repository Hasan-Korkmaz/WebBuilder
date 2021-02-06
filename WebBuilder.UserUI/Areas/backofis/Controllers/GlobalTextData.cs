using Entity.FrontDataTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using WebBuilder.Business.Abstract.LanguageDataServices;
using static WebBuilder.Core.Util.Enums;

namespace WebBuilder.UserUI.Areas.backofis.Controllers
{
    [Area("backofis")]
    public class GlobalTextData : Controller
    {
        IGlobalTextDataService globalTextDataService;
        IGlobalTextDataLanguageService globalTextDataLanguageService;
        public GlobalTextData(IGlobalTextDataService globalTextDataService, IGlobalTextDataLanguageService globalTextDataLanguageService)
        {
            this.globalTextDataService = globalTextDataService;
            this.globalTextDataLanguageService = globalTextDataLanguageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.InsertOrUpdate = ViewStatus.Insert;
            return View("InsertOrUpdate");
        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var searchInContext = await this.globalTextDataService.Get(x => x.Id == id);
            if (searchInContext.Status == Status.Success)
            {
                ViewBag.InsertOrUpdate = ViewStatus.Update;
                return View("InsertOrUpdate", searchInContext.Data);
            }
            else
            {
                return StatusCode(404);
            }

        }


        #region Operations

        [HttpPost]
        public async Task<ApiResponse> Add(Entity.GlobalTextData entity)
        {
       
          
            var serviceStatus = await this.globalTextDataService.Add(entity);
            if (serviceStatus.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = serviceStatus.Data, Message = serviceStatus.Message, StatusCode = 200 };
            }
            else
            {
                return new ApiResponse { Message = serviceStatus.Message, StatusCode = 500 };

            }
        }
        public async Task<ApiResponse> Delete(int id)
        {
            var searchInContext = await this.globalTextDataService.Get(x => x.Id == id);
            if (searchInContext.Status == Status.Empty)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 203, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Error)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 500, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Success)
            {
                var serviceStatus = await this.globalTextDataService.Delete(searchInContext.Data);
                if (serviceStatus.Status == Core.Util.Enums.Status.Success)
                {
                    return new ApiResponse { Data = serviceStatus.Data, Message = serviceStatus.Message, StatusCode = 200, DataStatus = true };
                }
                else
                {
                    return new ApiResponse { Message = serviceStatus.Message, StatusCode = 500, DataStatus = false };
                }
            }
            else
            {
                return new ApiResponse { Message = "Servis Erişim Hatası", StatusCode = 500, DataStatus = false };

            }



        }
        public async Task<ApiResponse> Update(Entity.GlobalTextData entity)
        {
            var searchInContext = await this.globalTextDataService.Get(x => x.Id == entity.Id);

            if (searchInContext.Status == Status.Empty)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 203, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Error)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 500, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Success)
            {
                foreach (var item in searchInContext.Data.GlobalTextDataLanguages)
                {
                    var stat=await this.globalTextDataLanguageService.Delete(item);
                }
                entity.GlobalTextDataLanguages.ForEach(x => x.isActive = true);
                    var orginalUpdate = await this.globalTextDataService.Update(entity);
                    if (orginalUpdate.Status == Core.Util.Enums.Status.Success)
                    {
                        return new ApiResponse { Data = orginalUpdate.Data, Message = orginalUpdate.Message, StatusCode = 200, DataStatus = true };
                    }
                    else
                    {
                        return new ApiResponse { Message = orginalUpdate.Message, StatusCode = 500, DataStatus = false };
                    }
            }
            else
            {
                return new ApiResponse { Message = "Servis Erişim Hatası", StatusCode = 500, DataStatus = false };

            }
        }
        public async Task<ApiResponse> Get(int id)
        {
            var model = await this.globalTextDataService.Get(x => x.Id == id);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200, DataStatus = true };
            }
            else if (model.Status == Status.Empty)
            {
                return new ApiResponse { Message = model.Message, StatusCode = 203, DataStatus = false };
            }
            else
            {
                return new ApiResponse { Message = model.Message, StatusCode = 500, DataStatus = false };
            }

        }
        public async Task<ApiResponse> GetList()
        {
            var model = await this.globalTextDataService.GetList(x => true);
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
