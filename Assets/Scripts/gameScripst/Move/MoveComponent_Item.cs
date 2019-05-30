using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class MoveComponent_Item : MoveComponent
{
    [SerializeField] protected Rigidbody2D rb;
    /// <summary>
    /// структура значений скорости и притяжения
    /// </summary>
    [SerializeField] Struct_MoveComponentValue struct_MoveComponentValue;
    [SerializeField] bool isLeft;
    public override void CreateItem()
    {
        rb = GetComponent<Rigidbody2D>();
        Struct_MoveComponentValue.New_Struct_MoveComponentValue(ref struct_MoveComponentValue);
        CurentGravity();
    }
    public override void OnModeItem()
    {
        isLeft = transform.position.x > 0;
    }
    public override void OffModeItem()
    {
        struct_MoveComponentValue.RefreshAllValue();
        CurentGravity();
    }
    public override void UpdateItem()
    {
        MoveItem(isLeft);
    }
    /// <summary>
    /// коректируем гравитация в соответствии с структурой
    /// </summary>
    void CurentGravity()
    {
        rb.gravityScale = struct_MoveComponentValue.getGravityValue__;
    }
    /// <summary>
    /// движение обьекта
    /// если влево то влево и наоборот
    /// </summary>
    /// <param name="isLeft"></param>
    void MoveItem(bool isLeft)
    {
        if(isLeft)
        {
            rb.AddForce(Vector2.left * struct_MoveComponentValue.getSpeedValue__ * Time.fixedDeltaTime);
        }
        else
        {
            rb.AddForce(Vector2.right * struct_MoveComponentValue.getSpeedValue__ * Time.fixedDeltaTime);
        }
    }
    /// <summary>
    /// если надо то меняем гравитацию на обратную
    /// </summary>
    public void ChangeGravity()
    {
        rb.gravityScale = -rb.gravityScale;
    }
}