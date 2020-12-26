using Identity.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace Identity.Models.Context
{
    public class ApiIdentityDbContext : IdentityDbContext<APIUser, APIRole ,int>
    {
        private readonly byte[] _encryptionKey = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
        private readonly byte[] _encryptionIV = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
        private readonly IEncryptionProvider _provider;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
            base.OnModelCreating(modelBuilder);//Bu sadece buraya özel 
           
        }
       
        public ApiIdentityDbContext(DbContextOptions<ApiIdentityDbContext> dbContext) : base(dbContext)
        {
            this._provider = new AesProvider(this._encryptionKey, this._encryptionIV);
        }
    }
}
