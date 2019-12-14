using MediatR;
using NPD.Domain.Entities.PersonAggreagete;

namespace NPD.Domain.Events
{
    public class PhoneNumberAddedEvent : INotification
    {
        public PhoneNumberAddedEvent(Person person, string phoneNumber)
        {
            Person = person;
            PhoneNumber = phoneNumber;
        }

        public Person Person { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}
