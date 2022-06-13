using Microsoft.AspNetCore.Mvc;
using ScrumBoardAPI.DTO;
using ScrumBoardAPI.Repository;

namespace ScrumBoardAPI.Controller;

[Route("api/boards")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IScrumBoardRepository _repository;

    public BoardController(IScrumBoardRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetListBoards()
    {
        IEnumerable<BoardDTO> boards;
        try
        {
            boards = _repository.GetAllBoard();
        }
        catch
        {
            boards = Enumerable.Empty<BoardDTO>();
        }
        return Ok(boards);
    }

    [HttpGet("{boardGUID}")]
    public IActionResult GetBoardByGUID(string boardGUID)
    {
        BoardDTO board;
        try
        {
            board = _repository.GetBoard(boardGUID);
        }
        catch
        {
            return NotFound();
        }
        return Ok(board);
    }

    [HttpPost]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO param)
    {
        try
        {
            _repository.AddBoard(param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardGUID}")]
    public IActionResult DeleteBoard(string boardGUID)
    {
        try
        {
            _repository.DeleteBoard(boardGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardGUID}/column")]
    public IActionResult CreateColumn(string boardGUID, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.AddColumn(boardGUID, param);
        }
        catch
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/column")]
    public IActionResult EditColumn(string boardGUID, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.EditColumn(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardGUID}/column/{columnGUID}")]
    public IActionResult DeleteColumn(string boardGUID, string columnGUID)
    {
        try
        {
            _repository.DeleteColumn(boardGUID, columnGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPost("{boardGUID}/task")]
    public IActionResult CreateTask(string boardGUID, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.AddTask(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/task")]
    public IActionResult EditTask(string boardGUID, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.EditTask(boardGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{boardGUID}/task/{taskGUID}")]
    public IActionResult DeleteTask(string boardGUID, string taskGUID)
    {
        try
        {
            _repository.DeleteTask(boardGUID, taskGUID);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("{boardGUID}/task/{taskGUID}")]
    public IActionResult TransferTask(string boardGUID, string taskGUID, [FromBody] TransferTaskDTO param)
    {
        try
        {
            _repository.TransferTask(boardGUID, taskGUID, param);
        }
        catch
        {
            return BadRequest();
        }
        return Ok();
    }
}
