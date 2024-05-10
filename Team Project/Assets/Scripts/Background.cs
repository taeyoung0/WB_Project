using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 3f;
    Renderer renderer;
    Vector3 size;
    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        size = renderer.bounds.size; // 렌더러의 바운딩 박스 크기를 가져옴
        //Debug.Log("오브젝트의 크기: " + size);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        if (transform.position.x < -18)
        {
            transform.position += new Vector3(size.x * 3, 0, 0);
        }
    }
}
