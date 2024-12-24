using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // ��������� ������ ����
    public GameObject[] prefabs;

    // Ǯ�� ����ϴ� ����Ʈ��
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;
        // ������ Ǯ�� ���(��Ȱ��ȭ��) �ִ� ���� ������Ʈ ����
        // �߰��ϸ� select ������ �Ҵ�
        foreach(GameObject item in pools[i])
        {
            if (!item.activeSelf)
            { // �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // ��� ���������� ���Ӱ� �����ϰ� select ������ �Ҵ�
        if (!select)
        {
            select = Instantiate(prefabs[i],transform);
            pools[i].Add(select);
        }

        return select;
    }


}