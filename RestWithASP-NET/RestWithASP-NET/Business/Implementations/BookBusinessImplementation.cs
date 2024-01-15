using RestWithASP_NET.Model;
using RestWithASP_NET.Repository;
using System;

namespace RestWithASP_NET.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }
    }
}
