using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private Animator anim;

    public GameObject button;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Retry()
    {

    }

    //点击了pause按钮
    public void Pause()
    {
        //播放暂停动画
        anim.SetBool("isPause", true);
        button.SetActive(false);
       
    }

    //点击了继续按钮
    public void Resume()
    {
        //播放继续动画
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
    }

    public void Home()
    {

    }

    //暂停动画播放完
    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    //继续动画播放完
    public void ResumeAnimEnd()
    {
        button.SetActive(true);
    }
}
