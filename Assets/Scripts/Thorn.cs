using UnityEngine;


public class Thorn : MonoBehaviour
{
    public GameManager gm;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("thorn"))
        {
            gm.EndGame();
        }
      
    }
}
