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
    public FlakSpawner flakSpawner;

    private int mapMaxScore;
    private int playerScore;
    private float percOfMax;
    private bool finished;


    // Start is called before the first frame update
    void Start()
    {
        finished = false;

        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        GameObject[] factories = GameObject.FindGameObjectsWithTag("Factory");
        GameObject[] bridges = GameObject.FindGameObjectsWithTag("Bridge");
        GameObject[] airports = GameObject.FindGameObjectsWithTag("Airport");

        int numHouses = houses.Length;
        int numFactories = factories.Length;
        int numBridges = bridges.Length;
        int numAirports = airports.Length;

        mapMaxScore = numHouses * 500 + numBridges * 1000 + numFactories * 1500 + numAirports * 2000;
    }


    public void OnPlayerFinished(int score)
    {
        if (!finished)
        {
            finished = true;
            playerScore = score;

            CalculateStars();
            SavePlayerPrefs();
            flakSpawner.PlayerFinished();

            finishedScreen.SetActive(true);
            SetPercentage();
            SetStarSprite();

            Debug.Log("Max score: " + mapMaxScore);
            Debug.Log("Player score: " + playerScore);
            Debug.Log("starsAwarded: " + starsAwarded);
            Debug.Log("percOfMax: " + percOfMax);

        }
    }


    private void CalculateStars()
    {
        // Destruction of 0 - 20 % gives 0 stars - loss
        // 21 - 40 % gives 1 star
        // 41 – 70 % gives 2 stars - next level unlocked
        // 71 – 100 % gives 3 stars.

        percOfMax = ((float)playerScore / mapMaxScore) * 100;

        if (percOfMax <= 20 ) { starsAwarded = 0; }
        else if ( (percOfMax > 20) && (percOfMax <= 40) ) { starsAwarded = 1; }
        else if ( (percOfMax > 40) && (percOfMax <= 70) ) { starsAwarded = 2; }
        else if ( (percOfMax > 70) && (percOfMax <= 100) ) { starsAwarded = 3; }
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
