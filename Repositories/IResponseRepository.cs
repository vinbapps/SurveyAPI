using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;

namespace SurveyAPI.Repositories
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetResponsesByUserId(int userId);
        Task<IEnumerable<Response>> GetResponsesByQuestionId(int questionId);
        Task<IEnumerable<Response>> GetResponsesByUserIdAndQuestionId(int userId, int questionId);
        Task<Response> GetResponse(int id); // Add this method
        Task CreateResponse(Response response);
        Task UpdateResponse(Response response);
        Task DeleteResponse(int id);
    }
}
