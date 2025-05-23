using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Order;
using Ecom.Core.Interfaces;
using Ecom.Core.Services;
using Ecom.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastracture.Repositories.Service
{
    public class OderService : IOrderService
    {
        private readonly IUnitOfWork unit;
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public OderService(IUnitOfWork unitOfWork,AppDbContext context,IMapper mapper)
        {
            this.unit = unitOfWork;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Order> CreateOrderAsync(OrderDTO orderDTO, string BuyerEmail)
        {
            var basket=await unit.CustomerBasketRepository.GetBasketAsync(orderDTO.basketId);
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (var item in basket.basketItems)
            {
                var product = await unit.ProductRepository.GetByIdAsync(item.Id);
                var orderitem=new OrderItem(product.Id,product.Name,item.Image,item.Price,item.Quantity);
                orderItems.Add(orderitem);
            }
            var deliveryMethod=await context.DeliveryMethods.FirstOrDefaultAsync(d=>d.Id==orderDTO.deliveryMethodId);
            var subTotal=orderItems.Sum(m=>m.Price*m.Quantity);
            var shipping = mapper.Map<ShippingAddress>(orderDTO.shipAddressDTO);
            var order = new Order(BuyerEmail, subTotal,shipping, deliveryMethod, orderItems);
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            await unit.CustomerBasketRepository.DeleteBasketAsync(orderDTO.basketId);
            return order;
        }

        public Task<IReadOnlyList<Order>> GetAllOrdersForUserAsync(string BuyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int Id, string BuyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
