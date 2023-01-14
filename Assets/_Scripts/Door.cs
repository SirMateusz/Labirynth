using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform closePosition, openPosition, door;

    public bool open = false;

    [SerializeField, Range(0f, 100f)]
    private float speed = 10f;

    void Start() => door.position = closePosition.position;

    private void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * speed);
        }

        if (!open && Vector3.Distance(door.position, closePosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, closePosition.position, Time.deltaTime * speed);
        }
    }

    public void OpenClose() { open = true; Debug.LogError("HERE"); }
}
