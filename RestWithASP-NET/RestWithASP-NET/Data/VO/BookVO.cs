using RestWithASP_NET.Hypermedia;
using RestWithASP_NET.Hypermedia.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET.Data.VO
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string? Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }
 
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
