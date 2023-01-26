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

        public static MockDbContext GetDbContext(bool withData = true) 
        {
            var option = new DbContextOptionsBuilder().UseInMemoryDatabase("dbTest").Options;
            var dbContext = new MockDbContext(option);

            if (withData ) 
            {
                dbContext.Users.Add(new APIYnovArchiM1.Models.User { });
                dbContext.SaveChanges();
            }

            return dbContext;
        }
    }
}
