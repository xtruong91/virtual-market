﻿using System.Threading.Tasks;
using VirtualMarket.Common.Messages;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher,
            IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
            => await _queryDispatcher.QueryAsync(query);

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
            => await _commandDispatcher.SendAsync(command);
    }
}
