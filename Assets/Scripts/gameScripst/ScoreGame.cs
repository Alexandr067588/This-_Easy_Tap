using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// счетчик очков
/// </summary>
public class ScoreGame : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text textScore;
    private void Awake()
    {
        score = 0;
        textScore = GetComponent<Text>();
        AllEventSystem.KillItemItemEvent += AddToScore;
        AllEventSystem.TotalScoreEvent += ReturnScore;
    }
    void AddToScore(TypeItem type)
    {
        if (type == TypeItem.Fruit) score++;
        else if (type == TypeItem.Bomb) score--;
        textScore.text = score.ToString();
    }
    int ReturnScore()
    {
        var value = score;
        score = 0;
        return value;
    }
}
