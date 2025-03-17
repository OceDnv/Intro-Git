using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Vérification
        if (other.gameObject.CompareTag("Collectable")) 
        {
            Debug.Log("Objet collecté !"); // message console

            // son
            AudioSource audio = other.GetComponent<AudioSource>();
            if (audio != null) 
            {
                audio.Play(); // joue son
            }

            Destroy(other.gameObject, 0.1f); // objet paf
        }
        
        if (other.gameObject.CompareTag("EndZone")) 
        {
            Debug.Log("Fin de partie !");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}