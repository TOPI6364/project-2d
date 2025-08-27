using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Offcet;
    [SerializeField] float CameraSpeed = 1f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, (Player.position + Offcet), CameraSpeed * Time.deltaTime);
    }
}
