using Tips.Domain;

namespace Tips.Service;

public interface IToDoService
{
    Task<List<ToDo>> GetAll();
    Task<ToDo> GetById(int id);
    Task<ToDo> Create(ToDo todo);
    Task<ToDo> Update(ToDo toDo);
    Task<ToDo> Delete(int id);
}