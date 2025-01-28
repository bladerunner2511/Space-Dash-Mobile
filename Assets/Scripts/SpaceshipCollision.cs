using System.Collections.ObjectModel;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            // Add Game Over UI or logic here
        }
        else
        {
            //check if the object is Stardust
            if (other.CompareTag("StarDust"))
            {
                //play the Stardust collection audio clip
                AudioSource collectionsound = other.GetComponent<AudioSource>();
                if (collectionsound != null)
                {
                    collectionsound.Play();
                }

                // Destroy the coin after the audio finishes playing
                Destroy(other.gameObject, collectionsound.clip.length);

                // Notify the ScoreManager to add points
                FindObjectOfType<ScoreManager>().AddScore(1);

               
            }
        }

    }
}



