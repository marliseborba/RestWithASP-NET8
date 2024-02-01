using RestWithASP_NET.Data.VO;

namespace RestWithASP_NET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO BookVO);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO BookVO);
        void Delete(long id);
    }
}
