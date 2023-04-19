using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HeroGritSheet.Data;
using Microsoft.EntityFrameworkCore;
using HeroGritSheet.Models;
using LiteDB;

public class LiteDbContext
{
    private readonly LiteDatabase _db;

    public LiteDbContext(string connectionString)
    {
        _db = new LiteDatabase(connectionString);
    }

    public ILiteCollection<Character> Characters => _db.GetCollection<Character>("characters");

    public async Task<int> SaveChangesAsync()
    {
        return await Task.FromResult(0);
    }
    public async Task<int> AddCharacterAsync(Character character)
    {
        return await Task.FromResult(0);
    }
}
