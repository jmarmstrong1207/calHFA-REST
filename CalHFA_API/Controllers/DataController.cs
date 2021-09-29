﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalHFA_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        // ALL OF THESE ARE ASYNC. PUT AWAIT KEYWORD BEFORE LONG CALLS LIKE ACCESSING DATABASE TO INCREASE ASYNCHRONOUS ABILITIES

        [HttpGet]
        public async Task<string> Index()
        {
            return "This is the index";
        }

        // GET: api/data/*string to put*
        [HttpGet("{str}")]
        public async Task<string> GetString(string str)
        {
            return str;
        }

        // GET: api/data/Details/5
        [HttpGet("details/{id}")]
        public async Task<int> Details(int id)
        {
            return id;
        }
    }
}
