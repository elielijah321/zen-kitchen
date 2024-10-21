using System.Collections.Generic;
using System.Linq;
using AzureFunctions.Mappers;
using Microsoft.EntityFrameworkCore;
using Project.Function;

namespace AzureFunctions.Database
{
    public class ProjectRepo
    {
        private readonly ProjectContext _ctx;

        public ProjectRepo(ProjectContext ctx)
        {
            _ctx = ctx;
        }

        // Allergies
         public string AddAllergy(UpdateAllergyRequestModel request)
         {
            var mappedEntity = request.ToModel();

            _ctx.Allergies.Add(mappedEntity);
            SaveAll();

            return mappedEntity.Id.ToString();
         }

        public string UpdateAllergy(UpdateAllergyRequestModel request)
        {
            var mappedEntity = request.ToModel();

            var entityToUpdate = _ctx.Allergies.FirstOrDefault(c => c.Id == mappedEntity.Id);

            entityToUpdate.Name = mappedEntity.Name;

            SaveAll();

            return mappedEntity.Id.ToString();
        }

        public IEnumerable<Allergy> GetAllAllergies()
        {
           return _ctx.Allergies;
        }

        public Allergy GetAllergyById(string id)
        {
           return GetAllAllergies().FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void DeleteAllergyById(string id)
        {
            var allergy = _ctx.Allergies.FirstOrDefault(a => a.Id.ToString() == id);
            
           _ctx.Allergies.Remove(allergy);
           SaveAll();
        }

        // Ingredients
         public string AddIngredient(UpdateIngredientRequestModel request)
         {
            var mappedEntity = request.ToModel();

            _ctx.Ingredients.Add(mappedEntity);
            SaveAll();

            return mappedEntity.Id.ToString();
         }

        public string UpdateIngredient(UpdateIngredientRequestModel request)
        {
            var mappedEntity = request.ToModel();

            var entityToUpdate = _ctx.Ingredients.FirstOrDefault(c => c.Id == mappedEntity.Id);

            entityToUpdate.Name = mappedEntity.Name;
            entityToUpdate.Calories = mappedEntity.Calories;
            entityToUpdate.Protein = mappedEntity.Protein;
            entityToUpdate.Weight = mappedEntity.Weight;
            entityToUpdate.UnitOfMeasureMent = mappedEntity.UnitOfMeasureMent;

            SaveAll();

            return mappedEntity.Id.ToString();
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
           return _ctx.Ingredients
                  .OrderByDescending(r => r.Name);;
        }

        public Ingredient GetIngredientById(string id)
        {
           return GetAllIngredients().FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void DeleteIngredientById(string id)
        {
            var ingredient = _ctx.Ingredients.FirstOrDefault(a => a.Id.ToString() == id);

            var recipeItems = _ctx.RecipeItems.Where(r => r.IngredientId == ingredient.Id);
            
           _ctx.Ingredients.Remove(ingredient);
           _ctx.RecipeItems.RemoveRange(recipeItems);

           SaveAll();
        }


        // Recipes
         public string AddRecipe(UpdateRecipeRequestModel request)
         {
            var mappedEntity = request.ToModel();

            _ctx.Recipes.Add(mappedEntity);
            SaveAll();

            return mappedEntity.Id.ToString();
         }

        public string UpdateRecipe(UpdateRecipeRequestModel request)
        {
            var mappedEntity = request.ToModel();

            var entityToUpdate = _ctx.Recipes.FirstOrDefault(c => c.Id == mappedEntity.Id);

            var previousIngredients = _ctx.RecipeItems.Where(r => r.RecipeId == mappedEntity.Id);
            _ctx.RecipeItems.RemoveRange(previousIngredients);

            entityToUpdate.Name = mappedEntity.Name;
            entityToUpdate.Price = mappedEntity.Price;
            entityToUpdate.Ingredients = request.Ingredients;

            SaveAll();

            return mappedEntity.Id.ToString();
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
           return _ctx.Recipes
                     .Include(r => r.Ingredients)
                        .ThenInclude(i => i.Ingredient)
                  .OrderBy(r => r.CreatedAt);
        }

        public Recipe GetRecipeById(string id)
        {
           var t = GetAllRecipes().FirstOrDefault(x => x.Id.ToString() == id);

           return t;
        }

        public void DeleteRecipeById(string id)
        {
            var recipe = _ctx.Recipes.FirstOrDefault(a => a.Id.ToString() == id);
            var recipeItems = _ctx.RecipeItems.Where(r => r.RecipeId == recipe.Id);
            
           _ctx.RecipeItems.RemoveRange(recipeItems);
           _ctx.Recipes.Remove(recipe);

           SaveAll();
        }

         // Menu
         public string AddMenu(UpdateMenuRequestModel request)
         {
            var mappedEntity = request.ToModel();

            _ctx.Menus.Add(mappedEntity);
            SaveAll();

            return mappedEntity.Id.ToString();
         }

        public string UpdateMenu(UpdateMenuRequestModel request)
        {
            var mappedEntity = request.ToModel();

            var entityToUpdate = _ctx.Menus.FirstOrDefault(c => c.Id == mappedEntity.Id);

            var previousRecipes = _ctx.MenuItems.Where(r => r.MenuId == mappedEntity.Id);
            _ctx.MenuItems.RemoveRange(previousRecipes);

            entityToUpdate.Name = mappedEntity.Name;
            entityToUpdate.Recipes = request.Recipes;

            SaveAll();

            return mappedEntity.Id.ToString();
        }

        public IEnumerable<Menu> GetAllMenus()
        {
           return _ctx.Menus
                     .Include(m => m.Recipes)
                        .ThenInclude(m => m.Recipe)
                     .OrderBy(m => m.CreatedAt);
        }

        public Menu GetMenuById(string id)
        {
           return GetAllMenus().FirstOrDefault(x => x.Id.ToString() == id);
        }

        public void DeleteMenuById(string id)
        {
            var menu = _ctx.Menus.FirstOrDefault(a => a.Id.ToString() == id);
            var menuItems = _ctx.MenuItems.Where(r => r.MenuId == menu.Id);
            
           _ctx.MenuItems.RemoveRange(menuItems);
           _ctx.Menus.Remove(menu);

           SaveAll();
        }

        public void PostCurrentMenu(UpdateMenuRequestModel menu)
        {
            var setting = GetSetting(SettingConstants.CURRENT_MENU_ID);
            setting.Value = menu.Id.ToString();
            UpdateSetting(setting);   
        }

        public string GetCurrentMenuId()
        {
            var setting = GetSetting(SettingConstants.CURRENT_MENU_ID);

            return setting.Value;
        }

        //Settings 
        public List<Setting> GetAllSettings()
        {
            return _ctx.Settings
                        .ToList();
        }

        public Setting GetSetting(string id)
        {
            return GetAllSettings().FirstOrDefault(s => s.Id.ToString() == id);
        }

        public void AddNewSetting(Setting setting)
        {
            _ctx.Settings.Add(setting);
            SaveAll();
        }

        public void UpdateSetting(Setting settingToUpdate)
        {
            var originalSetting = _ctx.Settings.FirstOrDefault(s => s.Id == settingToUpdate.Id);

            originalSetting.Name = settingToUpdate.Name;
            originalSetting.Value = settingToUpdate.Value;
           
            SaveAll();
        }

        // Save
        private bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}