using AutoMapper;
using HomeBiuld.Data;
using HomeBiuld.Dto;
using HomeBiuld.Model;
using HomeBiuld.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HomeBiuld.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BedController : Controller
    { 
        public readonly GeneraicRepo<Bad> _repo;

        public readonly IMapper _mapper;

        public BedController(AppDbContext context, IMapper mapper)
        {
            _repo = new implementGeneraicRepo<Bad>(context);
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(type: typeof(IEnumerable<BedDto>), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetBeds()
        {
            var x = _mapper.Map<List<BedDto>>(_repo.list());

            return (ModelState.IsValid) ? Ok(x) : BadRequest(ModelState);
        }

        [HttpGet("Bed/{id}")]
        [ProducesResponseType(type: typeof(BedDto), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetBed(int id)
        {
            return (_repo.Get(id) != null) ? Ok(_mapper.Map<BedDto>(_repo.Get(id))) : BadRequest(ModelState);
        }


        [HttpGet("/Bedcount")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult CountBeds()
        {
            var x = _repo.list();
            return (x.Count() >= 0) ? Ok(x.Count()) : BadRequest(ModelState);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(BedDto b)
        {
            if (b == null)
                return BadRequest(ModelState);

           
           var result= _repo.Add(_mapper.Map<Bad>(b));

            if(result == null)
                return BadRequest(ModelState);

            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult UpData(BedDto b, [FromQuery] int id)
        {
            var t = _repo.Get(id);
            if (t == null)
                return BadRequest(ModelState);

            if (b.Id != id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var x = _mapper.Map(b, t);
            var result = _repo.updata(x);

            if (result == null)
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

            var result = _repo.Remove(id);

            if (!result)
                return BadRequest(ModelState);

            return Ok(result);
        }



    }
}
