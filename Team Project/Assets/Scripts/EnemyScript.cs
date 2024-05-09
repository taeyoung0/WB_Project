using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject walls;
    // Start is called before the first frame update
    [SerializeField]
    private Transform createPos;
    
    [SerializeField]
    private float createInterval = 0.01f;
    private float lastCreateTime = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            CreateWall();
        }
        
    }

    void CreateWall(){
        if(Time.time - lastCreateTime > createInterval)
        {
            Instantiate(walls,createPos.position, quaternion.identity);
            lastCreateTime = Time.time;
        }
        
    }
}
