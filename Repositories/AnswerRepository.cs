using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;
using System.Linq;

namespace SurveyAPI.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly SurveyContext _context;

        public AnswerRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Answer>> GetAll()
        {
            return await _context.Answer.ToListAsync();
        }

        public async Task<Answer> GetById(int id)
        {
            return await _context.Answer.FindAsync(id);
        }

        public async Task<IEnumerable<Answer>> GetByQuestionId(int questionId)
        {
            return await _context.Answer.Where(a => a.QuestionId == questionId).ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetByUserId(int userId)
        {
            return await _context.Answer.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Answer> Add(Answer answer)
        {
            _context.Answer.Add(answer);
            await _context.SaveChangesAsync();

            return answer;
        }

        public async Task Update(Answer answer)
        {
            _context.Entry(answer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var answerToDelete = await _context.Answer.FindAsync(id);
            _context.Answer.Remove(answerToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
