using System;
using System.Collections.Generic;

namespace JobFinder.ViewModels
{
    public class SearchCriteriaViewModel
    {
        public IEnumerable<TownViewModel> Towns { get; set; }

        public IEnumerable<BusinessSectorViewModel> BusinessSectors { get; set; }
    }
}
