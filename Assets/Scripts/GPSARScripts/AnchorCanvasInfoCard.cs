using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class AnchorCanvasInfoCard : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI ModelName;

    [SerializeField]
    private TextMeshProUGUI ModelDescription;

    protected LocationAnchor pointOfInterest;


    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void InitializeInfoCard(LocationAnchor anchor, Camera arCamera)
    {
        this.pointOfInterest = anchor;
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
}
