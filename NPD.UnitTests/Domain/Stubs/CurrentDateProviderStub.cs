using NPD.Domain.Interfaces;
using System;

namespace NPD.UnitTests.Domain.Stubs
{
    public class CurrentDateProviderStub : ICurrentDateProvider
    {
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
    }
}
