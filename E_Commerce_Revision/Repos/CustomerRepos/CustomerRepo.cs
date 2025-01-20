using E_Commerce_Revision.Data;
using E_Commerce_Revision.DTOs.CartDTOs;
using E_Commerce_Revision.DTOs.CouponDTOs;
using E_Commerce_Revision.DTOs.CustomerDTOs;
using E_Commerce_Revision.DTOs.OrderDTOs;
using E_Commerce_Revision.DTOs.ProductDTOs;
using E_Commerce_Revision.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

namespace E_Commerce_Revision.Repos.CustomerRepos
{
    public class CustomerRepo : ICustomer
    {
        private readonly DataContext _context;
        public CustomerRepo(DataContext context)
        {
            _context = context;
        }
        public void AddCustomer(CustomerDto customerDto)
        {
            Customer cus = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Contact = customerDto.Contact,
                ShoppingCart = new ShoppingCart
                {
                    NumberOfItems = customerDto.ShoppingCartOnlyDto.NumberOfItems
                },
                Orders = customerDto.orderForCustomerDtos.Select(x=> new Order
                {
                    Price = x.Price,
                    Products = x.ProductsOnly.Select(x=> new Product
                    {
                        Name=x.Name,
                        Description=x.Description,
                        StockQuantity=x.StockQuantity,
                    }).ToList(),
                }).ToList(),
                Coupons = customerDto.couponOnlyDtos.Select(v=>  new Coupon
                {
                    Title = v.Title,
                    Percentage = v.Percentage,
                }).ToList(),
            };
            _context.Customers.Add(cus);
            _context.SaveChanges();
        }

        public void AddCustomer22(CustomerDtoToAddWithExistingCoupon customerDto)
        {
            List<Coupon> coList = new List<Coupon>();
            
            if (customerDto.CouponId == 0)
            {
                var coupons = _context.Coupons.ToList();
                Random rand = new Random();
                int randomindex = rand.Next(0, coupons.Count);
                coList =  [coupons.ElementAt(randomindex)];
            }
            else
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.Id == customerDto.CouponId);
                coList = [coupon];
            }
            Customer cus = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Contact = customerDto.Contact,
                ShoppingCart = new ShoppingCart
                {
                    NumberOfItems = customerDto.ShoppingCartOnlyDto.NumberOfItems
                },
                Orders = customerDto.orderForCustomerDtos.Select(x => new Order
                {
                    Price = x.Price,
                    Products = x.ProductsOnly.Select(x => new Product
                    {
                        Name = x.Name,
                        Description = x.Description,
                        StockQuantity = x.StockQuantity,
                    }).ToList(),
                }).ToList(),
                Coupons = coList,
                
            };
            _context.Customers.Add(cus);
            _context.SaveChanges();
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var cus = _context.Customers.Include(x => x.ShoppingCart).Include(x=> x.Coupons).Include(x => x.Orders).ThenInclude(x => x.Products).Select(x => new CustomerDto
            {
                Name = x.Name,
                Contact = x.Contact,
                Email = x.Email,
                ShoppingCartOnlyDto = new ShoppingCartOnlyDto
                {
                    NumberOfItems = x.ShoppingCart.NumberOfItems
                },
                orderForCustomerDtos = x.Orders.Select(x => new OrderForCustomerDto
                {
                    Price = x.Price,
                    ProductsOnly = x.Products.Select(v => new ProductsOnlyDto
                    {
                        Name = v.Name,
                        Description = v.Description,
                        StockQuantity = v.StockQuantity,
                    }).ToList()
                }).ToList(),
                couponOnlyDtos = x.Coupons.Select(m=> new CouponOnlyDto
                {
                    Title = m.Title,
                    Percentage = m.Percentage,
                }).ToList()
            }).ToList();
            return cus;
        }
    }
}
