using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

public class HomeController : Controller
  {

        [Route("/")]
        public ActionResult Index()
        {
          return View();
        }

    }
