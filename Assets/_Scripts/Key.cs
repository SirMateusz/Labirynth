using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Pickup
{
    [SerializeField] KeyColor color;
    [SerializeField] float speed = 20f;

    [SerializeField] private List<Material> materials = new List<Material>();

    private void Start()
    {
        if (color == KeyColor.Red) GetComponent<Renderer>().material = materials[0];
        else if (color == KeyColor.Green) GetComponent<Renderer>().material = materials[1];
        else if (color == KeyColor.Gold) GetComponent<Renderer>().material = materials[2];
    }

    public override void PickedUp()
    {
        GameManager.gameManager.AddKey(color);
        base.PickedUp();
    }

    void Update()
    {
        Rotation(speed);
    }
}

public enum KeyColor
{
    Red,
    Green,
    Gold
}
