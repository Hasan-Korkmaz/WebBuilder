using Entity;
using Entity.FrontDataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBuilder.Business.Abstract.DataServices;
using static WebBuilder.Core.Util.Enums;

namespace WebBuilder.UserUI.Areas.backofis.Controllers
{
    [Area("backofis")]
    public class LanguageController : Controller
    {
        ILanguageService languageService;
        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }
        public ActionResult Index()
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
        public async Task<ActionResult> Update(int id )
        {
            var searchInContext = await this.languageService.Get(x => x.Id == id);
            if (searchInContext.Status==Status.Success)
            {
                ViewBag.InsertOrUpdate = ViewStatus.Update;
                return View("InsertOrUpdate",searchInContext.Data);
            }
            else
            {
                return StatusCode(404);
            }
         
        }

        [HttpPost]
        public async Task<ApiResponse> Add(Language entity)
        {
            var serviceStatus = await this.languageService.Add(entity);
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
            var searchInContext = await this.languageService.Get(x => x.Id == id);
            if (searchInContext.Status == Status.Empty)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 203,DataStatus=false };
            }
            else if (searchInContext.Status == Status.Error)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 500, DataStatus = false };
            }
            else if (searchInContext.Status==Status.Success)
            {
                var serviceStatus = await this.languageService.Delete(searchInContext.Data);
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
        public async Task<ApiResponse> Update(Language entity)
        {
            var searchInContext = await this.languageService.Get(x => x.Id == entity.Id);
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
                var serviceStatus = await this.languageService.Update(entity);
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
        public async Task<ApiResponse> Get(int id)
        {
            var model = await languageService.Get(x => x.Id==id);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200,DataStatus=true };
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
            var model = await languageService.GetList(x => true);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200, DataStatus = true };
            }
            else
            {
                return new ApiResponse { Message = model.Message, StatusCode = 500, DataStatus = false };
            }

        }
    }
}
