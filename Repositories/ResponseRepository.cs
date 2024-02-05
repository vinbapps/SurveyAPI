using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SurveyAPI.Models;

namespace SurveyAPI.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly SurveyContext _context;

        public ResponseRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Response>> GetResponsesByUserId(int userId)
        {
            return await _context.Response.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Response>> GetResponsesByQuestionId(int questionId)
        {
            return await _context.Response.Where(r => r.QuestionId == questionId).ToListAsync();
        }

        public async Task<IEnumerable<Response>> GetResponsesByUserIdAndQuestionId(int userId, int questionId)
        {
            return await _context.Response
                .Where(r => r.UserId == userId && r.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Response>> GetResponses()
        {
            return await _context.Response.ToListAsync();
        }


        public async Task CreateResponse(Response response)
        {
            _context.Response.Add(response);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateResponse(Response response)
        {
            _context.Entry(response).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteResponse(int id)
        {
            var responseToDelete = await _context.Response.FindAsync(id);
            _context.Response.Remove(responseToDelete);
            await _context.SaveChangesAsync();
        }

        public Task<Response> GetResponse(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
