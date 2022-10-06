using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public void PickedUp()
    {
        Debug.Log("Picked Up");
        Destroy(this.gameObject);
    }
}
