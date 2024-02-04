using Microsoft.EntityFrameworkCore;
using Tips.Database;
using Tips.Domain;

namespace Tips.Service;

public class ToDoService : IToDoService
{
    private readonly AppDbContext _appDbContext;

    public ToDoService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<ToDo>> GetAll()
    {
        return await _appDbContext.ToDos.ToListAsync();
    }

    public async Task<ToDo?> GetById(int id)
    {
        return await _appDbContext.ToDos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ToDo> Create(ToDo todo)
    {
        await _appDbContext.ToDos.AddAsync(todo);
        await _appDbContext.SaveChangesAsync();
        return todo;
    }

    public async Task<ToDo> Update(ToDo toDo)
    {
        _appDbContext.ToDos.Update(toDo);
        await _appDbContext.SaveChangesAsync();
        return toDo;
    }

    public async Task<ToDo> Delete(int id)
    {
        var toDo = await GetById(id);

        if (toDo == null) return new ToDo();

        _appDbContext.ToDos.Remove(toDo);
        await _appDbContext.SaveChangesAsync();

        return toDo;
    }
}