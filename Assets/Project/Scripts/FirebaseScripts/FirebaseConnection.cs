using Firebase.Database;
using TMPro;
using UnityEngine;

namespace Project.Scripts.FirebaseScripts
{
    public class FirebaseConnection : MonoBehaviour
    {
        [SerializeField] private GoogleAuth _googleAuth;

        private const string UsersRoot = "users";
        private void OnEnable()
        {
            _googleAuth.AuthFinishedEvent += OnAuthStateChanged;
        }

        private void OnDisable()
        {
            _googleAuth.AuthFinishedEvent += OnAuthStateChanged;
        }

        public void OnAuthStateChanged()
        {
            if (_googleAuth.FirebaseAuth.CurrentUser == null)
                return;
            
            Save();
        }


        public void Save()
        {
            string userEmail = PlayerPrefs.GetString(GoogleAuth.EmailPlayerPrefsKey);
            
            DataForSave dataForSave = Serializer.GameData;
            string json = JsonUtility.ToJson(dataForSave);
            FirebaseDatabase.DefaultInstance.RootReference.Child(UsersRoot)
                .Child(userEmail)
                .SetRawJsonValueAsync(json);
        }
    }
}