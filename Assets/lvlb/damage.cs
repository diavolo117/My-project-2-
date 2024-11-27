
using UnityEngine;

public class damage : MonoBehaviour
{
    private Transform curcheck;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            curcheck = collision.transform;
            print(1);

            collision.GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
    public void respawn()
    {
        transform.position = curcheck.position;

        
    }
}
