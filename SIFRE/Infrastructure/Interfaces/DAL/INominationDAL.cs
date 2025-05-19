using System;
using System.Collections.Generic;
using BE.DTO;
using BE.Entities;
using BE.Enums;

namespace Infrastructure.Interfaces.DAL
{
    public interface INominationDAL
    {
        void AddNomination(Nomination nomination);
        List<User> GetUsers();
        List<RecognitionCategory> GetRecognitionCategories();
        int GetUserNominationsCount(Guid userId, DateTime fromDate);
        List<NominationCommentDTO> GetNominationComments(int nominationId);
        List<NominationDTO> GetNominationsByUser(Guid userId);
        void AddNominationHistory(NominationHistory nominationHistory);
        void AddNominationComment(NominationComment nominationComment);
        void UpdateNomination(int nominationId, NominationStatuses status);
        List<NominationHistoryDTO> GetNominationHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId, int? recognitionTypeId);
    }
}