using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class AccountRepository
    {

        IDbConnection _db;

        //REGISTER
        public void Register(User user)
        {
            //generate the user id
            //HASH THE PASSWORD
            string sql = @"
                INSERT INTO users 
                (id, username, email, hash)
                VALUES 
                (@id, @username, @email, @Hash)";
            _db.Execute(sql, user);
        }

        internal User GetUserByEmail(string email)
        {
            string sql = "SELECT * FROM users WHERE email = @email";
            return _db.QueryFirstOrDefault<User>(sql, new { email });
        }

        internal User GetUserById(string id)
        {
            string sql = "SELECT * FROM users WHERE id = @id";
            return _db.QueryFirstOrDefault<User>(sql, new { id });
        }

        public AccountRepository(IDbConnection db)
        {
            _db = db;
        }

    }
}