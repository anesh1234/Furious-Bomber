using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public GameObject loadingScreen;

    public void Paused()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnToMainMenu()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneCoroutine("Main Menu"));
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextMap()
    {
        int sceneId = SceneManager.GetActiveScene().buildIndex + 1;

        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneCoroutine(sceneId));
    }


    private IEnumerator LoadSceneCoroutine(object sceneId)
    {
        if (sceneId is int) 
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadSceneAsync((int)sceneId);
        }
        if (sceneId is string) 
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadSceneAsync((string)sceneId);
        }
    }
}
