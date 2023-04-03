using Microsoft.EntityFrameworkCore;
using tinker.Domain.Entities.Common;

namespace tinker.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
