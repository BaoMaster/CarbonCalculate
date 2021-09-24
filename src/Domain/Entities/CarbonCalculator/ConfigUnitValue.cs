using BlazorHero.CleanArchitecture.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorHero.CleanArchitecture.Domain.Entities.CarbonCalculator
{
    public class ConfigUnitValue : AuditableEntity<int>
    {
        public string QuestionKey { get; set; }
        public Double Value { get; set; }
    }
}
