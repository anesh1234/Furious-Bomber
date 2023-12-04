using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    public GameObject LoadingScreen;


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
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneId);
    }
}
