using Dapper;
using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    private string connectionString;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
        connectionString = @"Persist Security Info=False;User ID=sa;password=p@ssw0rd;Initial Catalog=MinimalAPIDB;Data Source=(localdb)\MSSQLLocalDB;Connection Timeout=100000;";
    }
    public IDbConnection connection
    {
        get { return new SqlConnection(connectionString); }
    }
    public IEnumerable<UserModel> GetAll()
    {
        using(IDbConnection dbConnection = connection)
        {
            string sQuery = @"select * from dbo.[User]";
            dbConnection.Open();
            return dbConnection.Query<UserModel>(sQuery);
        }
    }
    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            storedProcedure: "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Update", user);
    public Task DeleteUser(int id) =>
        _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });

}
