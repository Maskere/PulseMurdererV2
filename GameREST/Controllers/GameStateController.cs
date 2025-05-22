using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameState.Records;

namespace GameState {
    [Route("api/[controller]")]
    [ApiController]
    public class GameStateController : ControllerBase {
        Game game;

        public GameStateController(Game game){
            this.game = game;
        }

        // GET: api/<GameStateController>
        [HttpGet]
        public IActionResult Get() {
            return Ok(game.Round);
        }

        // GET api/<GameStateController>/5
        [HttpGet("{id}")]
        public int Get(int id) {
            return game.Round;
        }

        // POST api/<GameStateController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<GameStateController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GameRecord value) {
            try{
                if(value == null){
                    return BadRequest("Value cannot be null");
                }
                
                Game toConvert = RecordHelper.ConvertGameRecord(value);
                game.Round = toConvert.Round;
                return Ok(game.Round);
            }
            catch(Exception ex){
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<GameStateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
