using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext context;

        public OwnerRepository(DataContext context)
        {
            this.context = context;

        }
        public Owner GetOwner(int ownerId)
        {
            return this.context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return this.context.PokemonOwners
                .Where(p => p.Pokemon.Id == pokeId).Select(p => p.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return this.context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return this.context.PokemonOwners.Where(p=>p.Owner.Id==ownerId)
                .Select(p=>p.Pokemon).ToList();
        }

        public bool OwnersExists(int ownerId)
        {
            return this.context.Owners.Any(o=>o.Id==ownerId);   
        }
    }
}
