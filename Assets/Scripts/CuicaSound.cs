using UnityEngine;

public class CuicaSound : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float timeToBeDestroyed;

    void Update()
    {
        timer += Time.deltaTime * 1000;

        if (timer >= timeToBeDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
