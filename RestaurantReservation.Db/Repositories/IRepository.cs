namespace RestaurantReservation.Db.Repositories;

public interface IRepository<T>
{
    Task Add(T entity);
    Task Delete(int id);
    Task Update(int id, T entity);
    Task<T> GetById(int id);
}