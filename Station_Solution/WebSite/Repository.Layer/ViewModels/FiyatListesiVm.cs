using Google.Cloud.Firestore;

namespace WebSite.Repository.Layer.ViewModels
{
    public class FiyatListesiVm
    {
        public double LPG { get; set; }
        public double Diesel { get; set; }
        public double EuroDiesel { get; set; }
        public double Benzin { get; set; }
    }
}
