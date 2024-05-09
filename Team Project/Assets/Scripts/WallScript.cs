using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private bool IsDestroy = false;
    [SerializeField]
    private float fDestroyTime = 0.05f;
    private float fLastTime;
    [SerializeField]
    private float movespeed = 3f;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        if (transform.position.x < -18.3 || (IsDestroy && (Time.time - fLastTime > fDestroyTime)))
        {
            Destroy(gameObject);
        }


    }

    public void DestroyWall()
    {

        animator.SetTrigger("IsDestroy");
        IsDestroy = true;
        fLastTime = Time.time;

    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {

    //     if (other.gameObject.tag == "Player")
    //     {
    //         Debug.Log(other.gameObject.tag);

    //     }
    // }
}


