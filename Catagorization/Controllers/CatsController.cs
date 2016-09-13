using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Catagorization.Domain.Models;
using PeopleService.Domain.Models;
using PeopleService.Providers;

namespace Catagorization.Controllers
{
    [RoutePrefix("api/cats")]
    public class CatsController : ApiController
    {
        private readonly IPetOwnerService _petOwnerService;
        private readonly IPetSorter _sorter;

        public CatsController(IPetOwnerService petOwnerService, IPetSorter sorter)
        {
            _petOwnerService = petOwnerService;
            _sorter = sorter;
        }

        [Route("sorted")]
        public async Task<ICollection<PetByOwnerGender>> Sorted()
        {
           var petOwners = await _petOwnerService.GetPetOwnersAsync();

            var sortedPets = _sorter.SortByGender(petOwners);

            return sortedPets;
        }
    }
}
