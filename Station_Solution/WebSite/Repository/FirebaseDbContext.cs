using Google.Cloud.Firestore;

namespace WebSite.Repository;

public class FirebaseDbContext
{
    private readonly FirestoreDb _firestoreDb;

    // Constructor that accepts the firebase credential path
    public FirebaseDbContext(string firebaseCredentialPath)
    {
        string firebaseCredentialPat1h = "C:\\Users\\burak\\OneDrive\\Documents\\GitHub\\Gas_Station_Automation\\Station_Solution\\WebSite\\secrets\\firebasecredential.json";

        // Set the Google application credentials using the provided path
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", firebaseCredentialPat1h);

        // Connect to Firestore using the project ID
        _firestoreDb = FirestoreDb.Create("gasstation-3d1c9"); // Replace with your actual Firebase project ID
        Console.WriteLine($"Firestore bağlandı: {_firestoreDb.ProjectId}");
    }

    // Method to get the FirestoreDb instance
    public FirestoreDb GetFirestoreDb()
    {
        return _firestoreDb;
    }
}