using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// кнопки на игровом окне
/// </summary>
public class ButtonGameMenu : MonoBehaviour
{
    [SerializeField] TypeButton typeButton;
    private void OnMouseDown()
    {
        AllEventSystem.ClickTuButtonGameMenu(typeButton);
    }
}
public enum TypeButton
{
    Exit, 
    StartGame
}
