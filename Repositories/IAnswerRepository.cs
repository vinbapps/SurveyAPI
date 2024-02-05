using SurveyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyAPI.Repositories
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAll();
        Task<Answer> GetById(int id);
        Task<IEnumerable<Answer>> GetByQuestionId(int questionId);
        Task<IEnumerable<Answer>> GetByUserId(int userId);
        Task<Answer> Add(Answer answer);
        Task Update(Answer answer);
        Task Delete(int id);
    }
}
