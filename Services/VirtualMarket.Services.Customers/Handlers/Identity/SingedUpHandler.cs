using System.Threading.Tasks;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Customers.Domain;
using VirtualMarket.Services.Customers.Messages.Events;
using VirtualMarket.Services.Customers.Repositories;

namespace VirtualMarket.Services.Customers.Handlers.Identity
{
    public class SingedUpHandler : IEventHandler<SignedUp>
    {
        private readonly ICustomersRepository _customersRepository;

        public SingedUpHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task HandleAsync(SignedUp @event, ICorrelationContext context)
        {
            var customer = new Customer(@event.UserId, @event.Email);
            await _customersRepository.AddAsync(customer);
        }
    }
}
