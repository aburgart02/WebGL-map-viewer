using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float MouseSensitivity = 200f;
    private const float MoveSpeed = 10f;

    private float _xRotation;
    private float _yRotation;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.position += transform.forward * (Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        var horizontalRotation = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        var verticalRotation = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        _xRotation -= verticalRotation;
        _yRotation += horizontalRotation;
        transform.rotation = Quaternion.Euler(new Vector3(_xRotation, _yRotation));
    }
}