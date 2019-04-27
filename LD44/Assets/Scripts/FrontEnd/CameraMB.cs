using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMB : MonoBehaviour
{
    public static Camera MainCamera;

    private void Start()
    {
        MainCamera = GetComponent<Camera>();
    }
}