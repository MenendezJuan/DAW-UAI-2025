using System.Collections.Generic;
using BE.DTO;
using BE.Entities;

namespace Infrastructure.Interfaces.DAL
{
    public interface INominationRuleDAL
    {
        void UpdateNominationRule(NominationRule rule);
        List<NominationRuleDTO> GetNominationRules();
    }
}