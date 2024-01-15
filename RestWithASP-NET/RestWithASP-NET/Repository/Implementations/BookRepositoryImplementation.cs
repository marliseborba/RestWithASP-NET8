using RestWithASP_NET.Model;
using RestWithASP_NET.Repository;

namespace RestWithASP_NET.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book Book)
        {
            try
            {
                _context.Add(Book);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Update(Book Book)
        {
            if (!Exists(Book.Id))
                return null;

            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(Book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(Book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return Book;
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
