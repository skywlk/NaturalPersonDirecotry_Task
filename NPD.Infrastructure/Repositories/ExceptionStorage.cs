using NPD.Domain.Entities;
using NPD.Domain.Interfaces;
using NPD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Repositories
{
    public class ExceptionStorage : IExceptionStorage
    {
        private readonly NPDContext _context;
        private int _counter { get; set; }


        public ExceptionStorage(NPDContext context)
        {
            _counter = 0;
            _context = context;
        }

        /// <summary>
        /// Uses recursion to save exceptions and inner exceptions
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public async Task LogExeptionAsync(Exception exception, Guid uuid)
        {
            if (exception == null || _counter >= 3)
            {
                return;
            }

            var ex = new UnprocessedException(nameof(exception), $"{exception.Message} - {exception.StackTrace}", uuid, _counter);
            await SaveExceptionModelAsync(ex);
            await LogExeptionAsync(exception.InnerException, uuid);
        }

        protected async Task SaveExceptionModelAsync(UnprocessedException exception)
        {
            _context.Set<UnprocessedException>().Add(exception);
            await _context.SaveChangesAsync();
        }
    }
}
