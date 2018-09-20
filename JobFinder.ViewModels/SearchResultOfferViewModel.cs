using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using JobFinder.Models;

namespace JobFinder.ViewModels
{
    public class SearchResultOfferViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Town { get; set; }

        public string BusinessSector { get; set; }

        public DateTime DateCreated { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public bool? IsFullTime { get; set; }

        public bool? IsPermanent { get; set; }
    }
}
