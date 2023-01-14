using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void PickedUp()
    {
        AudioController.audioController.Play("pickup");
        Destroy(this.gameObject);
    }

    public void Rotation(float _speed)
    {
        transform.Rotate(new Vector3(0f, 5f, 0f) * Time.deltaTime * _speed);
    }
}
