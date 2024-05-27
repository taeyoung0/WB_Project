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
    private bool is_First = true;
    [SerializeField]
    private bool is_User = false;
    private float firstTime, turnTime;
    public CameraState ecameraState;
    public CameraController cameraController;
    public SoundMgr soundMgr;
    public UserScript userScript;
    public EnemyScript enemyScript;
    [SerializeField]
    public float turnRate = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        userScript = FindObjectOfType<UserScript>();
        enemyScript = FindObjectOfType<EnemyScript>();
        soundMgr = FindObjectOfType<SoundMgr>();
        firstTime = Time.time;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
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
            if (Time.time - turnTime > turnRate)
            {
                is_User = !is_User;
                turnTime = Time.time;

            }
            cameraController.SetViewState(is_User ? (int)CameraState.User : (int)CameraState.Enemy);
        }
        if (!is_First)
        {
            if ( is_User)
            {
                userScript.setTurn(is_User);
                enemyScript.setTurn(!is_User);
            }
            else
            {
                userScript.setTurn(is_User);
                enemyScript.setTurn(!is_User);
            }
        }



    }
}
