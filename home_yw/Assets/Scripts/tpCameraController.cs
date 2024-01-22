using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class tpCameraController : MonoBehaviour
{
    public GameObject Target;               // 추적할 대상 오브젝트
    public float offsetX = 0.0f;            // 카메라의 x축 오프셋
    public float offsetY = 10.0f;           // 카메라의 y축 오프셋
    public float offsetZ = -10.0f;          // 카메라의 z축 오프셋
    public float CameraSpeed = 10.0f;       // 카메라 이동 속도
    public float angleX = 0.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    Vector3 TargetPos;                      // 대상의 현재 위치

    void Start()
    {
        // 초기화 코드 작성
    }

    void Update()
    {
        // 대상의 위치에 오프셋을 더한 위치를 구함
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
        );

        // 카메라를 대상의 위치로 부드럽게 이동시키는 함수인 Lerp를 이용하여 이동
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
