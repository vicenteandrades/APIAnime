namespace APIAnime.Repository;
public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    T GetById(int id);
    bool Create(T entity);
    bool Put(T entity);
    bool Delete(int id);

}

