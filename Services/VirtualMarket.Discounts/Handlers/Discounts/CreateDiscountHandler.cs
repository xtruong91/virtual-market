using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Common.Types;
using VirtualMarket.Discounts.Domain;
using VirtualMarket.Discounts.Messages.Commands;
using VirtualMarket.Discounts.Messages.Events;
using VirtualMarket.Discounts.Repositories;

namespace VirtualMarket.Discounts.Handlers.Discounts
{
    public class CreateDiscountHandler : ICommandHandler<CreateDiscount>
    {
        private readonly IDiscountsRepository _discountsRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<CreateDiscountHandler> _logger;

        public CreateDiscountHandler(IDiscountsRepository discountsRepository,
            ICustomersRepository customersRepository,
            IBusPublisher busPublisher,
            ILogger<CreateDiscountHandler> logger)
        {
            _discountsRepository = discountsRepository;
            _customersRepository = customersRepository;
            _busPublisher = busPublisher;
            _logger = logger;
        }

        public async Task HandleAsync(CreateDiscount command, ICorrelationContext context)
        {
            var customer = await _customersRepository.GetAsync(command.CustomerId);
            if (customer is null)
            {
                throw new VirtualMarketException("customer_not_found",
                    $"Customer with id: '{command.CustomerId}' was not found.");
            }

            var discount = new Discount(command.Id, command.CustomerId,
                command.Code, command.Percentage);
            await _discountsRepository.AddAsync(discount);
            await _busPublisher.PublishAsync(new DiscountCreated(command.Id,
                command.CustomerId, command.Code, command.Percentage), context);
        }
    }
}
