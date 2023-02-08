using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    private float width;
    private float speed = -3f;

    private void Start()
    {
        width = 46f;
    }


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Reposition();
        } else
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
    }

    private void Reposition()
    {
        Vector2 vector = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + vector;
    }
}
