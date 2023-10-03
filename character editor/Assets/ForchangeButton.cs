using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForchangeButton : MonoBehaviour
{
    public GameObject[] hairs;
    public bool[] hasHairs;
    bool sDown1;
    bool sDown2;
    bool sDown3;
    Hairchanger hairchangerComponent; // Hairchanger 컴포넌트를 저장할 변수

    // Start is called before the first frame update
    void Start()
    {
        // Hairchanger 컴포넌트를 가지고 있는 게임 오브젝트를 찾아서 가져옴
        hairchangerComponent = FindObjectOfType<Hairchanger>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput(); // 숫자 키 입력을 감지
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) // "1" 키 입력을 감지
        {
            Debug.Log("1을 눌렀습니다.");
        }
        
        Swap(); // Swap 함수 호출
    }

    void Swap()
    {
        int hairsIndex = -1;
        if (sDown1) hairsIndex = 0;
        if (sDown2) hairsIndex = 1;
        if (sDown3) hairsIndex = 2;

        if (hairchangerComponent != null)
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

            if (hairsIndex != -1)
            {
                hairs[hairsIndex].SetActive(true); // 선택한 asset 활성화
            }

            // 이제 type 및 value 변수를 사용할 수 있습니다.
            Debug.Log("Type: " + type);
            Debug.Log("Value: " + value);
        }
        else
        {
            Debug.LogWarning("Hairchanger 컴포넌트를 찾을 수 없습니다.");
        }
    }

    void GetInput()
    {
        sDown1 = Input.GetKeyDown(KeyCode.Alpha1); // 숫자 1 키 입력 감지
        sDown2 = Input.GetKeyDown(KeyCode.Alpha2); // 숫자 2 키 입력 감지
        sDown3 = Input.GetKeyDown(KeyCode.Alpha3); // 숫자 3 키 입력 감지
    }
}
