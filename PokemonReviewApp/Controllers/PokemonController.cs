using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using System.Runtime.InteropServices;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPokemonRepository pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.pokemonRepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = this.mapper.Map<List<PokemonDto>>(pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId)
        {
            if (!this.pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var pokemon = this.mapper.Map<PokemonDto>(this.pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!this.pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var rating=pokemonRepository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(rating);
        }
    }
}
