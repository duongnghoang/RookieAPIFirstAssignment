using Application.Gateways;
using Domain.Entities;
using Infrastructure.Base;
using Persistence.Data;

namespace Infrastructure.Repositories;

public class TodoRepository(ApplicationDbContext context) : BaseRepository<Todo>(context), ITodoRepository
{

}