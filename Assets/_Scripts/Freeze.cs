using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    [SerializeField] int freezeTime = 10;

    [Range(0, 100)]
    [SerializeField] float speed = 40f;

    public override void PickedUp()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        Debug.Log("Time frozen");
        base.PickedUp();
    }
    void Update()
    {
        Rotation(speed);
    }
}
