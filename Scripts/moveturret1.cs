using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveturret1 : MonoBehaviour
{
    int right;
    Vector3 mousePos;
    Vector3 turretPos;
    int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        turretPos = transform.position;
        if(mousePos.x - turretPos.x > 0){
            right = 1;
        }
        else{
            right = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(state%4==1){
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            turretPos = transform.position;

            //Debug.Log(mousePos);
            float rot = Mathf.Atan((mousePos.y - turretPos.y) / (mousePos.x - turretPos.x))*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,0f,rot);
            if(mousePos.x - turretPos.x > 0 && right == 0){
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                right = 1;
            }
            if(mousePos.x - turretPos.x < 0 && right == 1){
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                right = 0;
            }
        }

        if (Input.GetKeyDown("space")){
            state+=1;
        }
    }
}
