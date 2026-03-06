using FrameworksPractice1.Domain;

namespace FrameworksPractice1.Services
{
    public interface ItemRepository
    {
        IReadOnlyCollection<Item> GetAll();
        Item? GetById(Guid id);
        Item Create(string name, decimal price);
    }
}
