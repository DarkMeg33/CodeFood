using CodeFood.Domain.Entities;
using CodeFood.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeFood.Domain.Repositories.EntityFramework;

public class EFServiceItemRepository : IServiceItemRepository
{
    private readonly AppDbContext _dbContext;

    public EFServiceItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<ServiceItem> GetServiceItems()
    {
        return _dbContext.ServiceItems!;
    }

    public ServiceItem GetServiceItemById(Guid id)
    {
        return _dbContext.ServiceItems!.FirstOrDefault(x => x.Id == id)!;
    }

    public void SaveServiceItem(ServiceItem entity)
    {
        if (entity.Id == default)
            _dbContext.Entry(entity).State = EntityState.Added;
        else
            _dbContext.Entry(entity).State = EntityState.Modified;

        _dbContext.SaveChanges();
    }

    public void DeleteServiceItem(Guid id)
    {
        _dbContext.Remove(new ServiceItem() { Id = id });
        _dbContext.SaveChanges();
    }
}
