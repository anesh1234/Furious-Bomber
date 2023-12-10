using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public MenuCamera mainCamera;
    public GameObject banner;


    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
        banner.SetActive(true);
    }

    public void LoadScene(int sceneId)
    {
        LoadingScreen.SetActive(true);
        mainCamera.MoveCamera();
        StartCoroutine(LoadSceneCoroutine(sceneId));
    }

    private IEnumerator LoadSceneCoroutine(int sceneId)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync(sceneId);
    }
}
