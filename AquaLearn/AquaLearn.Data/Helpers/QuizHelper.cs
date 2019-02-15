using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AquaLearn.Data.Entities;
using adm = AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaLearn.Data.Helpers
{
    class QuizHelper
    {
        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();
        public static AquaLearnDbContext _dbn = new AquaLearnDbContext();

        private readonly MapperConfiguration quizMap = new MapperConfiguration(mc =>
        {
            mc.Mappers.Add(DomainHelper.nameMapper.GetMappers().FirstOrDefault());

            mc.CreateMap<Quiz, adm.Quiz>()
              .ForMember(m => m.QuizId, u => u.MapFrom(s => s.QuizId))
              .ForAllOtherMembers(m => m.Ignore());
        });

        #region Get
        private List<adm.Quiz> GetQuizzes()
        {
            var du = new List<adm.Quiz>();

            foreach (var item in _db.Quiz.ToList())
            {
                du.Add(new adm.Quiz()
                {
                    UserId = item.UserId,
                    QuizId = item.QuizId,
                    Name = item.Name
                });
            }
            return du;
        }

        public List<adm.Quiz> GetScoresByStudent(int userId)
        {
            var quizzes = GetQuizzes();
            var quizzesForStudent = new List<adm.Quiz>();
            
            foreach(var quiz in quizzes)
            {
                if (quiz.UserId == userId)
                {
                    quizzesForStudent.Add(quiz);
                }
            }

            return quizzesForStudent;
        }

        #endregion

        #region Set
        public static bool SetQuiz(adm.Quiz quiz)
        {
            _db.Quiz.Add(quiz);
            return _db.SaveChanges() == 1;
        }
        #endregion
    }
}
