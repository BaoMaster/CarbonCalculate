using BlazorHero.CleanArchitecture.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Domain.Entities.CarbonCalculator
{
   public class Country : AuditableEntity<int>
    {
        public string CountryName { get; set; }
    }
}
