using System;
using System.Threading.Tasks;
using VirtualMarket.Common.Types;

namespace VirtualMarket.Common.Handlers
{
    public class Handler : IHandler
    {
        private Func<Task> _handle;
        private Func<Task> _onSuccess;
        private Func<Task> _always;
        private Func<VirtualMarketException, Task> _onCustomError;
        private Func<Exception, Task> _onError;
        private bool _rethrowExeception;
        private bool _rethrowCustomException;

        public Handler()
        {
            _always = () => Task.CompletedTask;
        }
        public IHandler Always(Func<Task> always)
        {
            _always = always;
            return this;
        }

        public async Task ExcecuteAsync()
        {
            bool isFailure = false;

            try
            {
                await _handle();
            }
            catch (VirtualMarketException customException)
            {
                isFailure = true;
                await _onCustomError?.Invoke(customException);
                if (_rethrowCustomException)
                {
                    throw;
                }
            }
            catch (Exception exception)
            {
                isFailure = true;
                await _onError?.Invoke(exception);
                if (_rethrowExeception)
                {
                    throw;
                }
            }
            finally
            {
                if (!isFailure)
                {
                    await _onSuccess?.Invoke();
                }
                await _always?.Invoke();
            }
        }

        public IHandler Handle(Func<Task> handle)
        {
            _handle = handle;
            return this;
        }

        public IHandler OnCustomError(Func<VirtualMarketException, Task> onCustomError, bool rethrow = false)
        {
            _onCustomError = onCustomError;
            _rethrowExeception = rethrow;
            return this;
        }

        public IHandler OnError(Func<Exception, Task> onError, bool rethrow = false)
        {
            _onError = onError;
            _rethrowExeception = rethrow;
            return this;
        }

        public IHandler OnSuccess(Func<Task> onSuccess)
        {
            _onSuccess = onSuccess;
            return this;
        }
    }
}
