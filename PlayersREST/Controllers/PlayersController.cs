using Microsoft.AspNetCore.Mvc;
using PlayersREST.Records;
using PlayerRepo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace PlayersREST.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase {
        private PlayerRepository? _playerRepository;

        public PlayersController(PlayerRepository playerRepository) {
            _playerRepository = playerRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        // GET: api/<PlayersController>
        [HttpGet]
        public ActionResult<List<Player>> Get() {
            List<Player>? players = _playerRepository?.GetAllPlayers();
            if (players?.Count() > 0) {
                return Ok(players);
            }
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id) {
            Player? player = _playerRepository?.GetPlayerById(id);
            if (player != null) {
                return Ok(player);
            }
            return NotFound(player);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<PlayersController>
            [HttpPost]
            public ActionResult<Player> Post([FromBody] PlayerRecord newPlayerRecord) {
                try {
                    Player? converted = RecordHelper.ConvertPlayerRecord(newPlayerRecord);
                    Player? createdPlayer = _playerRepository?.AddPlayer(converted);
                    return Created("/" + createdPlayer?.Id, createdPlayer);
                }
                catch (ArgumentNullException ex) {
                    return BadRequest(ex.Message);
                }
                catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
            }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public ActionResult<Player> Put(int id, [FromBody] PlayerRecord newValue) {
            try {
                Player? convertedPlayer = RecordHelper.ConvertPlayerRecord(newValue);
                Player? updatedPlayer = _playerRepository?.UpdatePlayer(id, convertedPlayer);

                if (updatedPlayer != null) {
                    return Ok(updatedPlayer);
                }
                else {
                    return NotFound("Player not found");
                }
            }
            catch (ArgumentNullException ex) {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Player> Delete(int id) {
            try{
                Player? toRemove = _playerRepository?.Remove(id);
                return Ok(toRemove);
            }
            catch(ArgumentNullException ex){
                return BadRequest(ex.Message);
            }
        }
    }
}

