using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brid : MonoBehaviour
{
    private bool isclick = false ;
    public Transform rightPos;
    public float maxDis = 3;

    private void OnMouseDown()
    {
        isclick = true;
    }

    private void OnMouseUp()
    {
        isclick = false;
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
        }
    }
}
