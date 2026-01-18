using Google.Cloud.Firestore;

namespace Gas_station_Automation_MVC.Models;

[FirestoreData]
public class Customer
{
    [FirestoreProperty]
    public string Id { get; set; } = string.Empty;
    [FirestoreProperty]
    public string Name { get; set; } = string.Empty;
    [FirestoreProperty]
    public string Email { get; set; } = string.Empty;
    [FirestoreProperty]
    public string PhoneNumber { get; set; } = string.Empty;
}

