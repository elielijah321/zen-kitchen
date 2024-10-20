using System.Linq;
using Company.Function;

namespace Project.Function
{
    public static class MenuHelper
    {
        private static string domain = "https://script.google.com/macros/s/AKfycbzERc6J5Rv1EVokoYvyWGgoxkOBoVtOkfEkFeJGY9WqZcf85g-iNcwiUS-I09IoeOv0/exec";

        public static async void UpdateMenuSpreadSheet()
        {
            var repo = RepositoryWrapper.GetRepo();

            var menu = repo.GetMenuById(repo.GetCurrentMenuId());

            var recipeNames = menu.Recipes.Select(r => {
                return  r.Recipe.Name;
            });

            GoogleSheetService.PutData(recipeNames);

            await HTTPHelper.CallApiAsync(domain);

        }
    }
}