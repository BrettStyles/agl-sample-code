using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleService.Domain.Models;

namespace PeopleService.Providers
{
    public interface IPetOwnerService
    {
        Task<ICollection<Owner>> GetPetOwnersAsync();
    }
}