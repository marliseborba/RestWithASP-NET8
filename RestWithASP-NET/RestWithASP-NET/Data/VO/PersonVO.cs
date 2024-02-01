using RestWithASP_NET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASP_NET.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("code")]
        public long Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [JsonIgnore]
        public string Address { get; set; }

        public string Gender { get; set; }
    }
}
