using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private Dictionary<int, Stack<GameObject>> prefabPools;

    private void Awake()
    {
        prefabPools = new Dictionary<int, Stack<GameObject>>();
    }

    public GameObject Spawn(GameObject prefab)
    {
        var poolObj = prefab.GetComponent<PoolObject>();

        if (!poolObj)
            return null;

        Stack<GameObject> pool = null;
        prefabPools.TryGetValue(poolObj.PrefabKey, out pool);

        if (pool == null)
        {
            pool = new Stack<GameObject>();
            prefabPools[poolObj.PrefabKey] = pool;
        }

        if (pool.Count == 0)
        {
            return Instantiate(prefab);
        }

        var resued = pool.Pop();

        resued.SetActive(true);
        return resued;
    }

    public void Unspawn(GameObject gameObjectCopy)
    {
        var poolObj = gameObjectCopy.GetComponent<PoolObject>();

        if (!poolObj)
            return;

        Stack<GameObject> pool = null;
        prefabPools.TryGetValue(poolObj.PrefabKey, out pool);

        if (pool == null)
        {
            pool = new Stack<GameObject>();
            prefabPools[poolObj.PrefabKey] = pool;
        }

        gameObjectCopy.SetActive(false);
        pool.Push(gameObjectCopy);
    }
}
