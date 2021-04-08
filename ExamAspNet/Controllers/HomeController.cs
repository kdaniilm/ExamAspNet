using AutoMapper;
using ExamAspNet.Models;
using ExamAspNet.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExamContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ExamContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var matches = await _context.Matches.ToListAsync();
            return await Task<ActionResult>.Run(() => View(matches));
        }
        //public async Task<ActionResult> FilterAsync(Filter filter)
        //{
        //    var matches = await _context.Matches.Where(x => x.StartTime == filter.Time).ToListAsync();
        //    return PartialView("GetMatchPartial", matches);
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
