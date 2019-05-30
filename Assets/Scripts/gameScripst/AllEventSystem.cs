using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// альманах всех событий и статических функций
/// </summary>
public class AllEventSystem
{
    /// <summary>
    /// заполняем структуру для [ MoveComponent_Item ] 
    /// </summary>
    /// <param name="typeValue">скорость или гравитация ... </param>
    /// <returns></returns>
    public delegate float ValueForMoveComponentDelegate(TypeValueMoveComponent typeValue);
    public static ValueForMoveComponentDelegate ValueForMoveComponentEvent;
    /// <summary>
    /// начальная точка всех обьектов на поле
    /// </summary>
    /// <returns></returns>
    public delegate Vector2 StartPositionItemDelegate();
    public static StartPositionItemDelegate StartPositionItemEvent;
    /// <summary>
    /// размер игрового поля 
    /// </summary>
    /// <returns></returns>
    public delegate Vector2 SizeGameBoardDelegate();
    public static SizeGameBoardDelegate SizeGameBoardEvent;
    /// <summary>
    /// Время до появления нового обьекта
    /// </summary>
    /// <returns></returns>
    public delegate float TimerForCreateNewItemDelegate();
    public static TimerForCreateNewItemDelegate TimerForCreateNewItemEvent;
    /// <summary>
    /// появление нового обьекта на поле
    /// </summary>
    public delegate void CreateNewItemDelegate();
    public static CreateNewItemDelegate CreateNewItemEvent;
    /// <summary>
    /// сколько всего будет создано в начале игры обьектов
    /// </summary>
    /// <returns></returns>
    public delegate int MaxCountPoolItemDelegate();
    public static MaxCountPoolItemDelegate MaxCountPoolItemEvent;
    /// <summary>
    /// случайная текстура для обьекта
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public delegate Sprite TextureForParticalDelegate(TypeItem type);
    public static TextureForParticalDelegate TextureForParticalEvent;
    /// <summary>
    /// убили обьект
    /// </summary>
    /// <param name="type"></param>
    public delegate void KillItemDelegate(TypeItem type);
    public static KillItemDelegate KillItemItemEvent;
    /// <summary>
    /// игра остановилась
    /// </summary>
    public delegate void StopGameDelegate();
    public static StopGameDelegate StopGameEvent;
    /// <summary>
    /// игра началась
    /// </summary>
    public delegate void StartGameDelegate();
    public static StartGameDelegate StartGameEvent;
    /// <summary>
    /// общее кол-во заработаных очков
    /// </summary>
    /// <returns></returns>
    public delegate int TotalScoreDelegate();
    public static TotalScoreDelegate TotalScoreEvent;
    public delegate void IsPushDelegate(bool isPush);
    public static IsPushDelegate IsPushEvent;

    /// <summary>
    /// заполняем структуру для [ MoveComponent_Item ] 
    /// </summary>
    /// <param name="typeValue">скорость или гравитация ... </param>
    /// <returns></returns>
    public static float ValueForMoveComponent(TypeValueMoveComponent typeValue)
    {
        if (ValueForMoveComponentEvent != null)
            return ValueForMoveComponentEvent(typeValue);
        else Debug.LogWarning("not found listener [ ValueForMoveComponent ] and value == -1");
        return -1f;
    }
    /// <summary>
    /// начальная точка всех обьектов на поле
    /// </summary>
    /// <returns></returns>
    public static Vector2 StartPositionItem()
    {
        if (StartPositionItemEvent != null)
            return StartPositionItemEvent();
        else Debug.LogWarning("not found listener [ StartPositionItemEvent ] and value == Vector2.zero");
        return Vector2.zero;
    }
    /// <summary>
    /// убили обьект
    /// </summary>
    /// <param name="type"></param>
    public static void KillItem(TypeItem type)
    {
        if (KillItemItemEvent != null)
            KillItemItemEvent(type);
        else Debug.LogWarning("not found listener [ TextureForParticalEvent ]");
    }
    /// <summary>
    /// случайная текстура для обьекта
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Sprite TextureForPartical(TypeItem type)
    {
        if (TextureForParticalEvent != null)
            return TextureForParticalEvent(type);
        else Debug.LogWarning("not found listener [ TextureForParticalEvent ] and value == null");
        return null;
    }
    /// <summary>
    /// размер игрового поля 
    /// </summary>
    /// <returns></returns>
    public static Vector2 SizeGameBoard()
    {
        if (SizeGameBoardEvent != null)
            return SizeGameBoardEvent();
        else Debug.LogWarning("not found listener [ SizeGameBoardEvent ] and value == Vector2.zero");
        return Vector2.zero;
    }
    /// <summary>
    /// Время до появления нового обьекта
    /// </summary>
    /// <returns></returns>
    public static float TimerForCreateNewItem()
    {
        if (TimerForCreateNewItemEvent != null)
            return TimerForCreateNewItemEvent();
        else Debug.LogWarning("not found listener [ TimerForCreateNewItem ] and value == -1");
        return -1;
    }
    /// <summary>
    /// появление нового обьекта на поле
    /// </summary>
    public static void CreateNewItem()
    {
        if (CreateNewItemEvent != null) CreateNewItemEvent();
        else Debug.LogWarning("not found listener [ CreateNewItemEvent ] ");
    }
    /// <summary>
    /// сколько всего будет создано в начале игры обьектов
    /// </summary>
    /// <returns></returns>
    public static int MaxCountPoolItem()
    {
        if (MaxCountPoolItemEvent != null)
            return MaxCountPoolItemEvent();
        else Debug.LogWarning("not found listener [ MaxCountPoolItemEvent ] and value == -1");
        return -1;
    }
    /// <summary>
    /// игра остановилась
    /// </summary>
    public static void  StopGame()
    {
        if (StopGameEvent != null)
            StopGameEvent();
        else Debug.LogWarning("not found listener [ StopGameEvent ]");
    }
    /// <summary>
    /// игра началась
    /// </summary>
    public static void StartGame()
    {
        if (StartGameEvent != null)
            StartGameEvent();
        else Debug.LogWarning("not found listener [ StartGameEvent ]");
    }
    /// <summary>
    /// общее кол-во заработаных очков
    /// </summary>
    /// <returns></returns>
    public static int TotalScore()
    {
        var value = 0;
        if (TotalScoreEvent != null)
            value = TotalScoreEvent();
        else Debug.LogWarning("not found listener [ TotalScoreEvent ] and return value = -1");
        return value;
    }
    /// <summary>
    /// нажали на кнопку выхода из игры
    /// </summary>
    /// <param name="button"></param>
    public static void ClickTuButtonGameMenu(TypeButton button)
    {
        if (button == TypeButton.StartGame) StartGame();
        else Application.Quit();
    }
    static public void IsPush(bool isPush)
    {
        if (TotalScoreEvent != null) IsPushEvent(isPush);
        else Debug.LogWarning("not found listener [ IsPushEvent ]");
    }
}
