using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;

namespace SurveyAPI.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        Task<Question> CreateQuestion(Question question);
        Task UpdateQuestion(Question question);
        Task DeleteQuestion(int id);
    }
}
