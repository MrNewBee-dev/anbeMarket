using System.Collections.Generic;

namespace Anbe.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual IList<City> Cities { get; set; }
    }
}