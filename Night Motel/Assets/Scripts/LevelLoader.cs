using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public bool LevelLoaded=false;
    public void LoadNextLevel()
    {
        
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("End");

        yield return new WaitForSeconds(1f); // Adjust the wait time to match your animation duration

        SceneManager.LoadSceneAsync(levelIndex);

        animator.SetTrigger("Start");



    }
}
