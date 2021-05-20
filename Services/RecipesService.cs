using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Recipe> GetAll()
        {
            return _repo.GetAll();
        }

        internal Recipe GetById(int id)
        {
            Recipe recipe = _repo.GetById(id);
            if (recipe == null)
            {
                throw new Exception("Invalid Car Id");
            }
            return recipe;
        }
        internal IEnumerable<Recipe> GetByCreatorId(string id)
        {
            return _repo.GetByCreatorId(id);
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }
        internal void Delete(int id, string creatorId)
        {
            Recipe recipe = GetById(id);
            if (recipe.CreatorId != creatorId)
            {
                throw new Exception("You can't delete another user's recipe");
            }
            if (!_repo.Delete(id))
            {
                throw new Exception("Something is Wrong");
            };
        }
    }
}