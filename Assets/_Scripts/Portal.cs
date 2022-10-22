using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] GameObject player;
    [SerializeField] Transform myRenderPlane, myColliderPlane;

    [SerializeField] Portal otherPortal;
    [SerializeField] PortalCamera portalCamera;
    [SerializeField] PortalTeleport portalTeleport;

    [SerializeField] Material material;

    float myAngle;

    private void Awake() 
    {
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.transform; 

        myRenderPlane.gameObject.GetComponent<Renderer>().material = Instantiate(material);

        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }     

        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        myAngle = transform.localEulerAngles.y % 360;
        portalCamera.SetMyAngle(myAngle);
    }
    
    private void Start() 
    {
        myRenderPlane.gameObject.GetComponent<Renderer>().material.mainTexture = otherPortal.myCamera.targetTexture;
    }

    void CheckAngle()
    {
        if (Mathf.Abs(otherPortal.ReturnMyAngle() - ReturnMyAngle()) != 180)
        {
            Debug.LogWarning($"Portals aren't set apppropriately: {gameObject.name}");
            Debug.LogWarning($"Angle: {otherPortal.ReturnMyAngle() - ReturnMyAngle()}");
        }
    }

    public float ReturnMyAngle() { return myAngle; }
}
