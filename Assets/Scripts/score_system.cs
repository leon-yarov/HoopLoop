using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class score_system : MonoBehaviour
{
    private int score = 0; //game's current score

    public Text score_text; //get the UI of score
    public Text score_text_shadow; //for decoration
    public void AddScore(int value) //add score by value passed
    {
        score += value;
        score_text.text = "SCORE: " + score;
        score_text_shadow.text = score_text.text;
    }
}
