namespace NPD.Domain.DTOs
{
    public class RelatedPersonDTO
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RelationType { get; set; }
        public PersonDTO Person { get; set; }

        public static RelatedPersonDTO CreateFrom(int id, int personId, int relationType, PersonDTO person)
        {
            return new RelatedPersonDTO
            {
                Id = id,
                PersonId = personId,
                RelationType = relationType,
                Person = person
            };
        }
    }
}