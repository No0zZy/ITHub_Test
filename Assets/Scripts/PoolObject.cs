using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PoolObject : MonoBehaviour
{
    [SerializeField] private int prefabKey;
    public int PrefabKey => prefabKey;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (prefabKey == 0)
        {
            string path = AssetDatabase.GetAssetPath(gameObject);
            prefabKey = path.GetHashCode();
        }
    }
#endif
}
