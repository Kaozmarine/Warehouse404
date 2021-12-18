namespace Warehouse404.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Role Role { get; set; }

        public string Login { get; set; } = string.Empty;
    }
}
