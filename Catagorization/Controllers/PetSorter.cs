using System.Collections.Generic;
using Catagorization.Domain.Models;
using PeopleService.Domain.Models;

namespace Catagorization.Controllers
{
    internal class PetSorter : IPetSorter
    {
        public ICollection<PetByOwnerGender> SortByGender(ICollection<Owner> owners)
        {
            return new List<PetByOwnerGender>();
        }
    }
}