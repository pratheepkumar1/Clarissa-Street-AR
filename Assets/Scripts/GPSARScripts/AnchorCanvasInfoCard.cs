using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class AnchorCanvasInfoCard : AnchorCanvasInterface
{

    [SerializeField]
    private GameObject InfoCard;

    [SerializeField]
    private TextMeshProUGUI ModelName;

    [SerializeField]
    private TextMeshProUGUI ModelDescription;

    private Camera arCamera;

    private Transform cameraTransform;

    public bool isMoveAroundEnabled;

    void Start()
    {
        //renderer = GetComponent<MeshRenderer>();
        //renderer.enabled = false;
        isMoveAroundEnabled = false;
        //Debug.Log(isMoveAroundEnabled);

    }


    public override void Setup(LocationAnchor anchor, Camera arCamera)
    {
        this.pointOfInterest = anchor;
        this.arCamera = arCamera;
        this.cameraTransform = arCamera.transform;
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        if (pointOfInterest != null)
        {
            if (ModelName != null)
            {
                ModelName.text = pointOfInterest.PoiName;
            }

            if (ModelDescription != null)
            {
                ModelDescription.text = pointOfInterest.Description;
            }

        }
    }


    public override bool CheckVisibility()
    {
        Debug.Log("57");
        RaycastHit cameraHit;
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out cameraHit, Mathf.Infinity))
        {
            //Debug.Log("61");
            //Debug.Log(cameraHit.transform.parent.tag);
            //Debug.Log(cameraHit.distance);

            if (cameraHit.transform.parent.tag == "Model" && cameraHit.distance < 15.0f)
            {
                //Debug.Log("64");
                return true;
            }
            //Debug.Log("67");
            return false;
        }
        return false;
    }


    public void Dismiss()
    {
        InfoCard.SetActive(false);
    }


    public void EnableMoveAround()
    {
        isMoveAroundEnabled = true;
        Debug.Log(isMoveAroundEnabled);
    }

    public override bool CheckMoveAroundEnabled()
    {
        Debug.Log("Move Around Enabled");
        return isMoveAroundEnabled;
    }

    public override void UpdateDistance(float distance)
    {

    }

    public override void UpdatePosition(Vector3 worldPosition, float groundLevel, float devicePosY)
    {
    }

    public override void UpdatePositionXZ(Vector3 newPos)
    {
    }

    public override void UpdatePositionY(float groundLevelY, float devicePosY)
    {
    
    }


}


