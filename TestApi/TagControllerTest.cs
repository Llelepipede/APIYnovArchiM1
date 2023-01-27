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
    internal class TagControllerTest
    {

        private TagController _tagController;
        private MockDbContext   _dbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContext = MockDbContext.GetDbContextTag();
            _tagController = new TagController(_dbContext);
        }

        [Test]
        public async Task TestPostTag()
        {
            var actionresult = await _tagController.PutTag(7, new APIYnovArchiM1.Models.Tag { ID = 7});
            var value = actionresult;

            Assert.IsNotNull(value);
            
        }


        [Test]
        public async Task TestGetTags()
        {
            var actionresult = await _tagController.GetTags();
            var value =  actionresult.Value as IEnumerable<Tag>;
            Assert.IsNotNull(value);
            Assert.That( value.Count(),Is.EqualTo(_dbContext.Tags.Count()));
        }

        [Test]
        public async Task TestGetTag()
        {
            int id = 1;
            var actionresult = await _tagController.GetTag(id);
            var value = actionresult.Value as IEnumerable<Tag>;
            Assert.IsNotNull(value);
            Assert.That(value, Is.EqualTo(_dbContext.Tags.ElementAt(id)));
        }

        [Test]
        public async Task TestDeleteTag()
        {
            int id = 1;
            var actionresult = await _tagController.DeleteTag(id);
            var value = actionresult;
            Assert.IsNotNull(value);
        }

        [Test]

        public async Task TestPutTag()
        {
            int id = 1;
            var actionresult = await _tagController.PutTag(id, new APIYnovArchiM1.Models.Tag { ID = id });
            var value = actionresult;
            Assert.IsNotNull(value);
        }

    }
}
