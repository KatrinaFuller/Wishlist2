using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Wishlist2.Models;

namespace Wishlist2.Repositories
{
  public class WishesRepository
  {
    private readonly IDbConnection _db;
    public WishesRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Wish> Get()
    {
      string sql = "SELECT * FROM wishes";
      return _db.Query<Wish>(sql);
    }

    public IEnumerable<Wish> GetWishesByUserId(string userId)
    {
      string sql = "SELECT * FROM wishes WHERE userId = @userId";
      return _db.Query<Wish>(sql, new { userId });
    }
    public Wish GetWishByWishId(int id)
    {
      string sql = "SELECT * FROM wishes WHERE id = @id";
      return _db.QueryFirstOrDefault<Wish>(sql, new { id });
    }

    public int Create(Wish newWish)
    {
      string sql = @"
        INSERT INTO wishes
        (name, description, img, userId)
        VALUES
        (@Name, @Description, @Img, @UserId)";
      return _db.ExecuteScalar<int>(sql, newWish);
    }

    public void Edit(Wish wish)
    {
      string sql = @"
        UPDATE wishes
        SET
            name = @Name,
            description = @Description,
            img = @Img
        WHERE id = @id";
      _db.Execute(sql, wish);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM wishes WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}