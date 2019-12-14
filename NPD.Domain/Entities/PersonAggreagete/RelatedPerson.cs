using NPD.Domain.Exceptions;
using System;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public class RelatedPerson : BaseEntity
    {
        private RelatedPerson()
        {
        }

        public RelatedPerson(RelationType relationType, int rPersonId,  int id = 0)
        {
            Type = Enum.IsDefined(typeof(RelationType), relationType) ? (RelationType)relationType : throw new NPDDomainException(nameof(relationType));
            RPersonId = rPersonId > 0 ? rPersonId : throw new NPDDomainException(nameof(rPersonId));
            Id = id;
        }

        public RelationType Type { get; protected set; }
        public int PersonId { get; protected set; }
        public int RPersonId { get; protected set; }
    }

    public enum RelationType {
        Coworker,
        Relative,
        Friend,
        Other,
    }
}