using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebBuilder.Business.Abstract;
using WebBuilder.Business.Abstract.DataServices;
using System.Linq;
using System.Linq.Expressions;
using Data.Abstract;

namespace WebBuilder.Business.Concrete
{
    public class UiDataService : IService
    {

        #region Defination
        private readonly ILanguageService languageService;
        private readonly ISliderService sliderService;
        private readonly IMenuService menuService;
        private readonly ICategoryService categoryService;
        private readonly IProductImageService productImageService;
        private readonly IProductService productService;
        private readonly IContactService contactService;
        private readonly IContactInformationService contactInformationService;
        private readonly IProjectService projectService;
        private readonly IServiceService serviceService;
        private readonly IGlobalTextDataService globalTextDataService;

        private string languageString = null;
        #endregion

        #region Constructor
        //public UiDataService() { }
        public UiDataService(
            ILanguageService languageService,
            ISliderService sliderService,
            IMenuService menuService, 
            ICategoryService categoryService,
            IProductImageService productImageService,
            IProductService productService,
            IContactService contactService,
            IContactInformationService contactInformationService,
            IProjectService projectService,
            IServiceService serviceService,
            IGlobalTextDataService globalTextDataService)
        {
            this.languageService = languageService;
            this.sliderService = sliderService;
            this.menuService = menuService;
            this.categoryService = categoryService;
            this.productImageService = productImageService;
            this.productService = productService;
            this.contactService = contactService;
            this.contactInformationService = contactInformationService;
            this.projectService = projectService;
            this.serviceService = serviceService;
            this.globalTextDataService = globalTextDataService;
        }

        #endregion
        public string LanguageConfigure
        {
            get { return languageString; }
            set
            {
                
                    //TODO : Dile göre servisleri configure et
                    this.languageString = value;
                    this.SliderService.Language = value;
                    this.MenuService.Language = value;
                    this.categoryService.Language = value;
                    this.productService.Language = value;
                    this.contactService.Language = value;
                    this.globalTextDataService.Language = value;
                    //this.projectService.Language = value;
                    //KeyPropertieValueService.Language = value;
                

            }
        }


        #region ForUI/UX Designer
        public ILanguageService LanguageService => languageService;
        public ISliderService SliderService => sliderService;
        public IMenuService MenuService => menuService;
        public ICategoryService CategoryService => categoryService;
        public IProductImageService ProductImageService => productImageService;
        public IProductService ProductService => productService;
        public IContactService ContactService => contactService;
        public IContactInformationService ContactInformationService => contactInformationService;
        public IProjectService ProjectService => projectService;
        public IServiceService ServiceService => serviceService;
        public IGlobalTextDataService GlobalTextDataService => globalTextDataService;
        #endregion

    }
}
