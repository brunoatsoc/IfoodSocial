namespace IfoodSocial.Service;

public interface IBaseRepository<T, E, F>
{
    public F Create(T entity);
    public IEnumerable<E> ReadAll();
    public E? ReadById(int id);
    public void Update(F entity);
    public void Delete(E entity);
}