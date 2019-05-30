using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// хранилище всех созданых обьектов во время игры 
/// </summary>
public class PoolItem : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> poolItem;
    [SerializeField] int maxCountItem;
    private void OnEnable()
    {
        AllEventSystem.CreateNewItemEvent += CurentItem;
        maxCountItem = AllEventSystem.MaxCountPoolItem();
        CreateNewItem();
    }
    private void OnDisable()
    {
        CleareListItem();
    }
    void CleareListItem()
    {
        for (int i = 0; i < poolItem.Count; i++)
        {
            Destroy(poolItem[i]);
        }
        poolItem.Clear();
    }
    /// <summary>
    /// создаем и заполняем хранилище в начале игры 
    /// </summary>
    void CreateNewItem()
    {
        if (poolItem == null) poolItem = new List<GameObject>();
        for (int i = 0; i < maxCountItem; i++)
        {
            GameObject newItem = Instantiate(prefab, transform);
            newItem.SetActive(false);
            poolItem.Add(newItem);
        }
    }
    /// <summary>
    /// по требованию включаем игровой обьект
    /// </summary>
    void CurentItem()
    {
        for (int i = 0; i < poolItem.Count; i++)
        {
            if (!poolItem[i].activeInHierarchy)
            {
                poolItem[i].SetActive(true);
                return;
            }
        }
    }
}
