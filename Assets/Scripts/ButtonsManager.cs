using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ButtonsManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void Clicked()
    {
        text.color = Color.red;
    }
}
