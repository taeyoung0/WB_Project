using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraState
{
    All,
    User,
    Enemy
}

public class SceneMgr : MonoBehaviour
{
    private bool is_First = true, is_User = false;
    private float firstTime, turnTime;
    public CameraState ecameraState;
    CameraController cameraController;
    [SerializeField]
    public float turnRate = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        firstTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_First)
        {
            cameraController.SetViewState((int)CameraState.All);
            if (Time.time - firstTime > 3.0f)
            {
                is_First = false;
                turnTime = Time.time;
            }

        }
        else
        {
            if (turnTime - Time.time > turnRate)
            {
                is_User = !is_User;
                turnTime = Time.time;
            }
            cameraController.SetViewState(is_User ? (int)CameraState.User : (int)CameraState.Enemy);
        }



    }
}
