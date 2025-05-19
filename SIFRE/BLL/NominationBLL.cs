using System;
using System.Collections.Generic;
using Infrastructure.Interfaces.DAL;
using Infrastructure.Interfaces.BLL;
using BE.Entities;
using BE.DTO;
using BE.Enums;
using Infrastructure.Session;

namespace BLL
{
    public class NominationBLL : INominationBLL
    {
        private readonly INominationDAL _nominationDAL;

        public NominationBLL(INominationDAL nominationDAL)
        {
            _nominationDAL = nominationDAL;
        }

        public void NominateCollaborator(Nomination nomination)
        {
            nomination.CreatedAt = DateTime.Now;
            nomination.StatusId = 1; // Pendiente
            _nominationDAL.AddNomination(nomination);
        }

        public List<User> GetUsers()
        {
            return _nominationDAL.GetUsers();
        }

        public List<RecognitionCategory> GetRecognitionCategories()
        {
            return _nominationDAL.GetRecognitionCategories();
        }

        public int GetUserNominationsCount(Guid userId, DateTime fromDate)
        {
            return _nominationDAL.GetUserNominationsCount(userId, fromDate);
        }

        public List<NominationCommentDTO> GetNominationComments(int nominationId)
        {
            return _nominationDAL.GetNominationComments(nominationId);
        }

        public List<NominationDTO> GetNominationsByUser(Guid userId)
        {
            return _nominationDAL.GetNominationsByUser(userId);
        }

        public void AddNominationHistory(NominationHistory nominationHistory)
        {
            _nominationDAL.AddNominationHistory(nominationHistory);
        }

        public void AddNominationComment(NominationComment nominationComment)
        {
            _nominationDAL.AddNominationComment(nominationComment);
        }

        public void UpdateNomination(int nominationId, NominationStatuses status, string comment)
        {
            NominationHistory nominationHistory = new NominationHistory
            {
                NominationId = nominationId,
                StatusId = (int)status, 
                CreatedBy = SingletonSession.Instancia.User.Id,
                CreatedAt = DateTime.Now
            };
            var nominationComment = new NominationComment
                {
                    NominationId = nominationId,
                    Comment = comment,
                    CreatedBy = SingletonSession.Instancia.User.Id,
                    CreatedAt = DateTime.Now
                };
            _nominationDAL.UpdateNomination(nominationId, status);
            _nominationDAL.AddNominationComment(nominationComment);

            _nominationDAL.AddNominationHistory(nominationHistory);
        }

        public List<NominationHistoryDTO> GetNominationHistory(DateTime dateFrom, DateTime dateTo, Guid? collaboratorId, int? recognitionTypeId)
        {
            return _nominationDAL.GetNominationHistory(dateFrom, dateTo, collaboratorId, recognitionTypeId);
        }
    }
}