using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // 플레이어 이동 방향
    Vector3 dir;
    // 애니메이터 컴포넌트
    public Animator animator;
    // 캐릭터 컨트롤러 컴포넌트
    CharacterController characterController;
    // 이동 속도
    public float speed = 20.0f;

    void Start()
    {
        // 초기화
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        // 걷는 애니메이션 비활성화
        animator.SetBool("isWalk", false);
    }

    void Update()
    {
        Move();
    }   

    void Move ()
    {
        // 캐릭터가 땅에 있을 때만 이동 가능
        if (characterController.isGrounded)
        {
            // 걷는 애니메이션 비활성화
            animator.SetBool("isWalk", false);

            // 수평 및 수직 입력 값 가져오기
            var h = Input.GetAxis("Horizontal");
            if (h != 0)
            {
                Debug.Log("Horizontal");
            }
            var v = Input.GetAxis("Vertical");
            if (v != 0)
            {
                Debug.Log("Vertical");
            }
            // 이동 방향 설정
            dir = new Vector3(h, 0, v) * speed;

            if (dir != Vector3.zero)
            {
                
                // 걷는 애니메이션 활성화
                animator.SetBool("isWalk", true);
                // 입력된 방향으로 캐릭터 회전
                transform.rotation = Quaternion.Euler(0, Mathf.Atan2(h, v) * Mathf.Rad2Deg, 0);
            }
            else
                // 걷는 애니메이션 비활성화
                animator.SetBool("isWalk", false);

            // 스페이스 키를 누르면 점프
            if (Input.GetKeyDown(KeyCode.Space))
                dir.y = 5f;
        }

        // 중력에 따른 수직 이동
        dir.y += Physics.gravity.y * Time.deltaTime;
        // 캐릭터 이동
        characterController.Move(dir * Time.deltaTime);
    }
}
