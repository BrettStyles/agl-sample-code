using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Configuration;
using PeopleService.Domain.Models;

namespace PeopleService.Providers
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly ISettings _configuration;

        public PetOwnerService(ISettings configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<Owner>> GetPetOwnersAsync()
        {
            //Get the service address from the configuration relative to the environment
            var petServiceAddress = _configuration.PetServiceAddress;

            using (var client = new HttpClient
            {
                BaseAddress = new Uri(petServiceAddress)
            })
            {
                var response = await client.GetAsync(new Uri("/people.json", UriKind.Relative));

                //throw if not 200 (OK)
                response.EnsureSuccessStatusCode();

                var owners = await response.Content.ReadAsAsync<ICollection<Owner>>();

                return owners;
            }
        }
    }
}