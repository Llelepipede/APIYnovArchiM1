using APIYnovArchiM1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.data
{
    internal class MockDbContext : ArchiDbContext
    {
        public MockDbContext(DbContextOptions options) : base(options)
        {
        }

        public static MockDbContext GetDbContextUser(bool withData = true) 
        {
            var option = new DbContextOptionsBuilder().UseInMemoryDatabase("dbTest").Options;
            var dbContext = new MockDbContext(option);

            if (withData ) 
            {
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 1, Email="mailuser1@gmail.com",FirstName="premier",LastName = "PREMIER",UserName = "1er"});
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 2, Email="mailuser2@gmail.com",FirstName="deuxieme",LastName = "PREMIER",UserName = "2er"});
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 3, Email="mailuser3@gmail.com",FirstName="troisieme",LastName = "PREMIER",UserName = "3er"});
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 4, Email="mailuser4@gmail.com",FirstName="quatrieme",LastName = "PREMIER",UserName = "4er"});
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 5, Email="mailuser5@gmail.com",FirstName="cinquime",LastName = "PREMIER",UserName = "5er"});
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { ID = 6, Email="mailuser6@gmail.com",FirstName="sixeme",LastName = "PREMIER",UserName = "6er"});
                dbContext.SaveChanges();
            }

            return dbContext;
        }

        public static MockDbContext GetDbContextTag(bool withData = true)
        {
            var option = new DbContextOptionsBuilder().UseInMemoryDatabase("dbTest").Options;
            var dbContext = new MockDbContext(option);

            if (withData)
            {
                dbContext.Tags.Add(new APIYnovArchiM1.Models.Tag { ID = 1 });
                dbContext.Tags.Add(new APIYnovArchiM1.Models.Tag { ID = 2 });
                dbContext.SaveChanges();
            }

            return dbContext;
        }
    }
}
