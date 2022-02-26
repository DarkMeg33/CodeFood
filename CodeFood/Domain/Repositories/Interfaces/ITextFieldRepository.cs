using CodeFood.Domain.Entities;

namespace CodeFood.Domain.Repositories.Interfaces;

public interface ITextFieldRepository
{
    IQueryable<TextField> GetTextFields();
    TextField GetTextFieldById(Guid id);
    TextField GetTextFieldByCodeWord(string codeWord);
    void SaveTextField(TextField entity);
    void DeleteTextField(Guid id);
}
