using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIChange : MonoBehaviour, IClick
{
    private SpriteRenderer rend;
    private Camera maincamera;
    public GameObject OurGUI;

    private bool CameraCheck = true;

    public void OnClickAction()
    {
        rend = GetComponent<SpriteRenderer>();
        maincamera = Camera.main;
        rend.color = Color.white;
        float cameraZoom = 5f;

        if (CameraCheck == true)
        {
            for (int i = 0; i < 40; i++)
            {
                cameraZoom = cameraZoom - 0.1f;
                maincamera.orthographicSize = cameraZoom;
                OurGUI.SetActive(true);
            }
            CameraCheck = false;
        } else if (CameraCheck == false)
        {

            cameraZoom = 1f;
            for (int i = 0; i < 40; i++)
            {
                cameraZoom = cameraZoom + 0.1f;
                maincamera.orthographicSize = cameraZoom;
                OurGUI.SetActive(false);
            }
            CameraCheck = true;
        }
    } 



}
