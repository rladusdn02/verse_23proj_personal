using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public void GameSceneToGame(){
        SceneManager.LoadScene("game");
        Debug.Log("Game Scene Go");
    }

    public void GameSceneToIntro(){
        SceneManager.LoadScene("intro");
        Debug.Log("intro Scene Go");
    }

}
