using System;
using System.Threading.Tasks;

namespace udemyLessonAPI.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
