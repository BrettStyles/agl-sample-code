using System.Collections.Generic;
using System.Linq;
using Catagorization.Domain.Models;
using PeopleService.Domain.Models;

namespace Catagorization.Controllers
{
    internal class PetSorter : IPetSorter
    {
        public ICollection<PetByOwnerGender> SortByGender(ICollection<Owner> owners, PetType petType)
        {
            //include only owners with the desired pet type
            var ownersWithPetType = owners.Where(o => o.Pets != null && o.Pets.Any(p => p.Type == petType)).ToList();

            //order the owners by male / female
            var ownersByGender = ownersWithPetType.OrderBy(o => o.Gender).ToList();

            //map/reduce to produce cat names ordered grouped by owner gender and project to exoected model
            var filtered = ownersByGender.GroupBy(p => p.Gender,
                p => p.Pets
                    .Where(t => t.Type ==  petType)
                    .Select(n => n.Name)
                    .ToList(),
                (gender, pets) => new PetByOwnerGender
                {
                    Gender = gender,
                    Names = pets
                    .SelectMany(p=>p)
                    .OrderBy(p=>p)
                    .ToList()
                }
            ).ToList();

            return filtered;
        }
    }
}