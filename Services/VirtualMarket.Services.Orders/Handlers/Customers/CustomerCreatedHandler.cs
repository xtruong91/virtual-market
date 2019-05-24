using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Orders.Domain;
using VirtualMarket.Services.Orders.Messages.Events;
using VirtualMarket.Services.Orders.Repositories;

namespace VirtualMarket.Services.Orders.Handlers.Customers
{
    public class CustomerCreatedHandler : IEventHandler<CustomerCreated>
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomerCreatedHandler(ICustomersRepository customersRepostitory)
        {
            _customersRepository = customersRepostitory;
        }
        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context) =>
            await _customersRepository.AddAsync(new Customer(@event.Id, @event.Email,
                @event.FirstName, @event.LastName, @event.Address, @event.Country));
    }
}
