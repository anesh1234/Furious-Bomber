using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public MenuCamera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }


    public void OnClickBack()
    {
        this.gameObject.SetActive(false);
    }


    public void LoadScene(int sceneId)
    {
        float currentTime = Time.realtimeSinceStartup;

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
