using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    [SerializeField] float tempsAttente = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip arrivée;

    [SerializeField] ParticleSystem crashParticules;
    [SerializeField] ParticleSystem arrivéeParticules;

    AudioSource audioSource;

    bool enTransition = false;
    bool collisionDésactivée = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Cheats();
    }

    void Cheats()
    {
        if (Input.GetKey(KeyCode.L))
        {
            NextLevel();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            collisionDésactivée = !collisionDésactivée;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (enTransition || collisionDésactivée) { return; }
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Félicitations, vous avez atteint l'arrivée !");
                Arrivée();
                break;

            case "Ami":
                break;

            case "Fuel":
                Debug.Log("Vous avez récupéré du carburant.");
                break;

            default:
                Crash();
                break;
        }

        
    }
    void Crash()
    {
        crashParticules.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(crash);        
        GetComponent<MouvementFusée>().enabled = false;
        enTransition = true;
        Invoke("ReloadLevel", tempsAttente);
    }

    void Arrivée()
    {
        arrivéeParticules.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(arrivée);
        GetComponent<MouvementFusée>().enabled = false;
        enTransition = true;
        Invoke("NextLevel", tempsAttente);
    }

    void ReloadLevel()
    {
        int niveauActuel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(niveauActuel);
    }

    void NextLevel()
    {
        int niveauActuel = SceneManager.GetActiveScene().buildIndex;
        int niveauSuivant = niveauActuel + 1;
        if (niveauSuivant == SceneManager.sceneCountInBuildSettings)
        {
            niveauSuivant = 0;
        }
        SceneManager.LoadScene(niveauSuivant);
    }

    void Transition()
    {
        if (enTransition == true)
        {
            audioSource.enabled = false;
        }
    }
}
