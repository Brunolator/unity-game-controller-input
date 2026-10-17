using UnityEngine;

public class PropellerSpinX : MonoBehaviour
{
    public float rotationSpeed = 5000f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
