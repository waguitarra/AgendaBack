using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class EmailsNewsletterImplementation : BaseRepository<EmailsNewsletterEntity>, IUEmailsNewsletterRepository
    {
        private DbSet<IUEmailsNewsletterRepository> _dataset;

        public EmailsNewsletterImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<IUEmailsNewsletterRepository>();
        }
    }
}
