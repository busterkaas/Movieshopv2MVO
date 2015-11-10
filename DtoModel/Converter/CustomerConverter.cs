using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDAL.BE;

namespace DtoModel.Converter
{
    class CustomerConverter : AbstractDtoConverter<Customer, CustomerDTO>
    {
        public override CustomerDTO Convert(Customer item)
        {
            var CustomerDto = new CustomerDTO()
            {
                City = item.City,
                CustomerId = item.CustomerId,
                Email = item.Email,
                FirstName = item.FirstName,
                HouseNr = item.HouseNr,
                LastName = item.LastName,
                StreetName = item.StreetName,
                ZipCode = item.ZipCode
            };

            return CustomerDto;
        }
    }
}
