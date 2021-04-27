using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger; // ghi lại hoạt động hệ thống
        private readonly QLSINHVIENContext _context;
        private IRabbitManager _manager;
        public HomeController(ILogger<HomeController> logger, QLSINHVIENContext context, IRabbitManager manager)
        {
            _logger = logger;
            _context = context;
            _manager = manager;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            //List<SinhVien> sv = _context.SinhVien.ToList(); 
            //return Ok(sv);
            var sv = this._context.SinhVien.Where(x => x.MaSv == "A10");
            _manager.Publish(sv, "demo.exchange.topic.dotnetcore", "topic", "*.queue.durable.dotnetcore.#");
            return Ok(sv);
        }
        [HttpGet]
        [Route("SearchId/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var sv = this._context.SinhVien.Find(id);
            if (sv is null)
            {
                return BadRequest("Không tồn tại SV");
            }
            return Ok(sv);
        }

    }
}