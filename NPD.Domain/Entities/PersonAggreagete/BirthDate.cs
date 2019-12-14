using NPD.Domain.Common;
using NPD.Domain.Exceptions;
using NPD.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public class BirthDate : ValueObject
    {
        public DateTime Value { get; private set; }

        private BirthDate()
        {
        }

        public BirthDate(DateTime birthDate, ICurrentDateProvider dateProvider)
        {
            if (dateProvider is null)
                throw new NPDDomainException(nameof(dateProvider));

            var calculatedDate = dateProvider.GetCurrentDate().AddYears(-18);
            Value = birthDate < calculatedDate ? birthDate : throw new NPDDomainException(nameof(birthDate));

            //var minDate = DateTime.MinValue;
            //Value = ((minDate + dateProvider.GetCurrentDate().Subtract(birthDate)).Year - 1) > 18 ? birthDate : throw new NPDDomainException(nameof(birthDate));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}