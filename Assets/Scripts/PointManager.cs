using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    public int score = 0;
    public Text scoreText;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void AddScore(int pointsToAdd) {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
