using NPD.Domain.Exceptions;
using System;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public class PhoneNumber : BaseEntity
    {
        public PhoneType Type { get; protected set; }
        public string Value { get; protected set; }

        private PhoneNumber()
        {
        }

        public PhoneNumber(PhoneType phoneType, string phoneNumber, int id = 0)
        {
            Value = phoneNumber.Length >= 4 && phoneNumber.Length <= 50 ? phoneNumber : throw new NPDDomainException(nameof(phoneNumber));
            Type = Enum.IsDefined(typeof(PhoneType), phoneType) ? (PhoneType)phoneType : throw new NPDDomainException(nameof(phoneType));
            Id = id;
        }

    }

    public enum PhoneType
    {
        Mobile,
        Home,
        Office,
    }
}