using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public class PersonOffer : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string PersonId { get; set; }
        public Person Person { get; set; }
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}
