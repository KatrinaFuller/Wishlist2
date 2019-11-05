using System;
using System.Collections.Generic;
using Wishlist2.Models;
using Wishlist2.Repositories;

namespace Wishlist2.Services
{
  public class WishesService
  {
    public readonly WishesRepository _repo;
    public WishesService(WishesRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Wish> Get()
    {
      return _repo.Get();
    }

    public IEnumerable<Wish> GetWishesByUserId(string userId)
    {
      IEnumerable<Wish> exists = _repo.GetWishesByUserId(userId);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public Wish GetWishByWishId(int id)
    {
      Wish exists = _repo.GetWishByWishId(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return exists;
    }

    public Wish Create(Wish newWish)
    {
      int id = _repo.Create(newWish);
      newWish.Id = id;
      return newWish;
    }

    public Wish Edit(Wish editWish)
    {
      Wish wish = _repo.GetWishByWishId(editWish.Id);
      if (wish == null)
      {
        throw new Exception("Invalid Id");
      }
      wish.Name = editWish.Name;
      wish.Description = editWish.Description;
      wish.Img = editWish.Img;
      _repo.Edit(wish);
      return wish;
    }

    public string Delete(int id, string userId)
    {
      Wish exists = _repo.GetWishByWishId(id);
      if (exists == null || exists.UserId != userId)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Wish has been deleted";
    }
  }
}