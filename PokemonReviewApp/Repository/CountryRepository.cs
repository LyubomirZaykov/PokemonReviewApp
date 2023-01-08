using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;


        public CountryRepository(DataContext context)
        {
            this.context = context;


        }
        public bool CountryExists(int id)
        {
            return this.context.Contries.Any(c=>c.Id== id);
        }

        public ICollection<Country> GetCountries()
        {
            return this.context.Contries.ToList();
        }

        public Country GetCountry(int id)
        {
            return this.context.Contries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return this.context.Owners.Where(o => o.Id == ownerId).Select(c =>c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return this.context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }
    }
}
