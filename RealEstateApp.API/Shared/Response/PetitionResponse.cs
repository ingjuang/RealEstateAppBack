namespace RealEstateApp.API.Shared.Response
{
    public class PetitionResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string module { get; set; }
        public string URL { get; set; }
        public object result { get; set; }
    }
}
