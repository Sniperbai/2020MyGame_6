﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public bool isSelect = false;
    public Sprite levelBG;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        if (transform.parent.GetChild(0).name == gameObject.name) 
        {
            isSelect = true;
        }

        if (isSelect) 
        {
            image.overrideSprite = levelBG;
            transform.Find("num").gameObject.SetActive(true);
        }
    }
}