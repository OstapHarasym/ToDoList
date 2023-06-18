using MongoDB.Driver;

namespace ToDoList.Server;

public interface IToDoRepository
{
    Task<ToDo> Get(Guid id);
    Task Add(ToDo toDo);
    Task<IEnumerable<ToDo>> Get(bool completed = false);
    Task Update(ToDo toDo);
    Task Delete(Guid id);
}

public class ToDoRepository : IToDoRepository
{
    private readonly IMongoCollection<ToDo> _collection;

    public ToDoRepository(IMongoCollection<ToDo> collection)
    {
        _collection = collection;
    }

    public async Task<ToDo> Get(Guid id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task Add(ToDo toDo)
    {
        await _collection.InsertOneAsync(toDo);
    }

    public async Task<IEnumerable<ToDo>> Get(bool completed = false)
    {
        return await _collection.Find(x => completed && x.Done != null || !completed && x.Done == null).ToListAsync();
    }

    public async Task Update(ToDo toDo)
    {
        var filter = Builders<ToDo>.Filter.Eq(x => x.Id, toDo.Id);
        await _collection.ReplaceOneAsync(filter, toDo);
    }

    public async Task Delete(Guid id)
    {
        await _collection.FindOneAndDeleteAsync(x => x.Id == id);
    }
}