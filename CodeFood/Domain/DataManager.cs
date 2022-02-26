using CodeFood.Domain.Repositories.Interfaces;

namespace CodeFood.Domain;

public class DataManager
{
    public ITextFieldRepository TextFields { get; set; }
    public IServiceItemRepository ServiceItems { get; set; }

    public DataManager(ITextFieldRepository textFields, IServiceItemRepository serviceItems)
    {
        TextFields = textFields;
        ServiceItems = serviceItems;
    }
}