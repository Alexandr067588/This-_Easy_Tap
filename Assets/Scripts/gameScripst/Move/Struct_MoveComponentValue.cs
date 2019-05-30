using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
/// <summary>
/// структура даных скорости и гравитации обьекта
/// событе для заполнения полей класса [ CurentValueEvent ]
/// приватный конструктор класса [ StructValueForMoveComponent ]
/// статический метод [ NewValueForComponentMove ]
/// гетер скорости [ getSpeedValue__ ]
/// гетер гравитации [ getGravityValue__ ]
/// перечесление типов данных [ TypeToMoveValue ]
/// </summary>
public struct Struct_MoveComponentValue
{
    /// <summary>
    /// значение гравитации
    /// </summary>
    [SerializeField] float gravityValue;
    /// <summary>
    /// значение скорости
    /// </summary>
    [SerializeField] float speedValue;
    /// <summary>
    /// возвращаем значение гравитации
    /// </summary>
    public float getGravityValue__
    {
        get { return gravityValue; }
    }
    /// <summary>
    /// возвращаем значение скорости
    /// </summary>
    public float getSpeedValue__
    {
        get { return speedValue; }
    }
    TypeValueMoveComponent newValue__
    {
        set
        {
            if (value == TypeValueMoveComponent.Gravity) gravityValue = AllEventSystem.ValueForMoveComponent(TypeValueMoveComponent.Gravity);
            else if (value == TypeValueMoveComponent.Speed) speedValue = AllEventSystem.ValueForMoveComponent(TypeValueMoveComponent.Speed);
        }
    }
    public void RefreshAllValue()
    {
        newValue__ = TypeValueMoveComponent.Gravity;
        newValue__ = TypeValueMoveComponent.Speed;
    }
    /// <summary>
    /// закрытый конструктор 
    /// </summary>
    /// <param name="gravityValue__">новое значени гравитации</param>
    /// <param name="speedValue__">новое значени скорости</param>
    Struct_MoveComponentValue(float gravityValue__, float speedValue__)
    {
        gravityValue = gravityValue__;
        speedValue = speedValue__;
    }
    /// <summary>
    /// статический метод для создание структуры по закрытому конструктору 
    /// </summary>
    /// <param name="structValue"> ссылка на структуру</param>
    public static void New_Struct_MoveComponentValue(ref Struct_MoveComponentValue struct_MoveComponentValue)
    {
       var gravityValue__ = AllEventSystem.ValueForMoveComponent(TypeValueMoveComponent.Gravity);
       var speedValue__ = AllEventSystem.ValueForMoveComponent(TypeValueMoveComponent.Speed);
       struct_MoveComponentValue = new Struct_MoveComponentValue(gravityValue__, speedValue__);
    }
}
/// <summary>
/// перечисление всех типов значений полей структуры
/// </summary>
public enum TypeValueMoveComponent
{
    Gravity,/// гравитация
    Speed   /// скорость
}

