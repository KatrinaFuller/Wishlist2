using System;
using System.Collections.Generic;
using Wishlist2.Models;

namespace Wishlist2.Repositories
{
  public class WishesRepository
  {
    internal IEnumerable<Wish> Get()
    {
      throw new NotImplementedException();
    }

    internal IEnumerable<Wish> GetWishesByUserId(string userId)
    {
      throw new NotImplementedException();
    }
    internal Wish GetWishByWishId(int id)
    {
      throw new NotImplementedException();
    }

    internal int Create(Wish newWish)
    {
      throw new NotImplementedException();
    }

    internal void Edit(Wish wish)
    {
      throw new NotImplementedException();
    }

    internal void Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}