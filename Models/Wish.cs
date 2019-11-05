using Wishlist2.Interfaces;

namespace Wishlist2.Models
{
  public class Wish : IWish
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
  }
}