using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    // Always Button Objects
    public GameObject SettingPanel;
    public GameObject QuitPanel;

    public GameObject ChatPanel;
    public GameObject ProfilePanel;
    public GameObject FriendsListPanel;
    public GameObject ChatBubblePanel;
    public GameObject FriendAccount;
    public GameObject AddFriendPanel;


    // Writing Journal Objects
    public GameObject writingPanel;
    public GameObject newPostPanel;


// Always Button Codes

    void Start ()
    {
        SettingPanel.SetActive(false);
        QuitPanel.SetActive(false);
        ChatPanel.SetActive(false);
        ProfilePanel.SetActive(false);
        FriendsListPanel.SetActive(false);
        ChatBubblePanel.SetActive(false);
        FriendAccount.SetActive(false);
        AddFriendPanel.SetActive(false);
    }

    // Setting Button OnClick
    public void ClickSettingBtn ()
    {
        if (SettingPanel.activeSelf == false)
        {
            SettingPanel.SetActive(true);
        }
        else{
            SettingPanel.SetActive(false);
        }
    }

    // Chatting Button OnClick
    public void ClickChattingBtn () 
    {
        if(ChatPanel.activeSelf == false)
        {
            ChatPanel.SetActive(true);
            ProfilePanel.SetActive(true);
            FriendsListPanel.SetActive(false);
            FriendAccount.SetActive(false);
            ChatBubblePanel.SetActive(false);
        }
        else{
            ChatPanel.SetActive(false);
            ProfilePanel.SetActive(false);

        }
    }

    public void ClickChattingListBtn ()
    {
        if(ProfilePanel.activeSelf == true)
        {
            ProfilePanel.SetActive(false);
            FriendsListPanel.SetActive(true);
            ChatBubblePanel.SetActive(false);
        }
        else
        {
            ProfilePanel.SetActive(true);
            FriendsListPanel.SetActive(false);
            ChatBubblePanel.SetActive(false);
        }
    }

    public void ClickFriendChat ()
    {
        if(FriendsListPanel.activeSelf == true)
        {
            FriendsListPanel.SetActive(false);
            ChatBubblePanel.SetActive(true);
        }
        else
        {
            FriendsListPanel.SetActive(true);
            ChatBubblePanel.SetActive(false);
        }
    }

    public void ClickFriendAccount()
    {
        if (FriendAccount.activeSelf == false)
        {
            ChatPanel.SetActive(false);
            FriendAccount.SetActive(true);
        }
    }

    // Quit Button OnClick
    public void ClickQuitBtn()
    {

    }




// Writing Journal Codes
    public void CloseWritingPanel() 
    {
        writingPanel.SetActive(false);
    }

    public void OpenNewPost() 
    {
        newPostPanel.SetActive(true);
    }

    public void CloseNewPost() 
    {
        newPostPanel.SetActive(false);
    }
}
