// SurveyAPI.Controllers.AnswerController.cs
using SurveyAPI.Models;
using SurveyAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Answer>> GetAnswers()
        {
            return await _answerRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetAnswer(int id)
        {
            var answer = await _answerRepository.GetById(id);
            if (answer == null)
            {
                return NotFound();
            }

            return answer;
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> PostAnswer([FromBody] Answer answer)
        {
            var newAnswer = await _answerRepository.Add(answer);
            return CreatedAtAction(nameof(GetAnswers), new { id = newAnswer.Id }, newAnswer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAnswer(int id, [FromBody] Answer answer)
        {
            if (id != answer.Id)
            {
                return BadRequest();
            }

            await _answerRepository.Update(answer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnswer(int id)
        {
            var answerToDelete = await _answerRepository.GetById(id);
            if (answerToDelete == null)
                return NotFound();

            await _answerRepository.Delete(answerToDelete.Id);
            return NoContent();
        }
    }
}
