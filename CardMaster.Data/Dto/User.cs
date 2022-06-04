namespace CardMaster.Data
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
     
        public byte[] PasswordHash { get; set; }
        
        public DateTime Created { get; set; }
    }
}
