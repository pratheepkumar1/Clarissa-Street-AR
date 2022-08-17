using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Orientation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform == true)
        {
            if (SceneManager.GetActiveScene().name == "Home Screen")
            {
                Screen.orientation = ScreenOrientation.Portrait;
            }
            else
            {
                Screen.orientation = ScreenOrientation.AutoRotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
