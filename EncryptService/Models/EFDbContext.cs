using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EncryptService.Models
{
    public class EFDbContext : DbContext
    {
        //Подключение к LocalDb
        public EFDbContext():
            base("EFDbContext")
        { }
        //Свйосво доступа к таблице EncryptModels 
        public DbSet<EncryptModel> EncryptModels { get; set; }
        //Свйосво доступа к таблице UserTextModels 
        public DbSet<UserTextModel> UserTextModels { get; set; }
    }
}