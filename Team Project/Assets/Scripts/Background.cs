using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Background : MonoBehaviour
{
    [SerializeField] 
    private float movespeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        if(transform.position.x < -18.3){
            transform.position += new Vector3(37.4f, 0,0);
        }
    }
}
