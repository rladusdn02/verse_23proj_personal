using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScriptManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Mirror")
        {
            // Mirror Scene에 필요한 컴포넌트 활성화/비활성화
            PlayerController playerController = FindObjectOfType<PlayerController>();
            Animator animator = playerController.GetComponent<Animator>();
            CharacterMove characterMove = playerController.GetComponent<CharacterMove>();
            CapsuleCollider collider = playerController.GetComponent<CapsuleCollider>();

            animator.enabled = false;
            characterMove.enabled = false;
            collider.enabled = false;

            HairController hairController = playerController.GetComponent<HairController>();
            hairController.enabled = true;
        }
        else if (sceneName == "HomeMinju")
        {
            // HomeMinju Scene에 필요한 컴포넌트 활성화/비활성화
            PlayerController playerController = FindObjectOfType<PlayerController>();
            Animator animator = playerController.GetComponent<Animator>();
            CharacterMove characterMove = playerController.GetComponent<CharacterMove>();
            CapsuleCollider collider = playerController.GetComponent<CapsuleCollider>();

            animator.enabled = true;
            characterMove.enabled = true;
            collider.enabled = true;

            HairController hairController = playerController.GetComponent<HairController>();
            hairController.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
