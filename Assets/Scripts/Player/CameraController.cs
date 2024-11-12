using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(m_Target.position.x, m_Target.position.y, this.transform.position.z);
    }
}