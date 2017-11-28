using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tournament_Web_Interface.Models;

namespace Tournament_Web_Interface.Controllers
{
    public class TournamentController : Controller
    {
        static List<PlayerModel> PlayerList = new List<PlayerModel>();
        public IActionResult ShowPlayers()
        {
            return View(PlayerList);
        }

        public IActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePlayer(PlayerModel newPlayer)
        {
            return RedirectToAction("ShowPlayers");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}