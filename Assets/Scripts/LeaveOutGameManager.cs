﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaveOutGameManager : BaseGameManager
{
    //使用するイラスト
    Sprite sprite_a;
    Sprite sprite_b;

    //画面上にあるアイコン
    Image[] icon;

    //イラストの数（イラストの通し番号の最も大きい数）
    public int spriteMax;

    public override void Arrangements()
    {
        GameObject iconParent = GameObject.Find("IconParent");
        if (!iconParent)
        {
            return;
        }

        int childCount = iconParent.transform.childCount;
        icon = new Image[childCount];

        for (int n = 0; n < childCount; n++)
        {
            Transform childTransform = iconParent.transform.GetChild(n);
            GameObject childObject= childTransform.gameObject;

            icon[n] = childObject.GetComponent<Image>();
        }

        RandomChange();
    }

    void RandomChange()
    {
        int randomIcon = Random.Range(0, icon.Length);
        spriteMax++;
        int randomTexture = Random.Range(0, spriteMax);

        if (Resources.Load<Sprite>("ProjectAssets/GameIcon/Icon_" + randomTexture))
        {
            sprite_a = Resources.Load<Sprite>("ProjectAssets/GameIcon/Icon_" + randomTexture);

            if (randomTexture % 2 == 0)
            {
                randomTexture++;
            }
            else
            {
                randomTexture--;
            }
            sprite_b = Resources.Load<Sprite>("ProjectAssets/GameIcon/Icon_" + randomTexture);
        }

        for (int i = 0; i < icon.Length; i++)
        {
            if (i == randomIcon)
            {
                icon[i].sprite = sprite_b;
                continue;
            }

            icon[i].sprite = sprite_a;
        }
    }

    public override void TimeUp()
    {
        
    }
}
