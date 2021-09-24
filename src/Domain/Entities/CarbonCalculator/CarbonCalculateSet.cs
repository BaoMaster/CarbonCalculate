using BlazorHero.CleanArchitecture.Domain.Contracts;
using BlazorHero.CleanArchitecture.Infrastructure.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Domain.Entities.CarbonCalculator
{
    public class CarbonCalculateSet : AuditableEntity<int>
    {
        public int NumberEmployee { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int CountryId { get; set; }
        public string UserId { get; set; }
        public virtual BlazorHeroUser User { get; set; }
    }
}
