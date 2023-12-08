using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int starsAwarded;
    public GameObject finishedScreen;
    public Image starsImageOutput;
    public TextMeshProUGUI scorePercOutput;
    public Sprite[] starSprites;
    public Button nextButton;

    private int mapMaxScore;
    private int playerScore;
    private float percOfMax;
    private bool finished = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        GameObject[] factories = GameObject.FindGameObjectsWithTag("Factory");
        GameObject[] bridges = GameObject.FindGameObjectsWithTag("Bridge");

        int numHouses = houses.Length;
        int numFactories = factories.Length;
        int numBridges = bridges.Length;

        mapMaxScore = numHouses * 50 * 10 + numBridges * 100 * 10 + numFactories * 150 * 10;
    }


    public void OnPlayerFinished(int score)
    {
        if (!finished)
        {
            finished = true;
            playerScore = score;

            Debug.Log(playerScore.ToString());

            CalculateStars();
            SavePlayerPrefs();

            finishedScreen.SetActive(true);
            SetPercentage();
            SetStarSprite();

            Debug.Log("starsAwarded: ");
            Debug.Log(starsAwarded);
            Debug.Log("percOfMax");
            Debug.Log(percOfMax);
            Debug.Log("");
        }
    }


    void CalculateStars()
    {
        // Destruction of 0 - 20 % gives 0 stars - loss
        // 21 - 40 % gives 1 star
        // 41 – 70 % gives 2 stars - next level unlocked
        // 71 – 100 % gives 3 stars.

        percOfMax = (playerScore / mapMaxScore) * 100;

        if (percOfMax <= 20 ) { starsAwarded = 0; }
        else if ((percOfMax > 20) && (percOfMax <= 40)) { starsAwarded = 1; }
        else if ((percOfMax > 40) && (percOfMax <= 70)) { starsAwarded = 2; }
        else if ((percOfMax > 70) && (percOfMax <= 100)) { starsAwarded = 3; }
    }

    void SavePlayerPrefs()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string sceneScore = currentSceneName + "score";
        string sceneStars = currentSceneName + "stars";

        PlayerPrefs.SetFloat(sceneScore, percOfMax);
        PlayerPrefs.SetInt(sceneStars, starsAwarded);
    }

    void SetPercentage()
    {
        int percentage = (int)percOfMax;
        scorePercOutput.text = percentage.ToString() + "%";
    }

    void SetStarSprite()
    {
        Sprite sprite = starSprites[starsAwarded];
        starsImageOutput.sprite = sprite;

        if (starsAwarded >= 2)
        {
            nextButton.interactable = true;
        }
    }
}
