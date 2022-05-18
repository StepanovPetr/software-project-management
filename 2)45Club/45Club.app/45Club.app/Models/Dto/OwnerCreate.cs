using System.Collections.Generic;

namespace _45Club.app.Models.Dto
{
    public class OwnerCreate
    {
        public ICollection<Person> Persons;

        public int PersonId {get; set; }

        public int TransportId { get; set; }
    }
}