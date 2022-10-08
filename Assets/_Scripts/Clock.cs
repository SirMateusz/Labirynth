using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    [SerializeField] bool addTime;
    [SerializeField] int time = 5;

    [Range(0, 100)]
    [SerializeField] float speed = 20f;

    public override void PickedUp()
    {

        if (addTime) GameManager.gameManager.AddTime(time);
        else GameManager.gameManager.AddTime(-time);

        base.PickedUp();
    }

    void Update()
    {
        Rotation(speed);
    }
}
