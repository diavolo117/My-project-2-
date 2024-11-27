
using UnityEngine;

public class spice : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<lives>().facebreak(damage);
        }
    }
}
