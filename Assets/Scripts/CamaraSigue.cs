using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    public Transform objetivo;
    public Vector3 offset = new Vector3(0, 6, -6);

    void LateUpdate()
    {
        if (objetivo != null)
        {
            transform.position = objetivo.position + offset;
        }
    }
}
