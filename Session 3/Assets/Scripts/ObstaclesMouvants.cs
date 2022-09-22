using UnityEngine;

public class ObstaclesMouvants : MonoBehaviour
{
    Vector3 positionInitiale;
    [SerializeField] Vector3 vecteurMouvement;
    [SerializeField] [Range (0,1)] float facteurMouvement;
    [SerializeField] float period = 2f;
    void Start()
    {
        positionInitiale = transform.position;
    }
    void Update()
    {
        if (period == 0f)
        {
            return;
        }

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;

        float rawSinWave = Mathf.Sin(cycles * tau);

        facteurMouvement = (rawSinWave + 1f) / 2f;

        Vector3 offset = vecteurMouvement * facteurMouvement;
        transform.position = (positionInitiale + offset);
    }
}
