namespace RestaurantReservation.Db.Repositories;

public interface IRepo<T>
{
    Task Add(T entity);
    Task Delete(int id);
    Task Update(int id, T entity);
}