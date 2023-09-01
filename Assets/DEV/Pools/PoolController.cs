using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : Controller
{
    #region Fields
    [SerializeField] private List<ObjectPool> pools;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            pools[i].Initialize(data);
        }
    }
    #endregion
}
