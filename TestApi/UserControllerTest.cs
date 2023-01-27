using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIYnovArchiM1.Controllers;
using APIYnovArchiM1.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using TestApi.data;

namespace TestApi
{
    internal class UserControllerTest
    {

        private UsersController _usersController;
        private MockDbContext   _dbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContext = MockDbContext.GetDbContextUser();
            _usersController = new UsersController(_dbContext);
        }

        [Test]
        public async Task TestPostUser()
        {
            var actionresult = await _usersController.PutUser(7, new APIYnovArchiM1.Models.User { ID = 7, Email = "mailuser7@gmail.com", FirstName = "sept", LastName = "PREMIER", UserName = "7er" });
            var value = actionresult;

            Assert.IsNotNull(value);
            
        }


        [Test]
        public async Task TestGetUsers()
        {
            var actionresult = await _usersController.GetUsers();
            var value =  actionresult.Value as IEnumerable<User>;
            Assert.IsNotNull(value);
            Assert.That( value.Count(),Is.EqualTo(_dbContext.Users.Count()));
        }

        [Test]
        public async Task TestGetUser()
        {
            int id = 1;
            var actionresult = await _usersController.GetUser(id);
            var value = actionresult.Value as IEnumerable<User>;
            Assert.IsNotNull(value);
            Assert.That(value, Is.EqualTo(_dbContext.Users.ElementAt(id)));
        }

        [Test]
        public async Task TestDeleteUser()
        {
            int id = 1;
            var actionresult = await _usersController.DeleteUser(id);
            var value = actionresult;
            Assert.IsNotNull(value);
        }

        [Test]

        public async Task TestPutUser()
        {
            int id = 1;
            var actionresult = await _usersController.PutUser(id, new APIYnovArchiM1.Models.User { ID = id, Email = "changed_one@gmail.com", FirstName = "premier", LastName = "PREMIER", UserName = "1er" });
            var value = actionresult;
            Assert.IsNotNull(value);
        }

    }
}
