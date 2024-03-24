using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ChattingManager : MonoBehaviour
{
    public GameObject chatPanel;
    public GameObject chatMessagePrefab;
    public TMP_InputField chatInputField;
    public Button sendButton; // 추가: 전송 버튼

    private bool isTyping = false;

    void Start() 
    {
        sendButton.onClick.AddListener(SendMessage); // 추가: 버튼 클릭 시 SendMessage 함수 호출
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭된 위치의 UI 요소를 확인
            PointerEventData eventData = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            UnityEngine.EventSystems.EventSystem.current.RaycastAll(eventData, results);
            
            foreach (RaycastResult result in results)
            {
                if (result.gameObject == chatInputField.gameObject)
                {
                    // 채팅 입력 필드를 클릭하면 커서를 활성화
                    isTyping = true;
                    chatInputField.Select();
                    chatInputField.ActivateInputField();
                    break;
                }
            }
        }

        if (isTyping && Input.GetKeyDown(KeyCode.Return))
        {
            // 엔터를 누르면 채팅 전송
            SendMessage();
        }
    }

    public void SendMessage()
    {
        string message = chatInputField.text;
        if (!string.IsNullOrEmpty(message))
        {
            GameObject chatMessage = Instantiate(chatMessagePrefab, chatPanel.transform);
            TextMeshProUGUI textMeshPro = chatMessage.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = message;
            textMeshPro.color = Color.black; // 추가: 텍스트 색상 검정색으로 설정
            chatInputField.text = ""; // Clear input field after sending message
        }
        isTyping = false;
    }
}
