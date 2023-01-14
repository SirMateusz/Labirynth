using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAnim : MonoBehaviour
{
    [SerializeField]
    private Lock _lock;

    public void UseKey()
    {
        _lock.UseKey();
    }
}
