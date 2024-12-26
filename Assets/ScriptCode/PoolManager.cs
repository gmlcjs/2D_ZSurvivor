using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 보관할 변수
    public GameObject[] prefabs;

    // 풀을 담당하는 리스트들
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int idxex)
    {
        GameObject select = null;
        // 선택한 풀의 놀고(비활성화된) 있는 게임 오브젝트 접근
        // 발견하면 select 변수에 할당
        foreach(GameObject item in pools[idxex])
        {
            if (!item.activeSelf)
            { // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // 모두 쓰고있으면 새롭게 생성하고 select 변수에 할당
        if (!select)
        {
            select = Instantiate(prefabs[idxex],transform);
            pools[idxex].Add(select);
        }

        return select;
    }


}