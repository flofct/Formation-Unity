using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    [SerializeField] float tempsAttente = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip arriv�e;

    [SerializeField] ParticleSystem crashParticules;
    [SerializeField] ParticleSystem arriv�eParticules;

    AudioSource audioSource;

    bool enTransition = false;
    bool collisionD�sactiv�e = false;

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
            collisionD�sactiv�e = !collisionD�sactiv�e;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (enTransition || collisionD�sactiv�e) { return; }
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("F�licitations, vous avez atteint l'arriv�e !");
                Arriv�e();
                break;

            case "Ami":
                break;

            case "Fuel":
                Debug.Log("Vous avez r�cup�r� du carburant.");
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
        GetComponent<MouvementFus�e>().enabled = false;
        enTransition = true;
        Invoke("ReloadLevel", tempsAttente);
    }

    void Arriv�e()
    {
        arriv�eParticules.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(arriv�e);
        GetComponent<MouvementFus�e>().enabled = false;
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
