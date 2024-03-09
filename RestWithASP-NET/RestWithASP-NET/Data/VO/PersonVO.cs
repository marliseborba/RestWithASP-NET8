using RestWithASP_NET.Hypermedia;
using RestWithASP_NET.Hypermedia.Abstract;
using RestWithASP_NET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get ; set ; } = new List<HyperMediaLink>();
    }
}
