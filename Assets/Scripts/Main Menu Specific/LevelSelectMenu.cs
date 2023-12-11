using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    public Button[] buttons;
    public string[] sceneNames;
    public Sprite[] starSprites;
    public Image[] starSpriteOutputFields;

    // Start is called before the first frame update
    void Start()
    {
        bool nextLevelUnlocked = true;

        for (int i = 0; i < buttons.Length; i++) 
        {
            if (nextLevelUnlocked)
            {
                buttons[i].interactable = true;

                string buttonText = sceneNames[i];

                float score = PlayerPrefs.GetFloat(buttonText + "score", 0);
                int stars = PlayerPrefs.GetInt(buttonText + "stars", 0);

                if (stars >= 2) { nextLevelUnlocked = true; } 
                else { nextLevelUnlocked = false; }

                starSpriteOutputFields[i].sprite = starSprites[stars];
            }
            else 
            { 
                buttons[i].interactable = false;
                starSpriteOutputFields[i].sprite = starSprites[0];
            }
        }
    }
}
