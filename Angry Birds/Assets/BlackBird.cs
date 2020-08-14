﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBird : Bird
{
    public List<Pig> blocks = new List<Pig>();

    //进入触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());        
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        if (blocks.Count > 0 && blocks != null) 
        {
            for (int i = 0; i < blocks.Count; i++) 
            {
                blocks[i].Dead();
            
            }
        
        }
    }
}
