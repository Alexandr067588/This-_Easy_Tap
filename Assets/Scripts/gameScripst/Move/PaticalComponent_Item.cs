using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// рисуем сам обьект по типу
/// </summary>
public class PaticalComponent_Item : MoveComponent
{
    [SerializeField] ParticleSystem imageItem;
    [SerializeField] TypeItem typeItem;
    public override void CreateItem()
    {
        imageItem = GetComponentInChildren<ParticleSystem>();
    }
    public override void SetTypeItem(TypeItem typeItem)
    {
        this.typeItem = typeItem;
    }
    public override void OffModeItem()
    {
        if (imageItem !=null)
        {
            imageItem.Clear();
            imageItem.Stop();
        }
    }

    /// <summary>
    /// рандомная текстура по типу из атласа
    /// </summary>
    /// <returns></returns>
    Sprite CurentTexture()
    {
        imageItem.textureSheetAnimation.SetSprite(0,AllEventSystem.TextureForPartical(typeItem));
        return AllEventSystem.TextureForPartical(typeItem);
    }
    public override void OnModeItem()
    {
        if (imageItem != null)
        {
            imageItem.textureSheetAnimation.SetSprite(0, AllEventSystem.TextureForPartical(typeItem));
            imageItem.Play();
        }
    }

    public override void UpdateItem()
    {
        base.UpdateItem();
    }
}
