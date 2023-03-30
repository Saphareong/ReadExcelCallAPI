namespace Add50Registration.body
{
    public class LoginResult
    {
        public SubLoginResult result { get; set; }
        public int code { get; set; }
    }

    public class SubLoginResult
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
