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
            var Answer = await _answerRepository.GetById(id);
            if (Answer == null)
            {
                return NotFound();
            }

            return Answer;
        }

        [HttpPost]
        public async Task<ActionResult<Answer>>PostAnswer([FromBody] Answer answer)
        {
            var newAnswer = await _answerRepository.Add(answer);
            return CreatedAtAction(nameof(GetAnswers), new { id = newAnswer.Id }, newAnswer);
        }

        [HttpPut]
        public async Task<ActionResult> PutAnswer(int id, [FromBody] Answer answer)
        {
            if(id != answer.Id)
            {
                return BadRequest();
            }

            await _answerRepository.Update(answer);

            return NoContent();


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnswer (int id)
        {
            var AnswerToDelete = await _answerRepository.GetById(id);
            if (AnswerToDelete == null)
                return NotFound();

            await _answerRepository.Delete(AnswerToDelete.Id);
            return NoContent();
        }
    }
}
