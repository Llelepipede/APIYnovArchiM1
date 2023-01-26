using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIYnovArchiM1.Controllers;
using APIYnovArchiM1.Models;
using TestApi.data;

namespace TestApi
{
    internal class UserControllerTest
    {

        private UsersController _usersController;
        private MockDbContext   _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = MockDbContext.GetDbContext();
            _usersController = new UsersController(_dbContext);
        }

        [Test]
        public async Task TestGetUsers()
        {
            var actionresult = await _usersController.GetUsers();
            var value =  actionresult.Value as IEnumerable<User>;

            Assert.AreEqual(_dbContext.Users.Count(),value.Count());
        }
    }
}
