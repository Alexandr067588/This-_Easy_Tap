using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// все числовые значения задействование в игре
/// </summary>
[CreateAssetMenu (fileName = "Value For Game ",menuName = "Value For Game")]
public class ValueForGame : ScriptableObject
{
    /// <summary>
    /// максимальная минимальная скорость
    /// </summary>
    [SerializeField] Vector2 speed;
    /// <summary>
    /// максимальная минимальная гравитация
    /// </summary>
    [SerializeField] Vector2 gravity;
    /// <summary>
    /// начальное положение
    /// </summary>
    [SerializeField] Vector2 startPosition;
    /// <summary>
    /// размер игрового поля
    /// </summary>
    [SerializeField] Vector2 sizeGameBoard;
    /// <summary>
    /// время до появления нового обьекта
    /// </summary>
    [SerializeField] float timerForCreateNewItem;
    /// <summary>
    /// максимальное кол-во обьектов на поле
    /// </summary>
    [SerializeField] int curentMaxCountPoolItem;
    float returnSpeed__
    {
        get
        {
            return Random.Range(speed.x, speed.y);
        }
    }
    float returnGravity__
    {
        get
        {
            return Random.Range(gravity.x, gravity.y);
        }
    }
    Vector2 returnStartPosition__
    {
        get
        {
            return startPosition;
        }
    }
    Vector2 StartPosition()
    {
        return returnStartPosition__;
    }
    float ReturnValue(TypeValueMoveComponent typeValue)
    {
        var returnValue = 0f;

        switch (typeValue)
        {
            case TypeValueMoveComponent.Gravity:
                returnValue = returnGravity__;
                break;
            case TypeValueMoveComponent.Speed:
                returnValue = returnSpeed__;
                break;
            default:
                break;
        }
        return returnValue;
    }
    void SizeGameBoard(Vector2 size)
    {
        sizeGameBoard = new Vector2();
        sizeGameBoard = size;
    }
    Vector2 ReturnSizeGameBoard()
    {
        return sizeGameBoard;
    }
    float TimerForCreateNewItem()
    {
        return timerForCreateNewItem;
    }
    int CurentMaxCountPoolItem()
    {
        return curentMaxCountPoolItem;
    }
    private void OnEnable()
    {
        AllEventSystem.ValueForMoveComponentEvent += ReturnValue;
        AllEventSystem.StartPositionItemEvent += StartPosition;
        AllEventSystem.SizeGameBoardEvent += ReturnSizeGameBoard;
        AllEventSystem.TimerForCreateNewItemEvent += TimerForCreateNewItem;
        AllEventSystem.MaxCountPoolItemEvent += CurentMaxCountPoolItem;
        ColliderForCursor.SizeGameBoardEvent += SizeGameBoard;

    }


}
