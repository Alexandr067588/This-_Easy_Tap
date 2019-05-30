using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// абстрактный класс всех компонентов
/// </summary>
public class MoveComponent : MonoBehaviour
{
    /// <summary>
    /// Awake
    /// </summary>
    virtual public void CreateItem()
    {

    }
    /// <summary>
    /// OnDisable
    /// </summary>
    virtual public void OffModeItem()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// OnEnable
    /// </summary>
    virtual public void OnModeItem()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Update
    /// </summary>
   virtual public void UpdateItem()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// PaticalComponent_Item и PositionItemComponent
    /// для создания правильной картинки и зачисления нужного кол-ва очков
    /// </summary>
    /// <param name="typeItem">Фрукт или Заряд</param>
    virtual public void SetTypeItem(TypeItem typeItem)
    {
        
    }


}
