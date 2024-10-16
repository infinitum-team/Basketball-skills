using System.Collections;
using System.Collections.Generic;
using MM;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelManager : Singleton<LevelManager> {
 //  public List<GameObject> levels;

   [SerializeField]
   private List<AssetReference> levelAssets;
   private Dictionary<string, AsyncOperationHandle<GameObject>> loadedLevels = new Dictionary<string, AsyncOperationHandle<GameObject>>();
   private GameObject currentLevel;
     void Start() {
      //UnlockNewLevel(4);
     SpawnLevel();
   }

   public void UnlockNewLevel(int index) {
      PlayerPrefs.SetInt(Constants.maxLevelIndex,index);
      LevelUiManager.Instance.levelUiItems[index].Unlock();
   }


   public void SpawnLevel()
   {
      string levelKey = PlayerPrefs.GetInt(Constants.currentLevelIndex).ToString();

      // Check if the current level is already loaded
      if (currentLevel != null)
      {
         // Unload and destroy the current level
         UnloadCurrentLevel();
      }

      // Load the new level
      levelAssets[PlayerPrefs.GetInt(Constants.currentLevelIndex)].LoadAssetAsync<GameObject>().Completed += (asyncOperationHandle) =>
      {
         if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
         {
            currentLevel = Instantiate(asyncOperationHandle.Result); // Instantiate the new level
            loadedLevels[levelKey] = asyncOperationHandle; // Store the handle
         }
         else
         {
            Debug.Log("Failed to load");
         }
      };
   }

// Method to unload the current level
   private void UnloadCurrentLevel()
   {
      string levelKey = PlayerPrefs.GetInt(Constants.currentLevelIndex).ToString();

      if (currentLevel != null)
      {
         // Only release the handle if it exists in the dictionary
         if (loadedLevels.TryGetValue(levelKey, out var handle))
         {
            Addressables.Release(handle); // Release the loaded asset
            loadedLevels.Remove(levelKey); // Remove from the dictionary
         }

         Destroy(currentLevel); // Destroy the current level instance
         currentLevel = null; // Reset the reference
         Debug.Log("Previous level unloaded.");
      }
   }


  
}
