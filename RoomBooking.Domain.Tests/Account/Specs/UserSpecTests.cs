using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomBooking.Domain.Account.Models;
using RoomBooking.Domain.Account.Specs;
using System.Collections.Generic;
using System.Linq;

namespace RoomBooking.Domain.Tests.Account.Specs
{
    [TestClass]
    public class UserSpecTests
    {
        private IQueryable<User> _users;

        public UserSpecTests()
        {
            var users = new List<User>();
            users.Add(new User("marcosbaiao", "marcosbaiao"));

            _users = users.AsQueryable();
        }

        [TestMethod]
        [TestCategory("Account/User - Specifications")]
        public void AuthenticateUserSpecShouldReturnOne()
        {
            var query = UserSpecs.AuthenticateUser("marcosbaiao", "marcosbaiao");
            var count = _users.Where(query).Count();

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        [TestCategory("Account/User - Specifications")]
        public void AuthenticateUserSpecShouldReturnZero()
        {
            var query = UserSpecs.AuthenticateUser("marcosbaiao222", "marcosbaiao");
            var count = _users.Where(query).Count();

            Assert.AreEqual(0, count);
        }
    }
}
