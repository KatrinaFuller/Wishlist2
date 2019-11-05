using System;
using System.Collections.Generic;
using System.Data;
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
      throw new NotImplementedException();
    }

    public IEnumerable<Wish> GetWishesByUserId(string userId)
    {
      throw new NotImplementedException();
    }
    public Wish GetWishByWishId(int id)
    {
      throw new NotImplementedException();
    }

    public int Create(Wish newWish)
    {
      throw new NotImplementedException();
    }

    public void Edit(Wish wish)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}