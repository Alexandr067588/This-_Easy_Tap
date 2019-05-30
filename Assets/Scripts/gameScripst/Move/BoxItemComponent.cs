using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// хранилище все компонентов айтема
/// 
/// </summary>
public class BoxItemComponent : MonoBehaviour
{
    /// <summary>
    /// передвижение 
    /// </summary>
    [SerializeField] MoveComponent moveComponent;
    /// <summary>
    /// позиция
    /// </summary>
    [SerializeField] MoveComponent positionComponent;
    /// <summary>
    /// иконка
    /// </summary>
    [SerializeField] MoveComponent particalComponent;
    /// <summary>
    /// на айтем вешаем соответствующие классы
    /// </summary>
    private void Awake()
    {
        gameObject.AddComponent<PositionItemComponent>();
        positionComponent = GetComponent<PositionItemComponent>();

        gameObject.AddComponent<MoveComponent_Item>();
        moveComponent = GetComponent<MoveComponent_Item>();

        gameObject.AddComponent<PaticalComponent_Item>();
        particalComponent= GetComponent<PaticalComponent_Item>();

        moveComponent.CreateItem();
        positionComponent.CreateItem();
        particalComponent.CreateItem();
        particalComponent.OnModeItem();
    }
    private void OnEnable()
    {
        positionComponent.OnModeItem();
        particalComponent.OnModeItem();
        moveComponent.OnModeItem();
    }
    private void OnDisable()
    {
        moveComponent.OffModeItem();
        positionComponent.OffModeItem();
        particalComponent.OffModeItem();
        var index = Random.Range(0, 100);
        TypeItem typeItem;
        if (index < 70) typeItem = TypeItem.Fruit;
        else typeItem = TypeItem.Bomb;
        positionComponent.SetTypeItem(typeItem);
        particalComponent.SetTypeItem(typeItem);

      
    }
    private void FixedUpdate()
    {
        moveComponent.UpdateItem();
    }

}
