using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserScript : MonoBehaviour
{

    private Animator animator;
    public Transform pos;
    public Vector2 boxSize;
    
    private bool is_turn;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_turn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                animator.SetTrigger("isAttack");
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    if (collider.tag == "Wall")
                    {
                        collider.GetComponent<WallScript>().DestroyWall();
                        //audioSource.Play();
                    }
                }
            }
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }

    public void setTurn(bool b)
    {
        is_turn = b;
    }
}



