using System;
using System.Collections.Generic;
using Infrastructure.Interfaces.DAL;
using Infrastructure.Interfaces.BLL;
using BE.Entities;
using BE.DTO;

namespace BLL
{
    public class NominationRuleBLL : INominationRuleBLL
    {
        private readonly INominationRuleDAL _nominationRuleDAL;

        public NominationRuleBLL(INominationRuleDAL nominationRuleDAL)
        {
            _nominationRuleDAL = nominationRuleDAL;
        }

        public void UpdateNominationRule(NominationRule rule)
        {
            rule.UpdatedAt = DateTime.Now;
            _nominationRuleDAL.UpdateNominationRule(rule);
        }

        public List<NominationRuleDTO> GetNominationRules()
        {
            return _nominationRuleDAL.GetNominationRules();
        }
    }
}