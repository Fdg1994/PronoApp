namespace Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; } = "https://via.placeholder.com/150x150.png?text=Company+Logo";
        public ICollection<User> Members { get; set; }
    }
}
