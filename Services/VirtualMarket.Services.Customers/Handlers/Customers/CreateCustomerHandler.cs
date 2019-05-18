using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Services.Customers.Domain;
using VirtualMarket.Services.Customers.Messages.Commands;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Customers
{
    public class CreateCustomerHandler : ICommandHandler<CreateCustomer>
    {
        public readonly IBusPublisher _busPublisher;
        private readonly ICartsRepository _cartsRepository;
        private readonly ICustomersRepository _customersRepository;

        public CreateCustomerHandler(IBusPublisher busPublisher,
            ICartsRepository cartsRepository,
            ICustomersRepository customersRepository)
        {
            _busPublisher = busPublisher;
            _cartsRepository = cartsRepository;
            _customersRepository = customersRepository;
        }
        public async Task HandleAsync(CreateCustomer command, ICorrelationContext context)
        {
            var customer = await _customersRepository.GetAsync(command.Id);
            if (customer.Completed)
            {
                throw new VirtualMarketException(Codes.CustomerAlreadyCompleted,
                    $"Customer account was already created for user with id: '{command.Id}'.");
            }

            customer.Complete(command.FirstName, command.LastName, command.Address, command.Country);
            await _customersRepository.UpdateAsync(customer);
            var cart = new Cart(command.Id);
            await _cartsRepository.AddAsync(cart);
            await _busPublisher.PublishAsync(new CustomerCreated(command.Id, customer.Email,
                command.FirstName, command.LastName, command.Address, command.Country), context);
        }
    }
}
