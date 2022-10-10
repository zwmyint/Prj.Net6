namespace Prj.Net6.APIFileUpload.Entities
{
    public sealed class UserPwd
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
