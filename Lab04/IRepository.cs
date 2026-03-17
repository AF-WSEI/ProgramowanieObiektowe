namespace Lab04;

public interface IRepository<T>
{
    void Add(T item);

    IEnumerable<T> GetAll();

    T GetById(int id);
}

public class MemoryRepository<T> : IRepository<T>
{
    private T[] _items = new T[10];
    private int _index = -1;
    public void Add(T item)
    {
        _items[++_index] = item;
    }

    public IEnumerable<T> GetAll()
    {
        for (int i = _index; i < _items.Length && i <= _index; i++)
        {
            yield return _items[i];
        }
    }

    public T GetById(int id)
    {
        return _items[id];
    }
}