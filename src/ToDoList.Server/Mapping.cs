using AutoMapper;
using ToDoList.DTOs;

namespace ToDoList.Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<ToDo, ToDoResponse>();
    }
}