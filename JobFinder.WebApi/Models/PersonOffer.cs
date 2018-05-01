using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.WebApi.Models
{
    public class PersonOffer
    {
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}
