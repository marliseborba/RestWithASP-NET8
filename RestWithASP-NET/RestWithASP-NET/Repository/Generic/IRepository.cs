using RestWithASP_NET.Model;
using RestWithASP_NET.Model.Base;

namespace RestWithASP_NET.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T T);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T T);
        void Delete(long id);
        bool Exists(long id);
    }
}
