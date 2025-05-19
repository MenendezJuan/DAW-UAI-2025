using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.DTO;
using BE.Entities;

namespace Infrastructure.Interfaces.BLL
{
    public interface IObjectiveBLL
    {
        List<PolicyCategoryDTO> GetPolicyCategories();
        List<RewardPolicyDTO> GetRewardPolicies();
        void AddRewardPolicy(RewardPolicy policy);
        void UpdateRewardPolicy(RewardPolicy policy);
        void DeleteRewardPolicy(int policyId);
        List<ObjectiveHistoryDTO> GetObjectiveHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId);
        List<ObjectiveDTO> GetObjectives();
        void AddObjective(Objective objective);
        void UpdateObjective(ObjectiveDTO objective, string comment);
        void DeleteObjective(int objectiveId);
        List<ObjectiveCommentDTO> GetObjectiveComments(int objectiveId);
    }
}
