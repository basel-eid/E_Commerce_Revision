using E_Commerce_Revision.DTOs.CustomerDTOs;

namespace E_Commerce_Revision.Repos.CustomerRepos
{
    public interface ICustomer
    {
        public void AddCustomer(CustomerDto customerDto);
        public void AddCustomer22(CustomerDtoToAddWithExistingCoupon customerDto);
        IEnumerable<CustomerDto> GetAll();
    }
}
