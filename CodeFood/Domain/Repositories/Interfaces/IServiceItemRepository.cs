using CodeFood.Domain.Entities;

namespace CodeFood.Domain.Repositories.Interfaces;

public interface IServiceItemRepository
{
    IQueryable<ServiceItem> GetServiceItems();
    ServiceItem GetServiceItemById(Guid id);
    void SaveServiceItem(ServiceItem entity);
    void DeleteServiceItem(Guid id);
}
