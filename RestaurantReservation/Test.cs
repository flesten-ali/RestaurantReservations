using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation;

public class Test<T>
{
    private IRepo<T> _repo;

    public Test(IRepo<T> repo)
    {
        _repo = repo;
    }

    public async Task TestAdd(T item)
    {
        await _repo.Add(item);
    }

    public async Task TestUpdate(int id, T item)
    {
        await _repo.Update(id, item);
    }

    public async Task TestDelete(int id)
    {
        await _repo.Delete(id);
    }
}
