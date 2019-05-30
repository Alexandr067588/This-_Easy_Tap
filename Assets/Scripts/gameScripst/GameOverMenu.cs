using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// менюшка вылазит по завершению времени
/// </summary>
public class GameOverMenu : MonoBehaviour
{
    [SerializeField] Text totalScoreText;
    private void Awake()
    {
        AllEventSystem.StartGameEvent += EndShowMenu;
        AllEventSystem.StopGameEvent += ShowMenu;
        gameObject.SetActive(false);
    }
    void ShowMenu()
    {
        totalScoreText.text = AllEventSystem.TotalScore().ToString();
        gameObject.SetActive(true);
    }
    void EndShowMenu()
    {
        gameObject.SetActive(false);
    }
}
