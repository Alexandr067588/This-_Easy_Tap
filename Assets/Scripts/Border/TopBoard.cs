using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Верхняя граници окна
/// получем нужный компонент редактируем высоту и ширину [ OnEnable ] 
/// если обьект с соответствующим классом попал в поле вызываем нужный метод у обьекта [ OnTriggerEnter2D ]
/// </summary>
public class TopBoard : MonoBehaviour
{

    [SerializeField] BoxCollider2D cMain;

    /// <summary>
    /// получем нужный компонент BoxCollider2D cMain
    /// редактируем высоту  и ширину cMain.size
    /// </summary>
    private void Awake()
    {
        cMain = GetComponent<BoxCollider2D>();
        cMain.size = new Vector2(Screen.width, Screen.height / 2);
    }
    /// <summary>
    /// если обьект с соответствующим классом попал в поле вызываем нужный метод у обьекта 
    /// т.е меняем силу гравитации на противоположную
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveComponent_Item moveObject = collision.GetComponent<MoveComponent_Item>();
        if (moveObject != null) moveObject.ChangeGravity();
    }
}
