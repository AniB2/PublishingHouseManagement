using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Domain.Entities;
using PublishingHouseManagement.Persistence.Context;

namespace PublishingHouseManagement.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly PublishingHouseManagementContext _context;

        public AuthorRepository(PublishingHouseManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProductToAuthorAsync(int authorId, int productId, CancellationToken cancellationToken = default)
        {
            var author = await _context.Authors.Include(a => a.Products).FirstOrDefaultAsync(a => a.Id == authorId, cancellationToken);

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);

            if (author == null || product == null)
                throw new InvalidOperationException("Author or Product not found.");

            if (!author.Products.Contains(product))
            {
                author.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}