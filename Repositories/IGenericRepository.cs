namespace dev_blog_dotnet.Repositories;

public interface IGenericRepository<T> {
    IEnumerable<T> GetAll();
    T? GetById(int id);
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(int id);
    bool Delete(T entity);
}
