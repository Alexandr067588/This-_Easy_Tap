using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// логиа создания обьектов
/// </summary>
public class LogicCriateItem : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] bool isStart;
    private void Awake()
    {
        AllEventSystem.StopGameEvent += StopGame;
        AllEventSystem.StartGameEvent += StartGame;
    }
    private void Start()
    {
        timer = AllEventSystem.TimerForCreateNewItem();
        StartCoroutine(StartCreate());
    }
    private void OnEnable()
    {
        if(isStart) StartCoroutine(StartCreate());
    }
    private void OnDisable()
    {
        StopCoroutine(StartCreate());
        timer = AllEventSystem.TimerForCreateNewItem();
    }
    IEnumerator StartCreate()
    {
        while (isStart)
        {
            AllEventSystem.CreateNewItem();
            yield return new WaitForSeconds(timer);
        }
        
    }
    void StopGame()
    {
        isStart = false;
    }
    void StartGame()
    {
        isStart = true;
        StartCoroutine(StartCreate());
    }
}
