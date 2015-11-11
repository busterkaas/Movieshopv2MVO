using MovieShopDAL.BE;
using MovieShopDTO.ModelDTO;

namespace MovieShopDTO.Converter
{
    public class CustomerConverter : AbstractDtoConverter<Customer, CustomerDTO>
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

        public override Customer Reverse(CustomerDTO item)
        {
            var Customer = new Customer()
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

            return Customer;
        }
    }
}
