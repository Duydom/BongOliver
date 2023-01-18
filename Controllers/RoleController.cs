using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BongOliver.API.DTOs.RoleDTO;
using BongOliver.API.Services.RoleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BongOliver.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize]
        [HttpGet("")]
        public ActionResult<List<RoleDto>> GetRoles()
        {
            return Ok(_roleService.GetRoles());
        }
    }
}