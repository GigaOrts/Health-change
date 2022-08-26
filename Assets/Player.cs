using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 directionOfRotation;

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        directionOfRotation.y = Input.GetAxis("Mouse X") * 150f * Time.deltaTime;

        transform.Rotate(directionOfRotation);
        transform.position += transform.rotation * direction * Time.deltaTime * 3f;
    }
}
