using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool iCanOpen = false;
    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    public Animator key;

    public Material[] materials;

    public Renderer keyRenderer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") iCanOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") { iCanOpen = false; GameManager.gameManager.SetUseText(""); }
    }

    private void Start()
    {
        if (myColor == KeyColor.Red) { keyRenderer.material = materials[0]; this.gameObject.GetComponent<Renderer>().material = materials[0]; }
        else if (myColor == KeyColor.Green) { keyRenderer.material = materials[1]; this.gameObject.GetComponent<Renderer>().material = materials[1]; }
        else if (myColor == KeyColor.Gold) { keyRenderer.material = materials[2]; this.gameObject.GetComponent<Renderer>().material = materials[2]; }
    }

    public void UseKey()
    {
        foreach( Door door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.gameManager.redKey > 0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKey--;
            locked = true;
            return true;
        }
        else if (GameManager.gameManager.goldKey > 0 && myColor == KeyColor.Gold)
        {
            GameManager.gameManager.goldKey--;
            locked = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza");
            return false;
        }
    }

    private void Update()
    {
        if (iCanOpen && !locked)
        {
            GameManager.gameManager.SetUseText("PRESS E TO OPEN LOCK");
        }
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen && !locked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }
}
