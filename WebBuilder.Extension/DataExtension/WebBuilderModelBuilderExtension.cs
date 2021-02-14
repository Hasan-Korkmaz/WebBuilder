using Entity;
using Entity.LanguageModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace WebBuilder.Extension.DataExtension
{
    public static class WebBuilderModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            IList<Language> languageList = new List<Language>();
            IList<Slider> sliderList = new List<Slider>();
            IList<SliderImage> sliderImages = new List<SliderImage>();
            IList<Menu> menuList = new List<Menu>();
            IList<MenuItem> menuItemList = new List<MenuItem>();
            IList<MenuItemLanguage> menuItemLanguageList = new List<MenuItemLanguage>();
            IList<Category> categoryList = new List<Category>();
            IList<Product> productList = new List<Product>();
            IList<Contact> contactList = new List<Contact>();
            IList<ContactInformation> contactInformationList = new List<ContactInformation>();
            IList<Project> projectList = new List<Project>();
            IList<Service> serviceList = new List<Service>();
            IList<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            IList<SocialMedia> socialMedias = new List<SocialMedia>();
            IList<Location> locations = new List<Location>();
            IList<Project> projects = new List<Project>();
            IList<GlobalTextData> globalTexts = new List<GlobalTextData>();
            IList<GlobalTextDataLanguage> globalTextLanguageList = new List<GlobalTextDataLanguage>();

            var webBuilderContentDirectoryImage = "/WebBuilderContent/Images/";
            var sliderPath = webBuilderContentDirectoryImage + "Slider/";
            var productPath = webBuilderContentDirectoryImage + "Product/";

            #region Language
            var turkish = new Language() { Id = 1, Name = "Turkish", ShortName = "tr-TR", InsertedDate = DateTime.Now.Date, isActive = true, isDelete = false };
            var english = new Language() { Id = 2, Name = "English", ShortName = "en-US", InsertedDate = DateTime.Now.Date, isActive = true, isDelete = false };
            languageList.Add(turkish);
            languageList.Add(english);
            #endregion

            #region Slider
            var slider = new Slider() { Id = 1, InsertedDate = DateTime.Now.Date, isActive = true, isDelete = false,SliderName="AnasayfaSlider",SliderDescription="Bu slider anasayfada bulunur ve dil desteği vardır",SliderTag="Anasayfa Slayt"};

         

            sliderList.Add(slider);



            #endregion

            #region SliderImg

            var sliderImgOne = new SliderImage() { Id = 1, ImgLocation = @"\WebBuilderContent\Images\Slider\384182b3-ce92-4d7d-9db7-a6ad9c3066a0.png", AltValue = "Metal işleme", Order = 1, isActive = true, isDelete = false, InsertedDate = DateTime.Now, SliderId = 1 };
            var sliderImgTwo = new SliderImage() { Id = 2, ImgLocation = @"\WebBuilderContent\Images\Slider\811b7ad3-9c76-4946-9bfc-00c19dd1166f.jpg", AltValue = "Metal İşleme SEO", Order = 2, isActive = true, isDelete = false, InsertedDate = DateTime.Now, SliderId = 1 };

            sliderImages.Add(sliderImgOne);
            sliderImages.Add(sliderImgTwo);
            #endregion

            #region Menu
            #region MainMenu
            var homePageMenu = new Menu() { Id = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false,Tag="MainMenu",  Name = "Anasayfa Menüsü", Description = "Bu açıklama Seed'de otomatik olarak oluşturuldu." };

            var homePageMenuItem1 = new MenuItem() { Id = 1,Name="Anasayfa", MenuId=1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/Index" };
            var homePageMenuItemTR = new MenuItemLanguage() { Id = 1, LanguageId=1,MenuItemId=1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Anasayfa" };
            var homePageMenuItemEN = new MenuItemLanguage() { Id = 2,LanguageId=2,MenuItemId=1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Homepage" };

            var homePageMenuItem2 = new MenuItem() { Id = 2, Name = "Hakkımızda", MenuId = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/AboutUS" };
            var homePageMenuItem2TR = new MenuItemLanguage() { Id = 3, LanguageId = 1, MenuItemId = homePageMenuItem2.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Kurumsal" };
            var homePageMenuItem2EN = new MenuItemLanguage() { Id = 4, LanguageId = 2, MenuItemId = homePageMenuItem2.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "AboutUS" };

            var homePageMenuItem3 = new MenuItem() { Id = 3, Name = "Ürünler", MenuId = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/Product" };
            var homePageMenuItem3TR = new MenuItemLanguage() { Id = 5, LanguageId = 1, MenuItemId = homePageMenuItem3.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Ürünler" };
            var homePageMenuItem3EN = new MenuItemLanguage() { Id = 6, LanguageId = 2, MenuItemId = homePageMenuItem3.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Products" };

            var homePageMenuItem4 = new MenuItem() { Id = 4, Name = "Blog", MenuId = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/Blog" };
            var homePageMenuItem4TR = new MenuItemLanguage() { Id = 7, LanguageId = 1, MenuItemId = homePageMenuItem4.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Blog" };
            var homePageMenuItem4EN = new MenuItemLanguage() { Id = 8, LanguageId = 2, MenuItemId = homePageMenuItem4.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Blog" };


            var homePageMenuItem5 = new MenuItem() { Id = 5, Name = "Hizmetler", MenuId = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/Services" };
            var homePageMenuItem5TR = new MenuItemLanguage() { Id = 9, LanguageId = 1, MenuItemId = homePageMenuItem5.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Hizmetler" };
            var homePageMenuItem5EN = new MenuItemLanguage() { Id = 10, LanguageId = 2, MenuItemId = homePageMenuItem5.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Services" };

            var homePageMenuItem6 = new MenuItem() { Id = 6, MenuId = 1, Name = "Referans", InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/AboutUS#who-work-with-side" };
            var homePageMenuItem6TR = new MenuItemLanguage() { Id = 11, LanguageId = 1, MenuItemId = homePageMenuItem6.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "Referans" };
            var homePageMenuItem6EN = new MenuItemLanguage() { Id = 12, LanguageId = 2, MenuItemId = homePageMenuItem6.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "References" };



            var homePageMenuItem7 = new MenuItem() { Id = 7, MenuId = 1, Name = "İletişim", InsertedDate = DateTime.Now, isActive = true, isDelete = false, Url = "/Home/ContactUs" };
            var homePageMenuItem7TR = new MenuItemLanguage() { Id = 13, LanguageId = 1, MenuItemId = homePageMenuItem7.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "İletişim" };
            var homePageMenuItem7EN = new MenuItemLanguage() { Id = 14, LanguageId = 2, MenuItemId = homePageMenuItem7.Id, InsertedDate = DateTime.Now, isActive = true, isDelete = false, DisplayName = "ContactUS" };


            #endregion
            menuList.Add(homePageMenu);
            menuItemList.Add(homePageMenuItem1);
            menuItemList.Add(homePageMenuItem2);
            menuItemList.Add(homePageMenuItem3);
            menuItemList.Add(homePageMenuItem4);
            menuItemList.Add(homePageMenuItem5);
            menuItemList.Add(homePageMenuItem6);
            menuItemList.Add(homePageMenuItem7);
            menuItemLanguageList.Add(homePageMenuItemTR);
            menuItemLanguageList.Add(homePageMenuItemEN);
            menuItemLanguageList.Add(homePageMenuItem2TR);
            menuItemLanguageList.Add(homePageMenuItem2EN);
            menuItemLanguageList.Add(homePageMenuItem3TR);
            menuItemLanguageList.Add(homePageMenuItem3EN);
            menuItemLanguageList.Add(homePageMenuItem4TR);
            menuItemLanguageList.Add(homePageMenuItem4EN);
            menuItemLanguageList.Add(homePageMenuItem5TR);
            menuItemLanguageList.Add(homePageMenuItem5EN);
            menuItemLanguageList.Add(homePageMenuItem6TR);
            menuItemLanguageList.Add(homePageMenuItem6EN);
            menuItemLanguageList.Add(homePageMenuItem7TR);
            menuItemLanguageList.Add(homePageMenuItem7EN);
            #endregion

            #region Category
            var categoryTr1 = new Category() { Id = 1,  CategoryName = "Akü", InsertedDate = DateTime.Now, isActive = true,  Description = "Sürdürülebilir bir geleceğe yatırım yaparak müşterilerin tercih edilen enerji depolama tedarikçisi olmak, kurum kültür ve değerlerimizi nesilden nesile aktararak tüm paydaşlarımıza katkıda bulunmak." };

              var categoryTr2 = new Category() { Id = 3, CategoryName = "Yedek Parça", InsertedDate = DateTime.Now, isActive = true, Description = "Otomotiv Yedek Parçası" };

              var categoryTr3 = new Category() { Id = 5,  CategoryName = "Üst Menü", InsertedDate = DateTime.Now, isActive = true, Description = "Üst Menü Deneme" };

              var categoryTr4 = new Category() { Id = 7, CategoryName = "Alt Menü 1 ", TopCategoryId=5, InsertedDate = DateTime.Now, isActive = true,  Description = "Alt Kategori Test" };

              var categoryTr5 = new Category() { Id = 9,  CategoryName = "Alt Menü 2 ", TopCategoryId=5, InsertedDate = DateTime.Now, isActive = true,  Description = "Alt Kategori Test" };

              var categoryTr6 = new Category() { Id = 11, CategoryName = "Alt Menü 3 ", TopCategoryId = 9, InsertedDate = DateTime.Now, isActive = true,  Description = "Alt Kategori Test" };



              categoryList.Add(categoryTr1);
              categoryList.Add(categoryTr2);
              categoryList.Add(categoryTr3);
              categoryList.Add(categoryTr4);
              categoryList.Add(categoryTr5);
              categoryList.Add(categoryTr6);


            #endregion

            #region Product
            var productTr1 = new Product() { Id = 1, CategoryId = 1, LanguageId = 1, InsertedDate = DateTime.Now, isActive = true, Name = "Mutlu Akü", Price = 35, Stock = 50, UnitType = Core.Util.Enums.UnitType.Piece, Description = "Yeni Nesil Mutlu Akü" };
            var productEn1 = new Product() { Id = 2, CategoryId = 1, LanguageId = 2, InsertedDate = DateTime.Now, isActive = true, Name = "Mutlu Battery", Price = 35, Stock = 50, UnitType = Core.Util.Enums.UnitType.Piece, Description = "New generation Mutlu battery" };
            var productTr2 = new Product() { Id = 3, CategoryId = 1, LanguageId = 1, InsertedDate = DateTime.Now, isActive = true, Name = "Çelik Akü", Price = 60, Stock = 10, UnitType = Core.Util.Enums.UnitType.Piece, Description = "60 AMP Çelik Akü" };
            var productEn2 = new Product() { Id = 4, CategoryId =1, LanguageId = 2, InsertedDate = DateTime.Now, isActive = true, Name = "Çelik Battery", Price = 60, Stock = 10, UnitType = Core.Util.Enums.UnitType.Piece, Description = "Çelik Battery" };
            productList.Add(productTr1);
            productList.Add(productTr2);
            productList.Add(productEn1);
            productList.Add(productEn2);
            #endregion

            #region Contact
            var contactItem1 = new Contact() { Id = 1, InsertedDate = DateTime.Now, IsRead = false, isDelete = false, isActive = true, Email = "hasankorkmazdev@gmail.com", NameSurname = "Hasan Korkmaz", Content = "TEST TEST TEST", Subject = "Insert Test", Phone = "+90 507 575 1463" };



            contactList.Add(contactItem1);
            #endregion
            
            #region ContactInformation
            var contactInformationItem1 = new ContactInformation() { Id = 1, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Mail = "gizemgok@gmail.com",  Adress = "Bosna Hersek Mh." };
            
            contactInformationList.Add(contactInformationItem1);
            #endregion

            #region PhoneNumbers
            var number1 = new PhoneNumber() { Id=1, InsertedDate = DateTime.Now,  isActive = true, isDelete = false, Name = "CEP", Number = "05555555555", ContactInformationId = contactInformationItem1.Id };
            phoneNumbers.Add(number1);
            #endregion

            #region Social Medias
            var socialMedia1 = new SocialMedia() { Id = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Name = "Facebook", Url="facebook.com", ContactInformationId = contactInformationItem1.Id };
            socialMedias.Add(socialMedia1);
            #endregion

            #region Location
            var location1 = new Location() { Id = 1, InsertedDate = DateTime.Now, isActive = true, isDelete = false, Latitude=38.0286307, Longitude= 32.5071287, Zoom=16.5, ContactInformationId = contactInformationItem1.Id };
            locations.Add(location1);
            #endregion

            #region Project
            var projectItem1 = new Project() { Id = 1, InsertedDate = DateTime.Now, isDelete = false, isActive = true, ProjectName = "WebBuilder", ProjectContent = "Deneme" };
            projectList.Add(projectItem1);
            #endregion

            #region Service
            var serviceItem1 = new Service() { Id = 1, InsertedDate = DateTime.Now, isDelete = false, isActive = true, ServiceName = "SEO Service", ServiceContent = "Deneme" };
            serviceList.Add(serviceItem1);
            #endregion

            #region GlobalTexts
            
            var text1 = new GlobalTextData() { Id = 1,  InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "specifications-title-text", Name="Özellikler Başlık" };
            var text1TR = new GlobalTextDataLanguage() { Id = 1, GlobalTextDataId = text1.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Teknik Özellikler", LanguageId = 1 };
            var text1EN = new GlobalTextDataLanguage() { Id = 2, GlobalTextDataId = text1.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Specifications", LanguageId = 2 };

            var text2 = new GlobalTextData() { Id = 2, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "specifications-subtitle-text", Name = "Özellikler Alt Başlık" };
            var text2TR = new GlobalTextDataLanguage() { Id = 3, GlobalTextDataId = text2.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Detaylar", LanguageId = 1 };
            var text2EN = new GlobalTextDataLanguage() { Id = 4, GlobalTextDataId = text2.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Details", LanguageId = 2 };

            var text3 = new GlobalTextData() { Id = 3, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-title1", Name = "1-)Geliş ama basit Ana Başlık" };
            var text3TR = new GlobalTextDataLanguage() { Id = 5, GlobalTextDataId = text3.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Gelişmiş Ama Basit", LanguageId = 1 };
            var text3EN = new GlobalTextDataLanguage() { Id = 6, GlobalTextDataId = text3.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Advanced but Simple", LanguageId = 2 };

            var text4 = new GlobalTextData() { Id = 4, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-subtitle1", Name = "1-)Geliş ama basit Alt Başlık" };
            var text4TR = new GlobalTextDataLanguage() { Id = 7, GlobalTextDataId = text4.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Modern Tasarım", LanguageId = 1 };
            var text4EN = new GlobalTextDataLanguage() { Id = 8, GlobalTextDataId = text4.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Modern Design", LanguageId = 2 };

            var text5 = new GlobalTextData() { Id = 5, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-text1", Name = "1-)Geliş ama basit Açıklama" };
            var text5TR = new GlobalTextDataLanguage() { Id = 9, GlobalTextDataId = text5.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Lorem Ipsum pasajlarının birçok varyasyonu vardır, ancak çoğu, enjekte edilen mizahla bazı şekillerde değişikliğe uğramıştır.", LanguageId = 1 };
            var text5EN = new GlobalTextDataLanguage() { Id = 10, GlobalTextDataId = text5.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour", LanguageId = 2 };


            var text6 = new GlobalTextData() { Id = 6, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-title2", Name = "2-)En Kullanışlı En Modern Ana Başlık" };
            var text6TR = new GlobalTextDataLanguage() { Id = 11, GlobalTextDataId = text6.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "En Kullanışlı,En Modern", LanguageId = 1 };
            var text6EN = new GlobalTextDataLanguage() { Id = 12, GlobalTextDataId = text6.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Most Convenient,Most Modern", LanguageId = 2 };

            var text7 = new GlobalTextData() { Id = 7, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-subtitle2", Name = "2-)En Kullanışlı En Modern  Alt Başlık" };
            var text7TR = new GlobalTextDataLanguage() { Id = 13, GlobalTextDataId = text7.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Modern Teknoloji", LanguageId = 1 };
            var text7EN = new GlobalTextDataLanguage() { Id = 14, GlobalTextDataId = text7.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Modern Technology", LanguageId = 2 };

            var text8 = new GlobalTextData() { Id = 8, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-text2", Name = "2-)En Kullanışlı En Modern Açıklama" };
            var text8TR = new GlobalTextDataLanguage() { Id = 15, GlobalTextDataId = text8.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Bir okuyucunun, düzenine bakarken bir sayfanın okunabilir içeriğinden rahatsız olacağı uzun süredir bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı", LanguageId = 1 };
            var text8EN = new GlobalTextDataLanguage() { Id = 16, GlobalTextDataId = text8.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum", LanguageId = 2 };


            var text9 = new GlobalTextData() { Id = 9, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-title3", Name = "3-)Mobil Uyumlu Ana Başlık" };
            var text9TR = new GlobalTextDataLanguage() { Id = 17, GlobalTextDataId = text9.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Mobil Uyumlu", LanguageId = 1 };
            var text9EN = new GlobalTextDataLanguage() { Id = 18, GlobalTextDataId = text9.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Mobile Compatible", LanguageId = 2 };

            var text10 = new GlobalTextData() { Id = 10, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-subtitle3", Name = "3-)Mobil Uyumlu  Alt Başlık" };
            var text10TR = new GlobalTextDataLanguage() { Id = 19, GlobalTextDataId = text10.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Finubus Türkçesi yok", LanguageId = 1 };
            var text10EN = new GlobalTextDataLanguage() { Id = 20, GlobalTextDataId = text10.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Finibus Bonorum", LanguageId = 2 };

            var text11 = new GlobalTextData() { Id = 11, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-text3", Name = "3-)Mobil Uyumlu Açıklama" };
            var text11TR = new GlobalTextDataLanguage() { Id = 21, GlobalTextDataId = text11.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Onlara layık görüyoruz ve onlar doğrulardan nefret edenleri suçluyorlar,Ama gerçekte ve onların hazzının alçakça zekası bu acıları bozuyor ve onun için sundu.", LanguageId = 1 };
            var text11EN = new GlobalTextDataLanguage() { Id = 22, GlobalTextDataId = text11.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas", LanguageId = 2 };


            var text12 = new GlobalTextData() { Id = 12, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-title4", Name = "4-)Hepsi Senin Ana Başlık" };
            var text12TR = new GlobalTextDataLanguage() { Id = 23, GlobalTextDataId = text12.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Hepsi Senin", LanguageId = 1 };
            var text12EN = new GlobalTextDataLanguage() { Id = 24, GlobalTextDataId = text12.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "It's All Yours", LanguageId = 2 };

            var text13 = new GlobalTextData() { Id = 13, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-subtitle4", Name = "4-)Hepsi Senin  Alt Başlık" };
            var text13TR = new GlobalTextDataLanguage() { Id = 25, GlobalTextDataId = text13.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Sizin Domain Adınız", LanguageId = 1 };
            var text13EN = new GlobalTextDataLanguage() { Id = 26, GlobalTextDataId = text13.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Your Domain Name", LanguageId = 2 };

            var text14 = new GlobalTextData() { Id = 14, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "advanced-but-simple-text4", Name = "4-)Hepsi Senin Açıklama" };
            var text14TR = new GlobalTextDataLanguage() { Id = 27, GlobalTextDataId = text14.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Öte yandan, haklı bir öfkeyle kınıyoruz ve insanların zevkinin cazibesi tarafından bu kadar kandırılan ve morali bozuk olan erkekleri sevmiyoruz.", LanguageId = 1 };
            var text14EN = new GlobalTextDataLanguage() { Id = 28, GlobalTextDataId = text14.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the ", LanguageId = 2 };



            var text15 = new GlobalTextData() { Id = 15, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "science-engineering-title", Name = "BİLİM VE MÜHENDİSLİK YOLUYLA YENİLİK başlık" };
            var text15TR = new GlobalTextDataLanguage() { Id = 29, GlobalTextDataId = text15.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "BİLİM VE MÜHENDİSLİK YOLUYLA YENİLİK", LanguageId = 1 };
            var text15EN = new GlobalTextDataLanguage() { Id = 30, GlobalTextDataId = text15.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Innovation through SCIENCE & ENGINEERING", LanguageId = 2 };

            var text16 = new GlobalTextData() { Id = 16, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "science-engineering-text", Name = "BİLİM VE MÜHENDİSLİK YOLUYLA YENİLİK Açıklama" };
            var text16TR = new GlobalTextDataLanguage() { Id = 31, GlobalTextDataId = text16.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Anric teknolojileri, Atomik Katman Biriktirme özelliğine odaklanarak ince film biriktirme alanlarında teknoloji ve yeniliğe odaklanır.", LanguageId = 1 };
            var text16EN = new GlobalTextDataLanguage() { Id = 32, GlobalTextDataId = text16.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "IAnric technologies focuses on technology and innovation in the areas of thin film deposition with a special focus on Atomic Layer Deposition.", LanguageId = 2 };


            var text17 = new GlobalTextData() { Id = 17, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "science-engineering-button-text", Name = "KAYIT OL -Button" };
            var text17TR = new GlobalTextDataLanguage() { Id = 33, GlobalTextDataId = text17.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "KAYIT OL", LanguageId = 1 };
            var text17EN = new GlobalTextDataLanguage() { Id = 34, GlobalTextDataId = text17.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "REGİSTER", LanguageId = 2 };


            var text18 = new GlobalTextData() { Id = 18, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "you-are-good-company-title", Name = "Siz iyi bir şirketsiniz -Text" };
            var text18TR = new GlobalTextDataLanguage() { Id = 35, GlobalTextDataId = text18.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Siz iyi bir şirketsiniz", LanguageId = 1 };
            var text18EN = new GlobalTextDataLanguage() { Id = 36, GlobalTextDataId = text18.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "You Are Good Company", LanguageId = 2 };


            var text19 = new GlobalTextData() { Id = 19, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "you-are-good-company-title-subtext", Name = "Siz iyi bir şirketsiniz  -Alt Başlık" };
            var text19TR = new GlobalTextDataLanguage() { Id = 37, GlobalTextDataId = text19.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Firma hakkında açıklama", LanguageId = 1 };
            var text19EN = new GlobalTextDataLanguage() { Id = 38, GlobalTextDataId = text19.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Description about your company", LanguageId = 2 };

            var text20 = new GlobalTextData() { Id = 20, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "you-are-good-company-title-panel-lamination", Name = "Panel Laminasyon -Text" };
            var text20TR = new GlobalTextDataLanguage() { Id = 39, GlobalTextDataId = text20.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Panel Laminasyon", LanguageId = 1 };
            var text20EN = new GlobalTextDataLanguage() { Id = 40, GlobalTextDataId = text20.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Panel Lamination", LanguageId = 2 };

            var text21 = new GlobalTextData() { Id = 21, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "you-are-good-container-right-content-title", Name = "Anasayfa Fotoğraf Başlık -Başlık" };
            var text21TR = new GlobalTextDataLanguage() { Id = 41, GlobalTextDataId = text21.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Fotoğraf Başlık", LanguageId = 1 };
            var text21EN = new GlobalTextDataLanguage() { Id = 42, GlobalTextDataId = text21.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Photo Title", LanguageId = 2 };

            var text22 = new GlobalTextData() { Id = 22, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "you-are-good-container-right-content-description", Name = "Anasayfa Fotoğraf Açıklama -Text" };
            var text22TR = new GlobalTextDataLanguage() { Id = 43, GlobalTextDataId = text22.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Fotoğraf Açıklaması", LanguageId = 1 };
            var text22EN = new GlobalTextDataLanguage() { Id = 44, GlobalTextDataId = text22.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Photo Description", LanguageId = 2 };

            var text23 = new GlobalTextData() { Id = 23, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "section-references-side", Name = "Referanslar -Text" };
            var text23TR = new GlobalTextDataLanguage() { Id = 45, GlobalTextDataId = text23.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Referanslar", LanguageId = 1 };
            var text23EN = new GlobalTextDataLanguage() { Id = 46, GlobalTextDataId = text23.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Photo Description", LanguageId = 2 };


            var text24 = new GlobalTextData() { Id = 24, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "our-trademarkers-title", Name = "Ticari Markalarımız -Text" };
            var text24TR = new GlobalTextDataLanguage() { Id = 47, GlobalTextDataId = text24.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Ticari Markalarımız", LanguageId = 1 };
            var text24EN = new GlobalTextDataLanguage() { Id = 48, GlobalTextDataId = text24.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Our Trademarker", LanguageId = 2 };


            var text25 = new GlobalTextData() { Id = 25, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "our-trademarkers-content-item-title", Name = "Kart Başlık -Başlık" };
            var text25TR = new GlobalTextDataLanguage() { Id = 49, GlobalTextDataId = text25.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Kart Başlık", LanguageId = 1 };
            var text25EN = new GlobalTextDataLanguage() { Id = 50, GlobalTextDataId = text25.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Card Title", LanguageId = 2 };


            var text26 = new GlobalTextData() { Id = 26, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "our-trademarkers-content-item-subtitle", Name = "Kart Alt Başlık -Alt Başlık" };
            var text26TR = new GlobalTextDataLanguage() { Id = 51, GlobalTextDataId = text26.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Kart Alt Başlık", LanguageId = 1 };
            var text26EN = new GlobalTextDataLanguage() { Id = 52, GlobalTextDataId = text26.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Card Subtitle", LanguageId = 2 };

            var text27 = new GlobalTextData() { Id = 27, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Tag = "our-trademarkers-content-item-description", Name = "Kart Açıklaması -Text" };
            var text27TR = new GlobalTextDataLanguage() { Id = 53, GlobalTextDataId = text27.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Kart Açıklaması", LanguageId = 1 };
            var text27EN = new GlobalTextDataLanguage() { Id = 54, GlobalTextDataId = text27.Id, isDelete = false, isActive = true, InsertedDate = DateTime.Now, Value = "Card description", LanguageId = 2 };



            globalTexts.Add(text1);
            globalTexts.Add(text2);
            globalTexts.Add(text3);
            globalTexts.Add(text4);
            globalTexts.Add(text5);
            globalTexts.Add(text6);
            globalTexts.Add(text7);
            globalTexts.Add(text8);
            globalTexts.Add(text9);
            globalTexts.Add(text10);
            globalTexts.Add(text11);
            globalTexts.Add(text12);
            globalTexts.Add(text13);
            globalTexts.Add(text14);
            globalTexts.Add(text15);
            globalTexts.Add(text16);
            globalTexts.Add(text17);
            globalTexts.Add(text18);
            globalTexts.Add(text19);
            globalTexts.Add(text20);
            globalTexts.Add(text21);
            globalTexts.Add(text22);
            globalTexts.Add(text23);
            globalTexts.Add(text24);
            globalTexts.Add(text25);
            globalTexts.Add(text26);
            globalTexts.Add(text27);

            globalTextLanguageList.Add(text1EN);
            globalTextLanguageList.Add(text2EN);
            globalTextLanguageList.Add(text3EN);
            globalTextLanguageList.Add(text4EN);
            globalTextLanguageList.Add(text5EN);
            globalTextLanguageList.Add(text6EN);
            globalTextLanguageList.Add(text7EN);
            globalTextLanguageList.Add(text8EN);
            globalTextLanguageList.Add(text9EN);
            globalTextLanguageList.Add(text10EN);
            globalTextLanguageList.Add(text11EN);
            globalTextLanguageList.Add(text12EN);
            globalTextLanguageList.Add(text13EN);
            globalTextLanguageList.Add(text14EN);
            globalTextLanguageList.Add(text15EN);
            globalTextLanguageList.Add(text16EN);
            globalTextLanguageList.Add(text17EN);
            globalTextLanguageList.Add(text18EN);
            globalTextLanguageList.Add(text19EN);
            globalTextLanguageList.Add(text20EN);
            globalTextLanguageList.Add(text21EN);
            globalTextLanguageList.Add(text22EN);
            globalTextLanguageList.Add(text23EN);
            globalTextLanguageList.Add(text24EN);
            globalTextLanguageList.Add(text25EN);
            globalTextLanguageList.Add(text26EN);
            globalTextLanguageList.Add(text27EN);
            globalTextLanguageList.Add(text1TR);
            globalTextLanguageList.Add(text2TR);
            globalTextLanguageList.Add(text3TR);
            globalTextLanguageList.Add(text4TR);
            globalTextLanguageList.Add(text5TR);
            globalTextLanguageList.Add(text6TR);
            globalTextLanguageList.Add(text7TR);
            globalTextLanguageList.Add(text8TR);
            globalTextLanguageList.Add(text9TR);
            globalTextLanguageList.Add(text10TR);
            globalTextLanguageList.Add(text11TR);
            globalTextLanguageList.Add(text12TR);
            globalTextLanguageList.Add(text13TR);
            globalTextLanguageList.Add(text14TR);
            globalTextLanguageList.Add(text15TR);
            globalTextLanguageList.Add(text16TR);
            globalTextLanguageList.Add(text17TR);
            globalTextLanguageList.Add(text18TR);
            globalTextLanguageList.Add(text19TR);
            globalTextLanguageList.Add(text20TR);
            globalTextLanguageList.Add(text21TR);
            globalTextLanguageList.Add(text22TR);
            globalTextLanguageList.Add(text23TR);
            globalTextLanguageList.Add(text24TR);
            globalTextLanguageList.Add(text25TR);
            globalTextLanguageList.Add(text26TR);
            globalTextLanguageList.Add(text27TR);
            #endregion

            modelBuilder.Entity<PhoneNumber>().HasData(phoneNumbers);
            modelBuilder.Entity<Language>().HasData(languageList);
            modelBuilder.Entity<Slider>().HasData(sliderList);
            modelBuilder.Entity<SliderImage>().HasData(sliderImages);
            modelBuilder.Entity<Menu>().HasData(menuList);
            modelBuilder.Entity<MenuItem>().HasData(menuItemList);
            modelBuilder.Entity<MenuItemLanguage>().HasData(menuItemLanguageList);
            modelBuilder.Entity<Category>().HasData(categoryList);
            modelBuilder.Entity<Product>().HasData(productList);
            modelBuilder.Entity<Contact>().HasData(contactList);
            modelBuilder.Entity<ContactInformation>().HasData(contactInformationList);
            modelBuilder.Entity<SocialMedia>().HasData(socialMedias);
            modelBuilder.Entity<Location>().HasData(locations);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<GlobalTextData>().HasData(globalTexts);
            modelBuilder.Entity<GlobalTextDataLanguage>().HasData(globalTextLanguageList);

        }
    }
}
