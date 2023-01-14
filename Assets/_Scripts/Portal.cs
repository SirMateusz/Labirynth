using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Camera myCamera;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform myRenderPlane, myColliderPlane;

    [SerializeField]
    private Portal otherPortal;

    [SerializeField]
    private PortalCamera portalCamera;

    [SerializeField]
    private PortalTeleport portalTeleport;

    [SerializeField]
    private Material material;

    float myAngle;

    private void Awake()
    {
        portalCamera.otherPortal = otherPortal.transform;
        portalCamera.playerCamera = player.gameObject.transform.GetChild(0);
        portalCamera.portal = this.transform;


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
        CheckAngle();
    }

    void CheckAngle()
    {
        if (Mathf.Abs(otherPortal.ReturnMyAngle() - ReturnMyAngle()) != 180)
        {
            Debug.LogWarning("Portale nie s¹ odpowiednio ustawione: " + gameObject.name);
            Debug.LogWarning("Angle: " + (otherPortal.ReturnMyAngle() - ReturnMyAngle()));
        }
    }

    public float ReturnMyAngle() { return myAngle; }
}
