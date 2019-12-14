using NPD.Domain.Common;
using NPD.Domain.Exceptions;
using NPD.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public class Name : ValueObject
    {
        private Name()
        {
        }

        public string Value { get; protected set; }

        public static Name Create(string name)
        {
            if (name is null)
                throw new NPDDomainException($"{nameof(name)} should not be empty");
            return new Name
            {
                Value = name.IsLatinOrGeorgian() ? name : throw new NPDDomainException($"{nameof(name)} parameter contains forbidden unicode combination"),
            };
        }
        
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
