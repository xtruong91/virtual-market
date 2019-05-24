using System.Threading.Tasks;
using Chronicle;
using VirtualMarket.Common.Handlers;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.RabbitMq;
using VirtualMarket.Services.Operations.Sagas;
using VirtualMarket.Services.Operations.Services;


namespace VirtualMarket.Services.Operations.Handlers
{
    public class GenericCommandHandler<T> : ICommandHandler<T> where T : class, ICommand
    {
        private readonly ISagaCoordinator _sagaCoordinator;
        private readonly IOperationPublisher _operationPublisher;
        private readonly IOperationsStorage _operationsStorage;

        public GenericCommandHandler(ISagaCoordinator sagaCoordinator,
            IOperationPublisher operationPublisher,
            IOperationsStorage operationsStorage)
        {
            _sagaCoordinator = sagaCoordinator;
            _operationPublisher = operationPublisher;
            _operationsStorage = operationsStorage;
        }

        public async Task HandleAsync(T command, ICorrelationContext context)
        {
            if (!command.BelongsToSaga())
            {
                return;
            }

            var sagaContext = SagaContext.FromCorrelationContext(context);
            await _sagaCoordinator.ProcessAsync(command, sagaContext);
        }
    }
}
