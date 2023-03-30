namespace Add50Registration.body
{
    public class RegistrationBody
    {
        public int eventId { get; set; }
        public string eventCode { get; set; }
        public DateTime participationDate { get; set; }

        public RegisterLocation registerLocation { get; set; }
    }

    public class RegisterLocation
    {
        public string address { get; set; }

        public Compound compound { get; set; }

        public NotLocation location { get; set; }
    }

    public class NotLocation
    {
        public string lat { get;  set; }
        public string lng { get; set; }
    }

    public class Compound
    {
        public string district { get; set; }
        public string commune { get; set; }
        public string province { get; set; }
    }
}
