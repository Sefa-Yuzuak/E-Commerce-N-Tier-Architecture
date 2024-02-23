using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericReporstory<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerWithJob()
        {
            using(var c = new Context())
            {
                return c.Customers.Include(x => x.Job).ToList();
            }
        }
    }
}
