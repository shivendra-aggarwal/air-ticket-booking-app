using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.A2b.Data.Enumerations.A2bEnums;

namespace API.A2b.Data
{
    public class InitializeDb
    {
        public static void LoadMeals(A2bDbContext a2BDbContext)
        {
            if (!a2BDbContext.Meals.Any())
            {
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 1,
                    MealTypeCode = MealTypeEnum.Veg.ToString(),
                    Price = 400,
                    ExternalId = Guid.NewGuid()
                });

                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 2,
                    MealTypeCode = MealTypeEnum.NonVeg.ToString(),
                    Price = 600,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 3,
                    MealTypeCode = MealTypeEnum.Snack.ToString(),
                    Price = 200,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 4,
                    MealTypeCode = MealTypeEnum.Veg.ToString(),
                    Price = 400,
                    ExternalId = Guid.NewGuid()
                });

                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 5,
                    MealTypeCode = MealTypeEnum.NonVeg.ToString(),
                    Price = 600,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 6,
                    MealTypeCode = MealTypeEnum.Snack.ToString(),
                    Price = 200,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 7,
                    MealTypeCode = MealTypeEnum.Veg.ToString(),
                    Price = 400,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 8,
                    MealTypeCode = MealTypeEnum.NonVeg.ToString(),
                    Price = 600,
                    ExternalId = Guid.NewGuid()
                });
                a2BDbContext.Meals.Add(new Models.Meal()
                {
                    MealId = 9,
                    MealTypeCode = MealTypeEnum.Snack.ToString(),
                    Price = 200,
                    ExternalId = Guid.NewGuid()
                });

                a2BDbContext.SaveChanges();
            }
        }
    }
}
