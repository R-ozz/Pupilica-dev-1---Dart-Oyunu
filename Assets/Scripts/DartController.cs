using UnityEngine;
using UnityEngine.InputSystem;

public class DartController : MonoBehaviour
{
    [SerializeField] private float throwForce = 15f;

    private Rigidbody rb;
    private bool thrown = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame && !thrown)
        {
            thrown = true;

            rb.isKinematic = false;
            rb.AddForce(transform.right * throwForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;

        DartBoard target = collision.collider.GetComponentInParent<DartBoard>();

        if (target != null)
        {
            target.TakeDamage(25);
        }
    }
}
