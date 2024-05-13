using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 3f;
    // Start is called before the first frame update
    private Renderer renderer;
    private Vector3 size;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        size = renderer.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        if (transform.position.x < -19.2)
        {
            transform.position += new Vector3(size.x * 3, 0, 0);
        }
    }
}
