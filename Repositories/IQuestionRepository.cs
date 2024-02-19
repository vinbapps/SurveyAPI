using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;

namespace SurveyAPI.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> Get();
        Task<Question> Get(int id);
        Task<Question> Create(Question question);
        Task Update(Question question);
        Task Delete(int id);
    }
}
