using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// позиция обьекта на столе
/// </summary>
[System.Serializable]
public class PositionItemComponent : MoveComponent
{
    [SerializeField] Transform positionItem;
    [SerializeField] bool isPush;
    /// <summary>
    /// размеры игрового поля
    /// </summary>
    [SerializeField] Vector2 size;
    /// <summary>
    /// тип обьекта
    /// </summary>
    [SerializeField] TypeItem typeItem;
   override public void OffModeItem()
    {
        StartPosition();
    }
    override public void OnModeItem()
    {

        positionItem.localPosition = new Vector3(Random.Range(-size.x/2, size.x / 2), -size.y/2, -1);
        gameObject.SetActive(true);
        
    }
    /// <summary>
    /// возвращаем в место спауна 
    /// </summary>
    void StartPosition()
    {
        positionItem.localPosition = AllEventSystem.StartPositionItem();
        gameObject.SetActive(false);
    }
 void IsClick(bool isPush__)
    {
        isPush = isPush__;
    }
    private void OnMouseEnter()
    {
        if (isPush)
        {
            AllEventSystem.KillItem(typeItem);
            StartPosition();
        }
    }
    /// <summary>
    /// перемещаем в рандомную самую нижнюю точку на столе
    /// </summary>
    override public void CreateItem()
    {
        positionItem = GetComponent<Transform>();
        size = AllEventSystem.SizeGameBoard();
        AllEventSystem.IsPushEvent += IsClick;
        StartPosition();
    }

    override public void UpdateItem()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// получаем тип обьекта
    /// </summary>
    /// <param name="typeItem"></param>
    public override void SetTypeItem(TypeItem typeItem)
    {
        this.typeItem = typeItem;
    }
}
/// <summary>
/// тип обьекта
/// </summary>
public enum TypeItem
{
    Fruit,
    Bomb,
}
