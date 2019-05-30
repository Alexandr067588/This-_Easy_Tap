using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// игровая область окна
/// событие для передачи координат курсора [ CoordinatPositionCursorEvent ]
/// получаем все компоненты подгоняем размеры [ OnEnable ]
/// если игровой обьект вышел за граници вызаваем у него нужные методы [ OnTriggerExit2D ]
/// слижение за передвижением курсора по игровому полю и передача координат по событию [ OnMouseDrag ]
/// </summary>
public class ColliderForCursor : MonoBehaviour
{
    [SerializeField] BoxCollider2D cMain;
    public delegate void CoordinatPositionCursorDelegate(Vector3 coordinat);
    public static event CoordinatPositionCursorDelegate CoordinatPositionCursorEvent;
    public delegate void SizeGameBoardDelegate(Vector2 size);
    public static event SizeGameBoardDelegate SizeGameBoardEvent;
    /// <summary>
    /// получаем все компоненты подгоняем размеры экрана
    /// </summary>
    private void Awake()
    {
        cMain = GetComponent<BoxCollider2D>();
        cMain.size = new Vector2(Screen.width, Screen.height);
        if (SizeGameBoardEvent != null)
        {
            SizeGameBoardEvent(cMain.size);
        }
    }
    /// <summary>
    /// если игровой обьект вышел за граници вызаваем у него нужные методы
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        BoxItemComponent returnItemToSpoun = collision.GetComponent<BoxItemComponent>();
        if (returnItemToSpoun != null) collision.gameObject.SetActive(false);
    }
    /// <summary>
    /// слижение за передвижением курсора по игровому полю 
    /// и передача координат по событию
    /// </summary>
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, .1f); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        objPosition.z = 0;
        if (CoordinatPositionCursorEvent != null) CoordinatPositionCursorEvent(objPosition);
        else Debug.LogWarning("Not found listener [ CoordinatPositionCursorEvent ]");
    }
    private void OnMouseDown()
    {
        AllEventSystem.IsPush(true);
    }
    private void OnMouseUp()
    {
        AllEventSystem.IsPush(false);
    }
}
