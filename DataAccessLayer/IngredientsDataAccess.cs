using Dapper;
using DomainModel.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class IngredientsDataAccess
    {
        public void AddIngredient(Ingredient ingredient)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CookBookConnectionString"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("dbo.InsertIngredientProcedure @Name, @Weight, @KcalPer100g, @PricePer100g, @Type", ingredient);
            }
        }
    }
}
