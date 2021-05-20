using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _service;

        private readonly AccountsService _acctService;

        public RecipesController(RecipesService service, AccountsService acctService)
        {
            _service = service;
            _acctService = acctService;
        }

        // GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll()
        {
            try
            {
                IEnumerable<Recipe> recipes = _service.GetAll();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET BY ID
        [HttpGet("{id}")]

        public ActionResult<Recipe> GetById(int id)
        {
            try
            {
                Recipe found = _service.GetById(id);
                return Ok(found);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // CREATE
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _acctService.GetOrCreateAccount(userInfo);
                newRecipe.CreatorId = userInfo.Id;

                Recipe recipe = _service.Create(newRecipe);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        [Authorize]

        public async Task<ActionResult<Recipe>> Delete(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                _service.Delete(id, userInfo.Id);
                return Ok("Deleted");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}