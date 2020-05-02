using System;
namespace udemyLessonAPI.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly UdemyAPIWithTokenContext context;

        public BaseRepository(UdemyAPIWithTokenContext context)
        {
            this.context = context;
        }
    }
}
