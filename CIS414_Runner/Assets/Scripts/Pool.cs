using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}

public class Pool : MonoBehaviour
{

    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;
    GameObject anObject;

    private void Awake()
    {
        singleton = this;
        pooledItems = new List<GameObject>();

        foreach (PoolItem item in items)
        {
            for (int i=0; i < item.amount; i++)
            {
                GameObject anObject = Instantiate(item.prefab);
                anObject.SetActive(false);
                pooledItems.Add(anObject);
            }
        }
    }

    public GameObject GetObject()
    {
        //Janky DOn't DO
        string aTag = "Straight";

        if(Random.Range(0,2) == 0)
        {
            aTag = "Thin";
        }
        //

        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].transform.tag == aTag)
            {
                anObject = pooledItems[i];
            }
        }

        if (anObject == null)
        {
            anObject = Instantiate(pooledItems[0]);
        }

        return anObject;
    }

}
