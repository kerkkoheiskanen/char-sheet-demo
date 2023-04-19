using LiteDB;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroGritSheet.Models;
using HeroGritSheet.Data;

namespace HeroGritSheet.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly LiteDbContext _dbContext;

        public CharacterRepository(LiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Character>> GetAllCharactersAsync()
        {
            return await Task.Run(() => _dbContext.Characters.FindAll().ToList());
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            return await Task.Run(() => _dbContext.Characters.FindById(id));
        }

        public async Task<Character> AddCharacterAsync(Character character)
        {
            await Task.Run(() => _dbContext.Characters.Upsert(character));
            return character;
        }

        public async Task<Character> UpdateCharacterAsync(Character character)
        {
            await Task.Run(() => _dbContext.Characters.Upsert(character));
            return character;
        }

        public async Task DeleteCharacterAsync(int id)
        {
            await Task.Run(() => _dbContext.Characters.Delete(id));
        }

        public async Task DeleteAllCharactersAsync()
        {
            await Task.Run(() => _dbContext.Characters.DeleteAll());
        }
    }
}
