using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 1.5f; 
    public LayerMask interactLayer; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactDistance, interactLayer);

        if (hits.Length > 0)
        {
            Collider2D closest = null;
            float closestDistance = Mathf.Infinity;

            foreach (Collider2D hit in hits)
            {
                float distance = Vector2.Distance(transform.position, hit.transform.position);

                if (distance < closestDistance)
                {
                    closest = hit;
                    closestDistance = distance;
                }
            }

            closest.GetComponent<Interactable>()?.Interact();
        }
    }
}
