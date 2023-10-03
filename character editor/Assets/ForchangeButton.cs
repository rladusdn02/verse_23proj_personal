using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForchangeButton : MonoBehaviour
{
    public GameObject[] hairs;
    public Hairchanger hairchangerComponent; // Hairchanger 컴포넌트를 직접 참조할 변수
    bool sDown1;
    bool sDown2;
    bool sDown3;

    void Start()
    {
        // Hairchanger 컴포넌트를 이 스크립트에서 직접 참조
        hairchangerComponent = FindObjectOfType<Hairchanger>();
        if (hairchangerComponent == null)
        {
            Debug.LogError("Hairchanger 컴포넌트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        GetInput();
        
        if (sDown1)
        {
            Debug.Log("1을 눌렀습니다.");
            hairchangerComponent.value = 0;
        }
        else if (sDown2)
        {
            Debug.Log("2을 눌렀습니다.");
            hairchangerComponent.value = 1;
        }
        else if (sDown3)
        {
            Debug.Log("3을 눌렀습니다.");
            hairchangerComponent.value = 2;
        }
        
        Swap();
    }

    void Swap()
    {
        int hairsIndex = -1;
        if (sDown1) hairsIndex = 0;
        if (sDown2) hairsIndex = 1;
        if (sDown3) hairsIndex = 2;

        if (hairsIndex != -1 && hairchangerComponent != null)
        {
            int value = hairchangerComponent.value;

            for (int i = 0; i < hairs.Length; i++)
            {
                if (i == value)
                {
                    hairs[i].SetActive(true); // value와 일치하는 asset 활성화
                }
                else
                {
                    hairs[i].SetActive(false); // 나머지 asset 비활성화
                }
            }

            Debug.Log("Value: " + value);
        }
    }

    void GetInput()
    {
        sDown1 = Input.GetKeyDown(KeyCode.Alpha1);
        sDown2 = Input.GetKeyDown(KeyCode.Alpha2);
        sDown3 = Input.GetKeyDown(KeyCode.Alpha3);
    }
}
