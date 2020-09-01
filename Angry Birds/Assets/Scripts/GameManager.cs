using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Bird> birds;
    public List<Pig> pig;

    public static GameManager _instance;

    private Vector3 originPos;  //初始化位置

    public GameObject win;
    public GameObject lose;

    public GameObject[] stars;

    private int starsNum = 0;

    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originPos = birds[0].transform.position;
        }

    }

    private void Start()
    {
        Initialized();
    }


    //初始化小鸟
    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0) //第一只小鸟
            {
                birds[i].transform.position = originPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }
    // 判定游戏逻辑
    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //下一只飞吧
                Initialized();
            }
            else
            {
                //输了
                lose.SetActive(true);
            }
        }
        else
        {
            //赢了
            win.SetActive(true);
        }
    }

    public void ShowStars()
    {
        StartCoroutine("show");

    }

    IEnumerator show()
    {
        for (; starsNum < birds.Count + 1; starsNum++)
        {
            if (starsNum >= stars.Length)
            {
                break;
            }
            yield return new WaitForSeconds(0.3f);
            stars[starsNum].SetActive(true);
        }
        print(starsNum);
    }

    public void Replay()
    {
        SaveDate();
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        SaveDate();
        SceneManager.LoadScene(1);
    }

    public void SaveDate()
    {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"),starsNum);
    }
}
