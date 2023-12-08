using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class LevelEndScreenInterface : MonoBehaviour
{
    public Image starsImageOutput;
    public TextMeshProUGUI scorePercOutput;
    public Sprite[] starSprites;
    public Button nextButton;


    public void SetPercentage(int percentage)
    {
        scorePercOutput.text = percentage.ToString();
    }

    public void SetStarSprite(int numStars)
    {
        Sprite sprite = starSprites[numStars];
        starsImageOutput.sprite = sprite;

        if (numStars >= 2)
        {
            nextButton.interactable = true;
        }
    }
    
}
