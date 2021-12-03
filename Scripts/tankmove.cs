using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankmove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        float mag = 1f;
        
        if(Input.GetKeyDown("up")){
            pos.y += mag;
        }
        else if(Input.GetKeyDown("down")){
            pos.y -= mag;
        }
        else if(Input.GetKeyDown("right")){
            pos.x += mag;
        }
        else if(Input.GetKeyDown("left")){
            pos.x -= mag;
        }

        transform.position = pos;
    }
}
