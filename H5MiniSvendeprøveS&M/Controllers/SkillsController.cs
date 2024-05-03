﻿using Microsoft.AspNetCore.Mvc;
using ApiRepository;

namespace H5MiniSvendeprøveS_M.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        SkillsRepository repo {  get; set; }
        public SkillsController()
        {
            repo = new SkillsRepository();
        }
    }
}