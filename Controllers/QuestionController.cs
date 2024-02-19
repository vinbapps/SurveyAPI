using SurveyAPI.Models;
using SurveyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _QuestionRepository;

        public QuestionController(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _QuestionRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _QuestionRepository.Get(id);
            if (question == null)
            {
                return NotFound();
            }

            return question;
        }
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion([FromBody] Question question)
        {
            var newQuestion = await _QuestionRepository.Create(question);
            return CreatedAtAction(nameof(GetQuestions), new { id = newQuestion.Id }, newQuestion);
        }


        [HttpPut]
        public async Task<ActionResult> PutQuestion(int id, [FromBody] Question Question)
        {
            if(id != Question.Id)
            {
                return BadRequest();
            }

            await _QuestionRepository.Update(Question);

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion (int id)
        {
            var QuestionToDelete = await _QuestionRepository.Get(id);
            if (QuestionToDelete == null)
                return NotFound();

            await _QuestionRepository.Delete(QuestionToDelete.Id);
            return NoContent();
        }
    }
}
