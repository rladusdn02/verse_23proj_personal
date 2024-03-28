using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    Vector3 HomePosition = new Vector3(-29.41f, 1.22f, 3f);
    Vector3 HomeRotation = new Vector3(0f, 90f, 0f);
    Vector3 MirrorPosition = new Vector3(4f, 1.49f, 0f);
    Vector3 MirrorRotation = new Vector3(0f, 180f, 0f);
    Vector3 DefaultScale = new Vector3(1f, 1f, 1f);
    Vector3 ElevatorPosition = new Vector3(2.738f, -1.335f, 0.798f);
    Vector3 ElevatorRotation = new Vector3(0f, -90f, 0f);
    Vector3 ElevatorScale = new Vector3(0.13f, 0.13f, 0.13f);

    static bool isCreated = false;

    void Start()
    {
        if (isCreated)
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        isCreated = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Mirror")
        {
            transform.position = MirrorPosition;
            transform.rotation = Quaternion.Euler(MirrorRotation);
            transform.localScale = DefaultScale;
        }
        else if (scene.name == "Elevator")
        {
            transform.position = ElevatorPosition;
            transform.rotation = Quaternion.Euler(ElevatorRotation);
            transform.localScale = ElevatorScale;
        }

        if (scene.name == "HomeMinju")
        {
            transform.position = HomePosition;
            transform.rotation = Quaternion.Euler(HomeRotation);
            transform.localScale = DefaultScale;
        }
    }
}
