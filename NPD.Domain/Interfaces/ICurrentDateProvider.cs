using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Domain.Interfaces
{
    public interface ICurrentDateProvider
    {
        DateTime GetCurrentDate();
    }
}
