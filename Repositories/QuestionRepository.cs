using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;
using System.Linq;

namespace SurveyAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyContext _context;

        public QuestionRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> Get()
        {
            return await _context.Question.Include(x=>x.Answers).ToListAsync(); 
        }

        public async Task<Question> Get(int id)
        {
            return await _context.Question.Include(x => x.Answers).Where(x=>x.Id==id).FirstOrDefaultAsync();
        }

        public async Task<Question> Create(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task Update(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var questionToDelete = await _context.Question.FindAsync(id);
            _context.Question.Remove(questionToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
