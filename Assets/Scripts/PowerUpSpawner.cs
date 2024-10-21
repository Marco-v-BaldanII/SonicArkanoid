using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public Esmerald esmeraldPrefab;

    public Transform leftPosition;
    public Transform rightPosition;

    private bool instanciated = false;

    private Esmerald esmerald;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EsmeraldSpawning");
    }
    private IEnumerator EsmeraldSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);


            var vector = rightPosition.position - leftPosition.position;

            var multiplier = (Random.Range(-100.0f, 100.0f) / 100.0f) / 2.0f;
            Debug.Log(multiplier);
            vector *= multiplier;

            if (!instanciated)
            {
                esmerald = Instantiate(esmeraldPrefab, transform);
                instanciated = true;
            }
            
            esmerald.gameObject.SetActive(true);    
            esmerald.transform.position = vector;
            esmerald.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
