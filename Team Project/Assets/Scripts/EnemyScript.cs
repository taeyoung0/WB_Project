using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject walls;
    private AudioSource audioSource;
    // Start is called before the first frame update
    [SerializeField]
    private Transform createPos;

    [SerializeField]
    private float createInterval = 0.01f;
    private float lastCreateTime = 0f;
    private Animator animator;
    private bool is_turn = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_turn)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                
                CreateWall();

            }
        }
    }

    void CreateWall()
    {
        if (Time.time - lastCreateTime > createInterval)
        {
            Instantiate(walls, createPos.position, quaternion.identity);
            lastCreateTime = Time.time;
            animator.SetTrigger("isAttack");
            //audioSource.Play();
        }

    }

    public void setTurn(bool b){
        is_turn = b;
    }
}
