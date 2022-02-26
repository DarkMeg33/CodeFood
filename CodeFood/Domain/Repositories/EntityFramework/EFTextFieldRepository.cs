using CodeFood.Domain.Entities;
using CodeFood.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFood.Domain.Repositories.EntityFramework;

public class EFTextFieldRepository : ITextFieldRepository
{
    private readonly AppDbContext _dbContext;

    public EFTextFieldRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TextField> GetTextFields()
    {
        return _dbContext.TextFields!;
    }

    public TextField GetTextFieldById(Guid id)
    {
        return _dbContext.TextFields!.FirstOrDefault(x => x.Id == id)!;
    }

    public TextField GetTextFieldByCodeWord(string codeWord)
    {
        return _dbContext.TextFields!.FirstOrDefault(x => x.CodeWord == codeWord)!;
    }

    public void SaveTextField(TextField entity)
    {
        if (entity.Id == default)
            _dbContext.Entry(entity).State = EntityState.Added;
        else
            _dbContext.Entry(entity).State = EntityState.Modified;

        _dbContext.SaveChanges();
    }

    public void DeleteTextField(Guid id)
    {
        _dbContext.Remove(new TextField() { Id = id });
        _dbContext.SaveChanges();
    }
}
