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
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1을 눌렀습니다.");
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
            // Hairchanger 스크립트에서 정의한 type과 value를 가져와서 사용
            Hairchanger.Type type = hairchangerComponent.type;
            int value = hairchangerComponent.value;

            for (int i = 0; i < hairs.Length; i++)
            {
                if (i != hairsIndex)
                {
                    hairs[i].SetActive(false); // 다른 모든 asset 비활성화
                }
            }

            if (hairsIndex >= 0 && hairsIndex < hairs.Length)
            {
                hairs[hairsIndex].SetActive(true); // 선택한 asset 활성화
            }

            // 이제 type 및 value 변수를 사용할 수 있습니다.
            Debug.Log("Type: " + type);
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
