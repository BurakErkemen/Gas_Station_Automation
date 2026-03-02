using Google.Cloud.Firestore;

namespace Kahramanlar.RepositoryLayer
{
    public class FirebaseDbContext
    {
        private readonly FirestoreDb firestoreDb;

        public FirebaseDbContext(string credentialPath)
        {
            string firebaseCredentialPath = "C:\\Users\\burak\\OneDrive\\Documents\\GitHub\\Gas_Station_Automation\\Station_Solution\\Kahramanlar.RepositoryLayer\\Secrets\\FirebaseCredential.json";

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", firebaseCredentialPath);

            firestoreDb = FirestoreDb.Create("gasstation-3d1c9");
            Console.WriteLine($"Firestore bağlandı: {firestoreDb.ProjectId}");
        }

        public FirestoreDb GetFirestoreDb()
        {
            return firestoreDb;
        }
    }
}
