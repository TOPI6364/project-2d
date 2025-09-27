using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Vector3 Offcet;
    [SerializeField] float CameraSpeed = 1f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, (GameManager.Instance.player.transform.position + Offcet), CameraSpeed * Time.deltaTime);
    }
}
