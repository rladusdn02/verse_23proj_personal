using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum E_STATE //사용자가 원하는 상태를 좀 더 쉽게 만들고자 하는 변수덩어리
    {
        NONE = 0, //첫숫자를 설정
        INTRO, //하나씩 늘어남!!
        START,
        CHANGE,
        END
    }
    // 게임 빌드할때는 public 삭제할것 표시
    public E_STATE gamestate; //public 으로 할 경우 함부로 변경될 수 있으므로, script내에서만 확인 가능하도록 설정해준다.
    public GameObject G_player; //player 오브젝트를 받아올 변수
    public Player player; //player 스크립트 받아올 변수
    
    //ui들을 받아올 변수 설정
    public GameObject ui_GameIntro;
    public GameObject ui_GameStart;
    public GameObject ui_CH_Appearance;

    // Start is called before the first frame update
    void Start()
    {
        GameIntro();
    }

    // Update is called once per frame
    void Update() 
    {
        GameState();
    }

    void GameState() //게임의 상태 관리
    {
        if (Input.GetKeyDown(KeyCode.Q)) //q입력하면 즉시 종료
            gamestate = E_STATE.END;

        switch(gamestate) //게임상태들을 case에 따라 구분하여 관리해준다.
        {
            //none의 유무는 play중일때 매 프레임 체크해야하는지에 따라 달라진다.
            //play의 경우, player의 life나 score를 매 프레임 체크해야하므로 none가 필요 없다.
            case E_STATE.NONE:
                //Debug.Log("NONE");
                break; 
            case E_STATE.INTRO:
                gamestate=E_STATE.NONE;
                GameIntro();
                break;
            
            case E_STATE.START:
                Debug.Log("게임시작");
                gamestate=E_STATE.NONE;
                StartCoroutine(GameStart()); //코루틴 이용해야 정상적으로 실행
                break;
            
            case E_STATE.CHANGE:
                gamestate=E_STATE.NONE;
                CH_Appearance();
                break;

            case E_STATE.END:
                Debug.Log("게임종료");
                gamestate=E_STATE.NONE;
                GameEnd();
                break;

        }
    }

    void GameIntro()
    {
        //게임 로고를 띄움
        ui_GameIntro.SetActive(true);

        //나머지 ui는 가리기
        ui_GameStart.SetActive(false);
        ui_CH_Appearance.SetActive(false);
    }

    IEnumerator GameStart() //코루틴, yeild가 필요함.
    {
        //게임 start
        ui_GameStart.SetActive(true);
        G_player.SetActive(true);

        //나머지 ui는 가리기
        ui_GameIntro.SetActive(false);
        ui_CH_Appearance.SetActive(false);
        
        G_player.SetActive(true);

        //1.5초동안 기다린 뒤 하단 스크립트 실행
        yield return new WaitForSeconds(3f); 

        //게임시작했기때문에 gamestart창은 false해준다.
        ui_GameStart.SetActive(false);

        gamestate = E_STATE.CHANGE;
    }

    void CH_Appearance()
    {

    }
    
    public void OnClickStart() //버튼에 활용할 변수는 항상 public이어야 editor에서 사용할 수 있다.
    {
        gamestate = E_STATE.START;
        //inspector 창에서 확인 가능한 가장 상단의 체크박스를 끄는 기능 : setactive
        ui_GameIntro.SetActive(false);
    }
    public void OnClickGameEnd()
    {
        gamestate = E_STATE.END;
    }
    void GameEnd()
    {
        Application.Quit(); //어플리케이션 종료 내장 함수
    }

}