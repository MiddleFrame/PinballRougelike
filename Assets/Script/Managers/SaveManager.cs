using UnityEngine;

namespace Script.Managers
{
    public class SaveManager : MonoBehaviour
    {
        private static bool isDataLoading;

        private void Awake()
        {
            if (isDataLoading)
                Destroy(gameObject);
            else
            {
                DontDestroyOnLoad(gameObject);
                LoadGame();
            }
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }


        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                SaveGame();
            }
            else
            {
                if (!isDataLoading)
                    LoadGame();
            }
        }


        private static void SaveGame()
        {
            Debug.Log("Save player data.");
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(GameManager.playerData));
        }


        private static void LoadGame()
        {
            Debug.Log("Loading player data.");
            isDataLoading = true;
            GameManager.playerData = JsonUtility.FromJson<PlayerData>(
                PlayerPrefs.GetString("PlayerData", JsonUtility.ToJson(new PlayerData())));
            Debug.Log("Player data complete loading.");
        }
    }
}