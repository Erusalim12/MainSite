using Application.Dal;
using Application.Dal.Domain.FeedBack;
using System;
using System.Collections.Generic;

namespace Application.Services.FeedBack.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
