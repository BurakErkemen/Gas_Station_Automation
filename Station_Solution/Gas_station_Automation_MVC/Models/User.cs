using Google.Cloud.Firestore;
using Google.Protobuf.WellKnownTypes;
using System.ComponentModel.DataAnnotations;

namespace Gas_station_Automation_MVC.Models;

[FirestoreData]
public class User
{
    [FirestoreDocumentId]
    public string Id { get; set; } = default!;

    [FirestoreProperty]
    public string Email { get; set; } = default!;

    [FirestoreProperty]
    public string? PhoneNumber { get; set; }

    [FirestoreProperty]
    [Required(ErrorMessage = "Ad Soyad zorunludur")]
    [StringLength(100, MinimumLength = 2)]
    public required string DisplayName { get; set; }

    [FirestoreProperty]
    public required string Role { get; set; } // "admin", "moderator", "customer"

    [FirestoreProperty]
    public Google.Cloud.Firestore.Timestamp CreatedAt { get; set; }

    [FirestoreProperty]
    public Google.Cloud.Firestore.Timestamp? LastLoginAt { get; set; }

    [FirestoreProperty]
    public string CreatedByUid { get; set; } = default!;

    [FirestoreProperty]
    public bool IsActive { get; set; } = true;

}

