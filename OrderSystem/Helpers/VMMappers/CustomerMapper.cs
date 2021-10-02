using ModelsPackage;
using OrderSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Helpers.VMMappers
{
    public static class CustomerMapper
    {
        public static IEnumerable<CustomerVM> MappToCustomerVMList(IList<Customers> customers)
        {
            var customersVMList = new List<CustomerVM>();

            for (int i = 0; i < customers.Count(); i++)
            {
                customersVMList.Add(MappToCumsterVM(customers[i]));
            }
            return customersVMList;
        }

        public static CustomerVM MappToCumsterVM(Customers customer)
        {
            return new CustomerVM
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                RegisteredForNewsLetter = customer.RegisteredForNewsLetter
            };
        }
    }
}
