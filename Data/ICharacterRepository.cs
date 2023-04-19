using System.Collections.Generic;
using System.Threading.Tasks;
using HeroGritSheet.Models;

namespace HeroGritSheet.Data
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetAllCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int id);
        Task<Character> AddCharacterAsync(Character character);
        Task<Character> UpdateCharacterAsync(Character character);
        Task DeleteCharacterAsync(int id);
    }
}
