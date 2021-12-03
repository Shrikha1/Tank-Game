using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class worldgen : MonoBehaviour
{
    public Sprite sprite;
    public Sprite t1sprite;
    public Sprite t2sprite;

    // Start is called before the first frame update
    void Start()
    {
        // Important vars
        float sf = 60f/514f;
        float xc = -100f*sf;
        float yc = 50f*sf;

        // Number of edges
        int n = 10;

        // Radii of Ellipse
        float a = 360f*sf;
        float b = 180f*sf;
        
        float[] angles = new float[n];
        Vector3[] pts = new Vector3[n];
        
        for(int i=0;i<n;i++){
            float angle = Random.value*2*Mathf.PI;
            angles[i] = angle;
        }

        Array.Sort(angles);

        for(int i=0;i<n;i++){
            // Debug.Log(angles[i]);
            pts[i] = new Vector3(xc+a*Mathf.Cos(angles[i]),yc+b*Mathf.Sin(angles[i]),0);
        }

        GameObject[] go = new GameObject[n];
        float xcd = 0f, ycd = 0f;

        for(int i=0;i<n;i++){
            xcd = xcd + pts[i].x;
            ycd = ycd + pts[i].y;
            
            go[i] = new GameObject();
            go[i].name = "go"+i;
            SpriteRenderer renderer = go[i].AddComponent<SpriteRenderer>();
            // Rigidbody2D rb = go[i].AddComponent<Rigidbody2D>();
            // rb.AddForce(go[i].transform.up * 10f);
            renderer.sprite = sprite;
            float posX = (pts[i].x + pts[(i+1)%n].x) /2;
            float posY = (pts[i].y + pts[(i+1)%n].y) /2;
            float rot = Mathf.Atan((pts[(i+1)%n].y - pts[i].y) / (pts[(i+1)%n].x - pts[i].x))*Mathf.Rad2Deg;
            float scale = Mathf.Sqrt((pts[(i+1)%n].y - pts[i].y)*(pts[(i+1)%n].y - pts[i].y) + (pts[(i+1)%n].x - pts[i].x)*(pts[(i+1)%n].x - pts[i].x));
            // Debug.Log(pts[i]);
            go[i].transform.position = new Vector3(posX, posY, 0f);
            go[i].transform.rotation = Quaternion.Euler(0f,0f,rot);
            go[i].transform.localScale = new Vector3(3*scale/20,1,0);
            go[i].AddComponent<BoxCollider2D>();
            
            worldedge w = go[i].AddComponent<worldedge>();
            w.edge1 = pts[i];
            w.edge2 = pts[(i+1)%n];
            
        }

        xcd = xcd/n;
        ycd = ycd/n;
        
        float th = 0.8f;

        GameObject t1 = GameObject.Find("t1");
        // t1.name = "t1";
        
        // SpriteRenderer t1renderer = t1.AddComponent<SpriteRenderer>();
        // t1renderer.sprite = t1sprite;

        float t1gen = Random.value;
        float xt1 = pts[0].x + t1gen*(pts[1].x - pts[0].x);
        float yt1 = pts[0].y + t1gen*(pts[1].y - pts[0].y);
        
        Vector3 v = pts[1]-pts[0];
        v = v/(v.magnitude*1.0f);
        t1.transform.position = new Vector3(xt1 - th*v.y, yt1 + th*v.x, 0f);
        
        t1.transform.rotation = go[0].transform.rotation;
        if(pts[1].x < pts[0].x){
            Vector3 rot = t1.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z+180);
            t1.transform.rotation = Quaternion.Euler(rot);            
        }

        // t1.AddComponent<BoxCollider2D>();
        
        GameObject t2 = GameObject.Find("t2");
        // t2.name = "t2";
        
        // SpriteRenderer t2renderer = t2.AddComponent<SpriteRenderer>();
        // t2renderer.sprite = t2sprite;

        float t2gen = Random.value;
        float xt2 = pts[5].x + t1gen*(pts[6].x - pts[5].x);
        float yt2 = pts[5].y + t1gen*(pts[6].y - pts[5].y);
        v = pts[6]-pts[5];
        v = v/(v.magnitude*1.0f);
        t2.transform.position = new Vector3(xt2 - th*v.y, yt2 + th*v.x, 0f);

        t2.transform.rotation = go[5].transform.rotation;
        if(pts[6].x < pts[5].x){
            Vector3 rot = t2.transform.rotation.eulerAngles;
            rot = new Vector3(rot.x,rot.y,rot.z+180);
            t2.transform.rotation = Quaternion.Euler(rot);            
        }

        GameObject turret1 = GameObject.Find("turret1");
        turret1.transform.position = t1.transform.position;

        GameObject turret2 = GameObject.Find("turret2");
        turret2.transform.position = t2.transform.position;
        
        
        // t2.AddComponent<BoxCollider2D>();
        // Marker
        // GameObject center = new GameObject();
        // center.name = "center";
        // SpriteRenderer crenderer = center.AddComponent<SpriteRenderer>();
        // crenderer.sprite = csprite;
        // center.transform.position = new Vector3(xcd, ycd, 0f);
        

        // go.AddComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
