using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    private Vector2 originalPosition;
    private float minDistance;
    private float maxDistance;
    private float moveSpeed;
    private float rotationSpeed;
    public float hoverAmplitude = 0.005f;
    public float hoverDuration = 1f;
    public GameObject deadfishprefab;


    private void Start()
    {

        originalPosition = transform.position;


        minDistance = 1f;
        maxDistance = 5f;


        moveSpeed = 2f;
        rotationSpeed = 180f;


        StartCoroutine(MoveFish());
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);

            Instantiate(deadfishprefab, transform.position, transform.rotation);

        }
    }
        private IEnumerator MoveFish()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 10f));

            float hoverTimer = 0f;
            float originalZ = transform.position.z;

            while (hoverTimer < hoverDuration)
            {
                transform.position += new Vector3(0f, Mathf.Sin(Time.time) * hoverAmplitude, 0f);
                transform.position = new Vector3(transform.position.x, transform.position.y, originalZ); 
                hoverTimer += Time.deltaTime;
                yield return null;
            }

            hoverTimer = 0f;

            float distance = Random.Range(minDistance, maxDistance);
            Vector2 targetPosition = originalPosition + new Vector2(distance, 0f);

            while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position += new Vector3(0f, Mathf.Sin(Time.time) * hoverAmplitude, 0f);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, originalZ); 
                yield return null;
            }

            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

            yield return new WaitForSeconds(Random.Range(1f, 10f));

            while (Vector2.Distance(transform.position, originalPosition) > 0.1f)
            {
                transform.position += new Vector3(0f, Mathf.Sin(Time.time) * hoverAmplitude, 0f);
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, transform.position.y, originalZ);
                yield return null;
            }

            transform.rotation = Quaternion.identity;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }

}
  










