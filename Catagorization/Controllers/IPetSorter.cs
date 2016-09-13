using System.Collections.Generic;
using Catagorization.Domain.Models;
using PeopleService.Domain.Models;

namespace Catagorization.Controllers
{
    public interface IPetSorter
    {
        ICollection<PetByOwnerGender> SortByGender(ICollection<Owner> owners, PetType petType);
    }
}