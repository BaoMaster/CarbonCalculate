using BlazorHero.CleanArchitecture.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Domain.Entities.CarbonCalculator
{
   public class CarbonCalculateAnswer : AuditableEntity<int>
    {
        public string QuestionKey { get; set; }
        public string Answer { get; set; }
        public double CarbonOfT { get; set; }
        public virtual CarbonCalculateSet CarbonCalculateSet { get; set; }
    }
}
