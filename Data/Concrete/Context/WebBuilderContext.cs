using Entity;
using Entity.LanguageModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebBuilder.Extension.DataExtension;

namespace Data.Concrete.Context
{
    public class WebBuilderContext : DbContext
    {
        public WebBuilderContext() : base()
        {

        }
        public WebBuilderContext(DbContextOptions option) : base(option)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DeveloperMsSql");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Developer MOCK Data
            modelBuilder.Seed();

        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLanguageMap> CategoryLanguageMap { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<GlobalTextData> GlobalTextDatas { get; set; }
        public DbSet<GlobalTextDataLanguage> GlobalTextDataLanguage { get; set; }

    }
}
