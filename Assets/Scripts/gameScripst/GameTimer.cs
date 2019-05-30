using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// панелька с часами 
/// </summary>
public class GameTimer : MonoBehaviour
{
    [SerializeField] Text textTimer;
    const int MIN = 60;
    [SerializeField] int timerValue = MIN;
    private void Awake()
    {
        textTimer = GetComponent<Text>();
        StartCoroutine(StartTimer());
        AllEventSystem.StartGameEvent += StartGame;
    }
    /// <summary>
    /// сам таймер
    /// </summary>
    /// <returns></returns>
    IEnumerator StartTimer()
    {
        while(timerValue >= 0)
        {
            textTimer.text = timerValue.ToString();
            timerValue--;
            yield return new WaitForSeconds(1f);
        }
        if (timerValue < 0)
        {
            StopCoroutine(StartTimer());
            AllEventSystem.StopGameEvent();
        }
    }
    /// <summary>
    /// запускаем таймер по новой
    /// </summary>
    void StartGame()
    {
        timerValue = MIN;
        StartCoroutine(StartTimer());
    }
}
