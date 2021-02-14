using Entity.FrontDataTypes;
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
    public class MenuController : Controller
    {
        IMenuService menuService;
        IMenuItemService menuItemService;

        public MenuController(IMenuService menuService,IMenuItemService menuItemService)
        {
            this.menuService = menuService;
            this.menuItemService = menuItemService;
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
            var searchInContext = await this.menuService.Get(x => x.Id == id);
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

        [HttpGet]
        public ActionResult AddMenuItem(int MenuId)
        {
            ViewBag.InsertOrUpdate = ViewStatus.Insert;
            ViewBag.MenuId = MenuId;
            return View("InsertOrUpdateMenuItem");
        }
        [HttpGet]
        public async Task<ActionResult> UpdateMenuItem(int id,int MenuId)
        {
            ViewBag.MenuId = MenuId;
            var searchInContext = await this.menuItemService.Get(x => x.Id == id);
            if (searchInContext.Status == Status.Success)
            {
                ViewBag.InsertOrUpdate = ViewStatus.Update;
                return View("InsertOrUpdateMenuItem", searchInContext.Data);
            }
            else
            {
                return StatusCode(404);
            }

        }
        [HttpGet]
        public ActionResult MenuItems(int Id)
        {
            ViewBag.MenuId = Id;
            return View("MenuItems");
        }


        #region Operations

        [HttpPost]
        public async Task<ApiResponse> Add(Entity.Menu entity)
        {


            var serviceStatus = await this.menuService.Add(entity);
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
            var searchInContext = await this.menuService.Get(x => x.Id == id);
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
                var serviceStatus = await this.menuService.Delete(searchInContext.Data);
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
        public async Task<ApiResponse> Update(Entity.Menu entity)
        {
            var searchInContext = await this.menuService.Get(x => x.Id == entity.Id);

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
                var orginalUpdate = await this.menuService.Update(entity);
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
            var model = await this.menuService.Get(x => x.Id == id);
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
            var model = await this.menuService.GetList(x => true && x.isDelete==false);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200, DataStatus = true };
            }
            else
            {
                return new ApiResponse { Message = model.Message, StatusCode = 500, DataStatus = false };
            }

        }

        [HttpPost]
        public async Task<ApiResponse> MenuItemAdd(Entity.MenuItem entity)
        {


            var serviceStatus = await this.menuItemService.Add(entity);
            if (serviceStatus.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = serviceStatus.Data, Message = serviceStatus.Message, StatusCode = 200 };
            }
            else
            {
                return new ApiResponse { Message = serviceStatus.Message, StatusCode = 500 };

            }
        }
        public async Task<ApiResponse> MenuItemDelete(int id)
        {
            var searchInContext = await this.menuItemService.Get(x => x.Id == id);
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
                var serviceStatus = await this.menuItemService.Delete(searchInContext.Data);
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
        public async Task<ApiResponse> MenuItemUpdate(Entity.MenuItem entity)
        {
            var searchInContext = await this.menuService.Get(x => x.Id == entity.Id);

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
                var orginalUpdate = await this.menuItemService.Update(entity);
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
        public async Task<ApiResponse> GetMenuItems(int Id)
        {
            var model = await this.menuService.GetMenuItems(Id);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                return new ApiResponse { Data = model.Data, Message = model.Message, StatusCode = 200, DataStatus = true };
            }
            else
            {
                return new ApiResponse { Message = model.Message, StatusCode = 500, DataStatus = false };
            }
        }
        [HttpGet]
        public async Task<IEnumerable <Select2Model>> GetMenuItemSelector(int Id,string search)
        {
            var model = await this.menuService.GetMenuItems(Id);
            if (model.Status == Core.Util.Enums.Status.Success)
            {
                if (model.Data.Count>0)
                {
                    if (String.IsNullOrEmpty(search))
                    {
                        var types = model.Data.Select(x => new Select2Model()
                        {
                            id = x.Id,
                            text = x.Name
                        }).ToList();
                        return types;
                    }
                    else
                    { 
                    var types = model.Data.Where(x => x.Name.Contains(search)).Select(x => new Select2Model()
                    {
                        id = x.Id,
                        text = x.Name
                    }).ToList() ;
                        return types;
                    }
               
                }

        
            }
            return null;
        }
        #endregion Operations
    }
}
