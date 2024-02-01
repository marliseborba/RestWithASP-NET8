using RestWithASP_NET.Model;

namespace RestWithASP_NET.Business
{
    public interface IBookBusiness
    {
        Book Create(Book Book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
    }
}
