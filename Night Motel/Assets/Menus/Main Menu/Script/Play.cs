using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject videoplayer;
    [SerializeField] private GameObject mainmenupanel;
    public void LoadLevel()
    {
        StartCoroutine(LoadLevelAsync(SceneManager.GetActiveScene().buildIndex + 1));
        videoplayer.SetActive(true);
        mainmenupanel.SetActive(false);
        Cursor.lockState=CursorLockMode.Locked;
    }

    IEnumerator LoadLevelAsync(int sceneindex)
    {
                AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneindex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
