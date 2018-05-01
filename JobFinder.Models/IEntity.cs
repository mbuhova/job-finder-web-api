using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFinder.Models
{
    public interface IEntity<TIDType>
    {
       TIDType Id { get; }
    }
}
