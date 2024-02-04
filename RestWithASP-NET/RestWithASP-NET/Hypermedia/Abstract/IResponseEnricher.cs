using Microsoft.AspNetCore.Mvc.Filters;

namespace RestWithASP_NET.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutedContext context);
        Task Enrich(ResultExecutedContext context);
    }
}
