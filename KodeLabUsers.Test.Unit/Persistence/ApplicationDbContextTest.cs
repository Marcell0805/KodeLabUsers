﻿using KodeLabUsers.Persistence;
using NUnit.Framework;

namespace KodeLabUsers.Test.Unit.Persistence
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertCustomerIntoDatabasee()
        {
            using var context = new ApplicationDbContext();
            //var customer = new Customer();
            //context.Customers.Add(customer);
            //Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
        }
    }
}