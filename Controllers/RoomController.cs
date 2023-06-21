using AutoMapper;
using HomeBiuld.Data;
using HomeBiuld.Dto;
using HomeBiuld.Model;
using HomeBiuld.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeBiuld.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RoomController : Controller
    {

        public readonly RoomRepo _repo;

        public readonly IMapper _mapper;

        public RoomController(AppDbContext context, IMapper mapper)
        {
            _repo = new implemetRoomRepo(context);
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<RoomDto>), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetRooms()
        {
            var x = _mapper.Map<List<RoomDto>>(_repo.GetList());
            return (ModelState.IsValid) ? Ok(x) : BadRequest(ModelState);
        }

        [HttpGet("Room/{id}")]
        [ProducesResponseType(type: typeof(Room), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetRoom(int id)
        {
            return (_repo.GetById(id) != null) ? Ok(_mapper.Map<RoomDto>(_repo.GetById(id))) : BadRequest(ModelState);
        }


        [HttpGet("/Roomcount")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult CountRooms()
        {
            var x = _repo.GetList();
            return (x.Count() >= 0) ? Ok(x.Count()) : BadRequest(ModelState);
        }



        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public IActionResult Create([FromBody] RoomDto room , [FromQuery] int idTv=-1, [FromQuery] int idBed=-1)
        {
            if(idBed <=0 || idTv <=0 || room == null)
                  return BadRequest(ModelState);
            
            var x = _repo.Create(_mapper.Map<Room>(room) , idTv , idBed);

            if(!x)
              return BadRequest(x);

            return Ok(x);
        }

 

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult UpData([FromBody] RoomDto room, [FromQuery] int id)
        {
            var t = _repo.GetById(id);
            if (t == null)
                return BadRequest(ModelState);

            if (room.Id != id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var x = _mapper.Map(room, t);
            bool result = _repo.Update(x);

            if (!result)
                return BadRequest(ModelState);

            return Ok(result);
        }



        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public IActionResult Delete(int id)
        {
            if (id == 0) 
                return BadRequest(ModelState);

            var result =_repo.Delete(id);

            if(!result)
                return BadRequest(ModelState);

            return Ok(result);
        }



    }
}
