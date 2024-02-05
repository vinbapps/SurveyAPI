using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SurveyAPI.Models;

namespace SurveyAPI.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SurveyContext _context;

        public QuestionRepository(SurveyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Question.ToListAsync();
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _context.Question.FindAsync(id);
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task UpdateQuestion(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestion(int id)
        {
            var questionToDelete = await _context.Question.FindAsync(id);
            _context.Question.Remove(questionToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
