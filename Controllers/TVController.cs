using AutoMapper;
using HomeBiuld.Data;
using HomeBiuld.Dto;
using HomeBiuld.Model;
using HomeBiuld.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HomeBiuld.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TVController : Controller
    {


        public readonly GeneraicRepo<Tv> _repo;

        public readonly IMapper _mapper;

        public TVController(AppDbContext context,IMapper mapper)
        {
            _repo = new implementGeneraicRepo<Tv>(context);
            _mapper = mapper;
        }


        [HttpGet("TVs")]
        [ProducesResponseType(type: typeof(IEnumerable<TvDto>), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetTvs()
        {
            var x =_mapper.Map<List<TvDto>>( _repo.list());
            
            return (ModelState.IsValid) ? Ok(x) : BadRequest(ModelState);
        }

        [HttpGet("Tv/{id}")]
        [ProducesResponseType(type: typeof(Tv), 200)]
        [ProducesResponseType(400)]

        public IActionResult GetTv(int id)
        {
            return (_repo.Get(id) != null) ? Ok(_mapper.Map<TvDto>( _repo.Get(id))) : BadRequest(ModelState);
        }


        [HttpGet("/Tvcount")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult CountTvs()
        {
            var x = _repo.list();
            return (x.Count() >= 0) ? Ok(x.Count()) : BadRequest(ModelState);
        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Create(TvDto b)
        {
            if (b == null)
                return BadRequest(ModelState);


            var result = _repo.Add(_mapper.Map<Tv>(b));

            if (result == null)
                return BadRequest(ModelState);

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult UpData(TvDto b, [FromQuery]int id)
        {
            var t = _repo.Get(id);
            if (t == null)
                return BadRequest(ModelState);

            if(b.Id != id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            var x = _mapper.Map(b,t);
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
