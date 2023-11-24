using Astronauts.Core.Entities;

namespace Astronauts.Core.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    Task<T> GetById(int id);
    Task Post(T entity);
}
