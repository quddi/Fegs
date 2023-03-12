using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using Google;
using UnityEngine;

namespace Project.Scripts.FirebaseScripts
{
    public class GoogleAuth : MonoBehaviour
    {
        private const string GoogleWebClientId =
            "***.apps.googleusercontent.com";

        private GoogleSignInConfiguration _googleSignInConfiguration;

        private FirebaseAuth _firebaseAuth;

        private bool _authDone = false;
        
        public const string EmailPlayerPrefsKey = "UserEmail";

        public event Action AuthFinishedEvent;

        public FirebaseAuth FirebaseAuth => _firebaseAuth;

        private void Awake()
        {
            if (_authDone == false)
                _googleSignInConfiguration = new GoogleSignInConfiguration()
                {
                    WebClientId = GoogleWebClientId,
                    RequestIdToken = true
                };
        }

        private void Start()
        {
            if (_authDone == false)
            {
                _firebaseAuth = FirebaseAuth.DefaultInstance;
                SignIn();
            }
        }

        public void SignIn()
        {
            GoogleSignIn.Configuration = _googleSignInConfiguration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GoogleSignIn.Configuration.RequestEmail = true;

            GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleAuthFinished);
        }

        private void OnGoogleAuthFinished(Task<GoogleSignInUser> task)
        {
            if (task.IsFaulted)
                return;

            if (task.IsCanceled)
                return;

            Credential credential = GoogleAuthProvider.GetCredential(task.Result.IdToken, null);

            _firebaseAuth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task1 =>
            {
                if (task1.IsFaulted)
                    return;

                if (task1.IsCanceled)
                    return;

                _authDone = true;
                
                PlayerPrefs.SetString(EmailPlayerPrefsKey, Email.Parse(FirebaseAuth.CurrentUser.Email));

                AuthFinishedEvent?.Invoke();
            });
        }
    }
}
