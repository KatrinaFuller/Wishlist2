using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Wishlist2.Models;
using Wishlist2.Services;

namespace Wishlist2.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishesController : ControllerBase
  {
    private readonly WishesService _ws;
    public WishesController(WishesService ws)
    {
      _ws = ws;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Wish>> Get()
    {
      try
      {
        return Ok(_ws.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);

      }
    }

    [HttpGet("user")]
    public ActionResult<IEnumerable<Wish>> GetWishesByUserId()
    {
      try
      {
        var id = HttpContext.User.FindFirstValue("Id");
        return Ok(_ws.GetWishesByUserId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Wish> GetWishByWishId(int id)
    {
      try
      {
        return Ok(_ws.GetWishByWishId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Wish> Create([FromBody] Wish newWish)
    {
      try
      {
        newWish.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ws.Create(newWish));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Wish> Edit([FromBody] Wish editWish, int id)
    {
      try
      {
        editWish.Id = id;
        return Ok(_ws.Edit(editWish));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<int> Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ws.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}