using AutoMapper;
using ExamAspNet.Models;
using ExamAspNet.Models.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNet.Controllers
{
    public class AdminController : Controller
    {
        private readonly ExamContext _context;
        private readonly IMapper _mapper;
        public AdminController(ExamContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            return await Task<ActionResult>.Run(() => View());
        }
        [HttpGet]
        public async Task<ActionResult> MatchControl()
        {
            return await Task<ActionResult>.Run(() => View(new MatchViewModel()));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> MatchControl(MatchViewModel matchView)
        {
            if (ModelState.IsValid)
            {
                var match = _mapper.Map<Match>(matchView);
                await _context.Matches.AddAsync(match);
                await _context.SaveChangesAsync();
            }
            return View("admin/Admin/Index");
        }

        [HttpGet]
        public async Task<ActionResult> UserControl()
        {
            var usersVM = _mapper.Map<List<UserViewModel>>(await _context.Users.ToListAsync());
            return await Task<ActionResult>.Run(() => View(usersVM));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> UserControl(List<UserViewModel> usersVM)
        {
            if (ModelState.IsValid)
            {
                var users = _mapper.Map<UserViewModel>(usersVM);
            }
            return View("Admin/Index");
        }
    }
}
