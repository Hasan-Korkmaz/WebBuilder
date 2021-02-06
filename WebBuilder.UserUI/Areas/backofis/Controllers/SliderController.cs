using Entity;
using Entity.FrontDataTypes;
using Microsoft.AspNetCore.Hosting;
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
    public class SliderController : Controller
    {
        ISliderService sliderService;
        IHostingEnvironment environment;
        ISliderImageService sliderImageService;
        Core.Util.FileProccesing fileProccesing;

        public SliderController(ISliderService sliderService, ISliderImageService sliderImageService, IHostingEnvironment environment)
        {
            this.sliderService = sliderService;
            this.sliderImageService = sliderImageService;
            this.environment = environment;
            fileProccesing= new Core.Util.FileProccesing();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.InsertOrUpdate = ViewStatus.Insert;
            return  View("InsertOrUpdate");
        }
        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var searchInContext = await this.sliderService.Get(x => x.Id == id);
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
        public async Task<ApiResponse> Add(Slider entity)
        {
            var files = Request.Form.Files;
            int indexer = 0;
            foreach (var item in files)
            {
                var path = environment.WebRootPath + "\\WebBuilderContent\\Images\\Slider";
                var fileName=fileProccesing.WriteFile(environment.WebRootPath + "\\WebBuilderContent\\Images\\Slider", item).Result;
                if (fileName!=null)
                {
                    entity.SliderImages[indexer].ImgLocation ="\\WebBuilderContent\\Images\\Slider\\" + fileName;
                    entity.SliderImages[indexer].InsertedDate = DateTime.Now;
                    entity.SliderImages[indexer].isActive = true;
                    entity.SliderImages[indexer].isDelete = false;
                    entity.SliderImages[indexer].Slider=entity;
                    entity.SliderImages[indexer].DeletedDate=DateTime.MinValue;
                    entity.SliderImages[indexer].UpdatedDate=DateTime.MinValue;
                }
                
                indexer++;
            }
            var serviceStatus = await this.sliderService.Add(entity);
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
            var searchInContext = await this.sliderService.Get(x => x.Id == id);
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
                var serviceStatus = await this.sliderService.Delete(searchInContext.Data);
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
        public async Task<ApiResponse> Update(Slider entity)
        {
            var searchInContext = await this.sliderService.Get(x => x.Id == entity.Id);
           
            if (searchInContext.Status == Status.Empty)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 203, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Error)
            {
                return new ApiResponse { Message = searchInContext.Message, StatusCode = 500, DataStatus = false };
            }
            else if (searchInContext.Status == Status.Success)
            {//Eski Resimleri Temiz
                var sliderTemp = new List<SliderImage>();
               
                //Bu işlemden önce tüm resimleri sil
                //İmgLocation varsa hiçbişey yapılmayacak öylece kalacak
                //İmgLocation yoksa git ekle
                foreach (var item in searchInContext.Data.SliderImages)
                {
                    await sliderImageService.Delete(item);
                }
                if (entity.SliderImages!=null)
                {
                    foreach (var item in entity.SliderImages)
                    {
                        //Resim varsa önceden sildiğim için şimdi yeniden devreye alıyorum
                        if (!string.IsNullOrEmpty(item.ImgLocation))
                        {
                            item.isDelete = false;
                            item.isActive = true;
                            item.UpdatedDate = DateTime.Now;
                        }
                    }
                }
               
                //Yeni resim işlemleri
              
                foreach (var item in entity.SliderImages.Where(x=> x.ImgLocation==null))
                {
                    if (item.Image!=null)
                    {
                        var path = environment.WebRootPath + "\\WebBuilderContent\\Images\\Slider";
                        var fileName = fileProccesing.WriteFile(environment.WebRootPath + "\\WebBuilderContent\\Images\\Slider", item.Image).Result;
                        if (fileName != null)
                        {
                            item.ImgLocation = "\\WebBuilderContent\\Images\\Slider\\" + fileName;
                            item.InsertedDate = DateTime.Now;
                            item.isActive = true;
                            item.isDelete = false;
                            item.Slider = entity;
                            item.DeletedDate = DateTime.MinValue;
                            item.UpdatedDate = DateTime.MinValue;
                            
                        }

                    }

                }
                var serviceStatus = await this.sliderService.Update(entity);
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
            var model = await this.sliderService.Get(x => x.Id == id);
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
            var model = await this.sliderService.GetList(x => true && x.isDelete == false) ;
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
