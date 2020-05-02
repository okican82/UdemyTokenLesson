using System;
using System.Threading.Tasks;
using udemyLessonAPI.Domain.Repositories;

namespace udemyLessonAPI.Domain.UnitOfWork
{
    

    

    public class UnitOfWork : IUnitOfWork 
    {
        private readonly UdemyAPIWithTokenContext context;

        public UnitOfWork(UdemyAPIWithTokenContext context)
        {
            this.context = context;

        }

        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
