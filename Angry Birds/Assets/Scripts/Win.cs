using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public void Show() 
    {
        //动画播完后显示星星的操作
        GameManager._instance.ShowStars();
    }
}
