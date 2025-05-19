using BE.DTO;
using BE.Entities;
using Infrastructure.Interfaces.BLL;
using Infrastructure.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ObjectiveBLL : IObjectiveBLL
    {
        private readonly IObjectiveDAL _objectiveDAL;
        public ObjectiveBLL(IObjectiveDAL objectiveDAL)
        {
            _objectiveDAL = objectiveDAL;
        }

        public List<ObjectiveHistoryDTO> GetObjectiveHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId)
        {
            return _objectiveDAL.GetObjectiveHistory(dateFrom, dateTo, collaboratorId);
        }
                public List<RewardPolicyDTO> GetRewardPolicies()
        {
            return _objectiveDAL.GetRewardPolicies();
        }

        public void AddRewardPolicy(RewardPolicy policy)
        {
            policy.CreatedAt = DateTime.Now;
            _objectiveDAL.AddRewardPolicy(policy);
        }

        public void UpdateRewardPolicy(RewardPolicy policy)
        {
            policy.UpdatedAt = DateTime.Now;
            _objectiveDAL.UpdateRewardPolicy(policy);
        }

        public void DeleteRewardPolicy(int policyId)
        {
            _objectiveDAL.DeleteRewardPolicy(policyId);
        }

        public List<PolicyCategoryDTO> GetPolicyCategories()
        {
            return _objectiveDAL.GetPolicyCategories();
        }
                public List<ObjectiveDTO> GetObjectives()
        {
            return _objectiveDAL.GetObjectives();
        }

        public void AddObjective(Objective objective)
        {
            objective.CreatedAt = DateTime.Now;
            _objectiveDAL.AddObjective(objective);
        }

        public void UpdateObjective(ObjectiveDTO objective, string comment)
        {
            objective.UpdatedAt = DateTime.Now;
            _objectiveDAL.UpdateObjective(objective, comment);
        }

        public void DeleteObjective(int objectiveId)
        {
            _objectiveDAL.DeleteObjective(objectiveId);
        }

        public List<ObjectiveCommentDTO> GetObjectiveComments(int objectiveId)
        {
            return _objectiveDAL.GetObjectiveComments(objectiveId);
        }
    }
}
