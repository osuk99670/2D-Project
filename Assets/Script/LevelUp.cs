using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    public void Show()
    {
        Next();
        rect.localScale= Vector3.one;
        GameManager.instance.GameStop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.GameResume();
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }

    void Next()
    {
        foreach(Item item in items)
        {
            item.gameObject.SetActive(false);//��� ������ ��Ȱ��ȭ
        }

        int[] rand = new int[3];
        while (true)
        {
            rand[0] = Random.Range(0, items.Length);
            rand[1] = Random.Range(0, items.Length);
            rand[2] = Random.Range(0, items.Length);
            if (rand[0] != rand[1] && rand[1] != rand[2] && rand[0] != rand[2])  //���� 3�� ������ Ȱ��ȭ
            {
                break;
            }
        }

        for(int index=0; index<rand.Length; index++)
        {
            Item randItem = items[rand[index]];

            if (randItem.level==randItem.data.damages.Length) //���� �������� ���� �Һ���������� ��ü
            {
                items[4].gameObject.SetActive(true);
            }
            else
            {
                randItem.gameObject.SetActive(true);
            }
        }
    }
}