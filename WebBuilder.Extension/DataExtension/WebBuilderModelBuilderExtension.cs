using Entity;
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
            IList<Menu> menuList = new List<Menu>();
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
            var slider = new Slider() { Id = 1, InsertedDate = DateTime.Now.Date, isActive = true, isDelete = false,SliderName="AnasayfaSlider",SliderDescription="Bu slider anasayfada bulunur ve dil desteği vardır"};
           



            sliderList.Add(slider);
        


            #endregion

            #region Menu
            #region MainMenu
            var homePageMenuItem1 = new Menu() { Id = 1, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Anasayfa", MenuName = "MainMenu", MenuURL = "/Home/Index" };
            var homePageMenuItem2 = new Menu() { Id = 2, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Kurumsal", MenuName = "MainMenu", MenuURL = "/Home/AboutUS" };
            var homePageMenuItem3 = new Menu() { Id = 3, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Ürünler", MenuName = "MainMenu", MenuURL = "/Home/Product" };
            var homePageMenuItem4 = new Menu() { Id = 4, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Blog", MenuName = "MainMenu", MenuURL = "/Home/Blog" };
            var homePageMenuItem5 = new Menu() { Id = 5, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Hizmetler", MenuName = "MainMenu", MenuURL = "/Home/Services" };
            var homePageMenuItem6 = new Menu() { Id = 6, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "Referans", MenuName = "MainMenu", MenuURL = "/Home/AboutUS#who-work-with-side" };
            var homePageMenuItem7 = new Menu() { Id = 7, InsertedDate = DateTime.Now, LanguageId = 1, isActive = true, isDelete = false, MenuDisplayName = "İletisim", MenuName = "MainMenu", MenuURL = "/Home/ContactUS" };
            
            

            var homePageMenuItem8 = new Menu() { Id = 8, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "Home Page", MenuName = "MainMenu", MenuURL = "/Home/Index" };
            var homePageMenuItem9 = new Menu() { Id = 9, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "About Us", MenuName = "MainMenu", MenuURL = "/Home/AboutUS" };
            var homePageMenuItem10 = new Menu() { Id = 10, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "Products", MenuName = "MainMenu", MenuURL = "/Home/Product" };
            var homePageMenuItem11 = new Menu() { Id = 11, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "Blog", MenuName = "MainMenu", MenuURL = "/Home/Blog" };
            var homePageMenuItem12 = new Menu() { Id = 12, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "Services", MenuName = "MainMenu", MenuURL = "/Home/Services" };
            var homePageMenuItem13 = new Menu() { Id = 13, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "References", MenuName = "MainMenu", MenuURL = "/Home/AboutUS#who-work-with-side" };
            var homePageMenuItem14 = new Menu() { Id = 14, InsertedDate = DateTime.Now, LanguageId = 2, isActive = true, isDelete = false, MenuDisplayName = "Contact Us", MenuName = "MainMenu", MenuURL = "/Home/ContactUs" };
            #endregion
            menuList.Add(homePageMenuItem1);
            menuList.Add(homePageMenuItem2);
            menuList.Add(homePageMenuItem3);
            menuList.Add(homePageMenuItem4);
            menuList.Add(homePageMenuItem5);
            menuList.Add(homePageMenuItem6);
            menuList.Add(homePageMenuItem7);

            menuList.Add(homePageMenuItem8);
            menuList.Add(homePageMenuItem9);
            menuList.Add(homePageMenuItem10);
            menuList.Add(homePageMenuItem11);
            menuList.Add(homePageMenuItem12);
            menuList.Add(homePageMenuItem13);
            menuList.Add(homePageMenuItem14);
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
            var text1Tr = new GlobalTextData() { Id = 1,  InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "specifications-title-text", Value = "Teknik Özellikler", LanguageId=1 };
            var text1En = new GlobalTextData() { Id = 2, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "specifications-title-text", Value = "Specifications", LanguageId=2 };
            var text2Tr = new GlobalTextData() { Id = 3, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "specifications-subtitle-text", Value = "Alt Başlık", LanguageId=1 };
            var text2En = new GlobalTextData() { Id = 4, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "specifications-subtitle-text", Value = "Sub Title", LanguageId=2 };

            var text3Tr = new GlobalTextData() { Id = 5, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title1", Value = "Gelişmiş Ama Basit", LanguageId=1 };
            var text3En = new GlobalTextData() { Id = 6, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title1", Value = "Advanced but Simple", LanguageId=2 };
            var text4Tr = new GlobalTextData() { Id = 7, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle1", Value = "Modern Tasarım", LanguageId = 1 };
            var text4En = new GlobalTextData() { Id = 8, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle1", Value = "Modern Design", LanguageId = 2 };
            var text5Tr = new GlobalTextData() { Id = 9, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text1", Value = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour", LanguageId = 2 };
            var text5En = new GlobalTextData() { Id = 10, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text1", Value = "Lorem Ipsum pasajlarının birçok varyasyonu vardır,ancak çoğu,enjekte edilen mizahla bazı şekillerde değişikliğe uğramıştır.", LanguageId = 1 };

            var text6Tr = new GlobalTextData() { Id = 11, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title2", Value = "En Kullanışlı,En Modern", LanguageId = 1 };
            var text6En = new GlobalTextData() { Id = 12, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title2", Value = "Most Convenient,Most Modern ", LanguageId = 2 };
            var text7Tr = new GlobalTextData() { Id = 13, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle2", Value = "Modern Teknoloji", LanguageId = 1 };
            var text7En = new GlobalTextData() { Id = 14, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle2", Value = "Modern Technology", LanguageId = 2 };
            var text8Tr = new GlobalTextData() { Id = 15, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text2", Value = "Bir okuyucunun, düzenine bakarken bir sayfanın okunabilir içeriğinden rahatsız olacağı uzun süredir bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı", LanguageId = 1 };
            var text8En = new GlobalTextData() { Id = 16, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text2", Value = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum", LanguageId = 2 };

            var text9Tr = new GlobalTextData() { Id = 17, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title3", Value = "Mobil Uyumlu", LanguageId = 1 };
            var text9En = new GlobalTextData() { Id = 18, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title3", Value = "Mobile Compatible ", LanguageId = 2 };
            var text10Tr = new GlobalTextData() { Id = 19, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle3", Value = "Finubus Türkçesi yok", LanguageId = 1 };
            var text10En = new GlobalTextData() { Id = 20, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle3", Value = "Finibus Bonorum", LanguageId = 2 };
            var text11Tr = new GlobalTextData() { Id = 21, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text3", Value = "Onlara layık görüyoruz ve onlar doğrulardan nefret edenleri suçluyorlar,Ama gerçekte ve onların hazzının alçakça zekası bu acıları bozuyor ve onun için sundu.", LanguageId = 1 };
            var text11En = new GlobalTextData() { Id = 22, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text3", Value = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas", LanguageId = 2 };

            var text12Tr = new GlobalTextData() { Id = 23, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title4", Value = "Hepsi Senin", LanguageId = 1 };
            var text12En = new GlobalTextData() { Id = 24, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-title4", Value = "It's All Yours ", LanguageId = 2 };
            var text13Tr = new GlobalTextData() { Id = 25, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle4", Value = "Sizin Domain Adınız", LanguageId = 1 };
            var text13En = new GlobalTextData() { Id = 26, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-subtitle4", Value = "Your Domain Name", LanguageId = 2 };
            var text14Tr = new GlobalTextData() { Id = 27, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text4", Value = "Öte yandan, haklı bir öfkeyle kınıyoruz ve insanların zevkinin cazibesi tarafından bu kadar kandırılan ve morali bozuk olan erkekleri sevmiyoruz.", LanguageId = 1 };
            var text14En = new GlobalTextData() { Id = 28, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "advanced-but-simple-text4", Value = "On the other hand, we denounce with righteous indignation and dislike men who are so beguiled and demoralized by the charms of pleasure of the ", LanguageId = 2 };

            var text15Tr = new GlobalTextData() { Id = 29, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-title", Value = "BİLİM VE MÜHENDİSLİK YOLUYLA YENİLİK", LanguageId = 1 };
            var text15En = new GlobalTextData() { Id = 30, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-title", Value = "Innovation through SCIENCE & ENGINEERING", LanguageId = 2 };
            var text16Tr = new GlobalTextData() { Id = 31, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-text", Value = "Anric teknolojileri, Atomik Katman Biriktirme özelliğine odaklanarak ince film biriktirme alanlarında teknoloji ve yeniliğe odaklanır.", LanguageId = 1 };
            var text16En = new GlobalTextData() { Id = 32, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-text", Value = "Anric technologies focuses on technology and innovation in the areas of thin film deposition with a special focus on Atomic Layer Deposition.", LanguageId = 2 };
            var text17Tr = new GlobalTextData() { Id = 33, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-button-text", Value = "KAYIT OL", LanguageId = 1 };
            var text17En = new GlobalTextData() { Id = 34, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "science-engineering-button-text", Value = "REGİSTER", LanguageId = 2 };
            var text18Tr = new GlobalTextData() { Id = 35, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title", Value = "Siz iyi bir şirketsiniz", LanguageId = 1 };
            var text18En = new GlobalTextData() { Id = 36, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title", Value = "You Are Good Company", LanguageId = 2 };
            var text19Tr = new GlobalTextData() { Id = 37, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title-subtext", Value = "Firma hakkında açıklama", LanguageId = 1 };
            var text19En = new GlobalTextData() { Id = 38, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title-subtext", Value = "Description about your company", LanguageId = 2 };
            var text20Tr = new GlobalTextData() { Id = 39, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title-panel-lamination", Value = "Panel Laminasyonu", LanguageId = 1 };
            var text20En = new GlobalTextData() { Id = 40, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-company-title-panel-lamination", Value = "Panel Lamination", LanguageId = 2 };
            var text21Tr = new GlobalTextData() { Id = 41, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-container-right-content-title", Value = "Fotoğraf Başlık", LanguageId = 1 };
            var text21En = new GlobalTextData() { Id = 42, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-container-right-content-title", Value = "Photo Title", LanguageId = 2 };
            var text22Tr = new GlobalTextData() { Id = 43, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-container-right-content-description", Value = "Fotoğraf Açıklaması", LanguageId = 1 };
            var text22En = new GlobalTextData() { Id = 44, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "you-are-good-container-right-content-description", Value = "Photo Description", LanguageId = 2 };
            var text23Tr = new GlobalTextData() { Id = 45, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "section-references-side", Value = "Referanslar", LanguageId = 1 };
            var text23En = new GlobalTextData() { Id = 46, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "section-references-side", Value = "References", LanguageId = 2 };
            var text24Tr = new GlobalTextData() { Id = 47, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-title", Value = "Ticari Markalarımız", LanguageId = 1 };
            var text24En = new GlobalTextData() { Id = 48, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-title", Value = "Our Trademarkers", LanguageId = 2 };
            var text25Tr = new GlobalTextData() { Id = 49, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-title", Value = "Kart Başlık", LanguageId = 1 };
            var text25En = new GlobalTextData() { Id = 50, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-title", Value = "Card Title", LanguageId = 2 };
            var text26Tr = new GlobalTextData() { Id = 51, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-subtitle", Value = "Kart Alt Başlık", LanguageId = 1 };
            var text26En = new GlobalTextData() { Id = 52, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-subtitle", Value = "Card Subtitle", LanguageId = 2 };
            var text27Tr = new GlobalTextData() { Id = 53, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-description", Value = "Kart Açıklaması", LanguageId = 1 };
            var text27En = new GlobalTextData() { Id = 54, InsertedDate = DateTime.Now, isDelete = false, isActive = true, Key = "our-trademarkers-content-item-description", Value = "Card description", LanguageId = 2 };


            globalTexts.Add(text1Tr);
            globalTexts.Add(text2Tr);
            globalTexts.Add(text3Tr);
            globalTexts.Add(text4Tr);
            globalTexts.Add(text5Tr);
            globalTexts.Add(text6Tr);
            globalTexts.Add(text7Tr);
            globalTexts.Add(text8Tr);
            globalTexts.Add(text9Tr);
            globalTexts.Add(text10Tr);
            globalTexts.Add(text11Tr);
            globalTexts.Add(text12Tr);
            globalTexts.Add(text13Tr);
            globalTexts.Add(text14Tr);
            globalTexts.Add(text15Tr);
            globalTexts.Add(text16Tr);
            globalTexts.Add(text17Tr);
            globalTexts.Add(text18Tr);
            globalTexts.Add(text19Tr);
            globalTexts.Add(text20Tr);
            globalTexts.Add(text21Tr);
            globalTexts.Add(text22Tr);
            globalTexts.Add(text23Tr);
            globalTexts.Add(text24Tr);
            globalTexts.Add(text25Tr);
            globalTexts.Add(text26Tr);
            globalTexts.Add(text27Tr);

            globalTexts.Add(text1En);
            globalTexts.Add(text2En);
            globalTexts.Add(text3En);
            globalTexts.Add(text4En);
            globalTexts.Add(text5En);
            globalTexts.Add(text6En);
            globalTexts.Add(text7En);
            globalTexts.Add(text8En);
            globalTexts.Add(text9En);
            globalTexts.Add(text10En);
            globalTexts.Add(text11En);
            globalTexts.Add(text12En);
            globalTexts.Add(text13En);
            globalTexts.Add(text14En);
            globalTexts.Add(text15En);
            globalTexts.Add(text16En);
            globalTexts.Add(text17En);
            globalTexts.Add(text18En);
            globalTexts.Add(text19En);
            globalTexts.Add(text20En);
            globalTexts.Add(text21En);
            globalTexts.Add(text22En);
            globalTexts.Add(text23En);
            globalTexts.Add(text24En);
            globalTexts.Add(text25En);
            globalTexts.Add(text26En);
            globalTexts.Add(text27En);
            #endregion

            modelBuilder.Entity<PhoneNumber>().HasData(phoneNumbers);
            modelBuilder.Entity<Language>().HasData(languageList);
            modelBuilder.Entity<Slider>().HasData(sliderList);
            modelBuilder.Entity<Menu>().HasData(menuList);
            modelBuilder.Entity<Category>().HasData(categoryList);
            modelBuilder.Entity<Product>().HasData(productList);
            modelBuilder.Entity<Contact>().HasData(contactList);
            modelBuilder.Entity<ContactInformation>().HasData(contactInformationList);
            modelBuilder.Entity<SocialMedia>().HasData(socialMedias);
            modelBuilder.Entity<Location>().HasData(locations);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<GlobalTextData>().HasData(globalTexts);

        }
    }
}
