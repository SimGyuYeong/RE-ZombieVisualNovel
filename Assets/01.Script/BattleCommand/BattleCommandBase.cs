using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleCommandBase
{   
    GameObject[ , ] tileMap = new GameObject[8,8];

    GameObject loadPrefab;

    public void StageLoader(string stageName)
    {
        loadPrefab = Resources.Load<GameObject>($"Stages/{stageName}");

        if(loadPrefab == null)
        {
            Debug.Log("스테이지 프리팹 로드 오류");
            return;
        }
    }

    public void StageSet()
    {
        if(loadPrefab == null)
        {
            Debug.Log("스테이지 세팅 오류");
            return;
        }

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                tileMap[i , j] = loadPrefab.transform.GetChild(i * 8 + j).gameObject;
                Debug.Log(i * 8 + j);
            }
        }
    }
}
