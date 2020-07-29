using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isclick = false ;
    
    public float maxDis = 3;
    [HideInInspector]
    public SpringJoint2D sp;
    public Rigidbody2D rg;

    public  LineRenderer right;
    public Transform rightPos;
    public  LineRenderer left;
    public Transform leftPos;

    public GameObject boom;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        isclick = true;
        rg.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isclick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);

        //禁用划线组件
        right.enabled = false;
        left.enabled = false;
    }

    private void Update()
    {
        if (isclick) { //鼠标一直按下，进行位置的跟随
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position += new Vector3(0, 0, 10);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis) //进行位置限定
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;//单位华向量
                pos *= maxDis;//最大长度的向量
                transform.position = pos + rightPos.position;
            }

            Line();
        }
    }

    void Fly() 
    {
        sp.enabled = false;
        Invoke("Next",5);
    }

    //划线
    void Line()
    {
        right.enabled = true;
        left.enabled = true;

        right.SetPosition(0, rightPos.position);
        right.SetPosition(1,transform.position);

        left.SetPosition(0,leftPos.position);
        left.SetPosition(1,transform.position);
    }

    //下一只小鸟的飞出
    void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }
}
