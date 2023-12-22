using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform cameraT;
    public Transform MainPlayer;
    public float CameraSmooth = 5.0f;
    void Start()
    {
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(MainPlayer.position.x, MainPlayer.position.y, cameraT.position.z);
        cameraT.position = targetPos; //Vector3.Lerp(cameraT.position,targetPos,CameraSmooth);
    }
}
