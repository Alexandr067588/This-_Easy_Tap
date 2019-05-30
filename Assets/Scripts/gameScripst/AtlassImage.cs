using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Все атласы на текстуры обьектов
/// </summary>
[CreateAssetMenu(fileName = "Atlass Image",menuName = "Atlass Image")]
public class AtlassImage : ScriptableObject
{
    [SerializeField] List<Sprite> fruits;
    [SerializeField] List<Sprite> bombs;
    private void OnEnable()
    {
        AllEventSystem.TextureForParticalEvent += returnSprite;
    }
    Sprite returnSprite(TypeItem type)
    {
        
        if(type == TypeItem.Fruit)
        {
            return fruits[Random.Range(0, fruits.Count)];
        }
        else return bombs[Random.Range(0, bombs.Count)];
    }

}
