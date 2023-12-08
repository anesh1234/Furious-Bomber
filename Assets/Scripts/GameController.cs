using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int starsAwarded;

    private int mapMaxScore;
    private int playerScore;
    private int numHouses;
    private int numFactories;
    private int numBridges;




    // Start is called before the first frame update
    void Start()
    {
        GameObject[] houses = GameObject.FindGameObjectsWithTag("House");
        GameObject[] factories = GameObject.FindGameObjectsWithTag("Factory");
        GameObject[] bridges = GameObject.FindGameObjectsWithTag("Bridge");

        numHouses = houses.Length;
        numFactories = factories.Length;
        numBridges = bridges.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateStars()
    {
        float percOfMax = playerScore / mapMaxScore;

        if (percOfMax <= 20 ) { starsAwarded = 0; }
        else if ((percOfMax > 20) && (percOfMax <= 40)) { starsAwarded = 1; }
        else if ((percOfMax > 40) && (percOfMax <= 70)) { starsAwarded = 2; }
        else if ((percOfMax > 70) && (percOfMax <= 100)) { starsAwarded = 3; }
        // Destruction of 0 - 20 % gives 0 stars - loss
        // 21 - 40 % gives 1 star
        // 41 – 70 % gives 2 stars - next level unlocked
        // 71 – 100 % gives 3 stars.
    }
}
