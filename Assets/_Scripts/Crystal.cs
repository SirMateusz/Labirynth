using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    [SerializeField] int points = 5;
    
    [Range(0, 100)]
    [SerializeField] float speed = 50;
    public override void PickedUp()
    {
        GameManager.gameManager.AddPoints(points);
        base.PickedUp();
    }

    void Update()
    {
        Rotation(speed);
    }
}
