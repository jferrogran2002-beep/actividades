using UnityEngine;

public class Colliders : MonoBehaviour
{
    private bool esNegro = false;
    private Color colorOriginal = new Color(0.051f,0.439f,1.0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area1"))
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area2"))
        {
            Renderer rend = GetComponent<Renderer>();
            if (!esNegro)
            {
                rend.material.color = Color.black;
                 esNegro = true;
            }
            else
            {
                rend.material.color = colorOriginal;
                esNegro = false;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Pin"))
        {
            Vector3 escala = hit.gameObject.transform.localScale;
            hit.gameObject.transform.localScale = new Vector3(escala.x, escala.y + 0.8f, escala.z);
            hit.gameObject.tag = "Untagged";
        }

        if (hit.gameObject.CompareTag("Pin2"))
        {
            Rigidbody body = hit.collider.attachedRigidbody;
            Vector3 direccionEmpuje = hit.moveDirection;
            if (direccionEmpuje.y < -0.3f) return;
            body.AddForceAtPosition(direccionEmpuje, hit.point, ForceMode.Impulse);
            
        }
    }
}