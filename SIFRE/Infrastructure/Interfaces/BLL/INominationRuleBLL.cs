using System.Collections.Generic;
using BE.DTO;
using BE.Entities;

namespace Infrastructure.Interfaces.BLL
{
    public interface INominationRuleBLL
    {
        void UpdateNominationRule(NominationRule rule);
        List<NominationRuleDTO> GetNominationRules();
    }
}