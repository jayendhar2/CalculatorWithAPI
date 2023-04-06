using CoinApi.Context;
using CoinApi.DB_Models;
using CoinApi.Request_Models;
using CoinApi.Shared;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data.SqlClient;
using static CoinApi.Shared.ApiFunctions;

namespace CoinApi.Services.Exercise
{
    public class ExerciseService : IExerciseService
    {
        public List<Object> loadDB()
        {
            List<Object> result = new List<Object>(10);
            Random r = new Random();    
            for (int i = 0;i < 10;i++)
            {
                Problem pr = new Problem();
                int num1 = r.Next(10, 100);
                int num2 = r.Next(10, 100);
                int sum = num1 + num2;
                pr.problem = num1 + " + " + num2 + " = ?";
                pr.rightResult = sum;
                pr.wrongResult1 = r.Next(10, 100);
                pr.wrongResult2 = r.Next(10, 100);
                result.Add(pr);
            }
            return result;
        }
    }
}
