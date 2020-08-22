using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class score_system : MonoBehaviour
{
    private int score = 0;
    public Text score_text;
    public Text score_text_shadow;
    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
        score_text.text = "SCORE: " + score;
        score_text_shadow.text = score_text.text;
    }
}
