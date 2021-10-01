using Application.Dal.Domain.FeedBack;
using System.Collections.Generic;

namespace Application.Services.FeedBack.Customers
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
    }
}
