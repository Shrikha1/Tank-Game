using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitycontrol : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    Vector2 f_dir;
    // public float m_Thrust = 20f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.gravityScale = 0f;
        f_dir = new Vector2(0f, 0f);
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(f_dir, ForceMode2D.Force);
        
        // if (Input.GetButton("Jump"))
        // {
        //     //Apply a force to this Rigidbody in direction of this GameObjects up axis
        //     m_Rigidbody.AddForce(transform.up * m_Thrust);
        // }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        float angle = (Mathf.Deg2Rad*col.gameObject.transform.localEulerAngles.z);
        // if(angle>Mathf.PI){
        //     angle = 2*Mathf.PI - angle;
        // }
        // f_dir = new Vector2(9.8f*Mathf.Sin(angle),-1f*9.8f*Mathf.Cos(angle));
        worldedge w = col.gameObject.GetComponent<worldedge>();
        Vector3 v = w.edge2-w.edge1;
        v = v/(v.magnitude*1.0f);
        Vector2 vp = new Vector2(9.8f*v.y, -9.8f*v.x);
        f_dir = vp;
        // Debug.Log(vp);
        
        // Debug.Log(9.8f*Mathf.Sin(angle));
        // Debug.Log(-1f*9.8f*Mathf.Cos(angle));

    }
}