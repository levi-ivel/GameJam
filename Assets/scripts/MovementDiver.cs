using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementDiver : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float harpoonSpeed = 10f;
    public float harpoonDistance = 5f;
    public float timeBetweenShots = 2f;
    public GameObject harpoonPrefab;
    private Rigidbody2D rb;
    private GameObject shop;
    private bool canShoot = true;
    public Text fishCountText;
    private int fishCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shop = GameObject.Find("ShopPanel");
        shop.SetActive(false);
    }

    private void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine(ShootHarpoon());
        }
    }

    private void HandleMovement()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement * moveSpeed);
    }

    private IEnumerator ShootHarpoon()
    {
        canShoot = false;

        bool originalColliderState = GetComponent<Collider2D>().enabled;

        GetComponent<Collider2D>().enabled = false;

        GameObject harpoon = Instantiate(harpoonPrefab, transform.position, Quaternion.identity);
        Rigidbody2D harpoonRb = harpoon.GetComponent<Rigidbody2D>();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 harpoonDirection = (mousePosition - (Vector2)transform.position).normalized;

        harpoonRb.AddForce(harpoonDirection * harpoonSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(harpoonDistance / harpoonSpeed);

        Destroy(harpoon);

        yield return new WaitForSeconds(1.0f);

        GetComponent<Collider2D>().enabled = originalColliderState;

        yield return new WaitForSeconds(timeBetweenShots);

        canShoot = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("shop"))
        {
            shop.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("surface"))
        {
            //SceneManager.LoadScene(2);
        }

        if (other.CompareTag("deep1"))
        {
            SceneManager.LoadScene(1);
        }

        if (other.CompareTag("GunCave"))
        {
            SceneManager.LoadScene(3);
        }

        if (other.CompareTag("shop"))
        {
            shop.SetActive(true);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("deadfish1"))
        {
            Destroy(collision2D.gameObject);
            GameManager.Instance.AddToInventory(collision2D.gameObject);
            GameManager.Instance.fishCount++;
            GameManager.Instance.UpdateFishCountText();
            GameManager.Instance.SaveGameData();
            fishCount++;
            UpdateFishCountText();
        }

        if (collision2D.gameObject.CompareTag("deadfish2"))
        {
            Destroy(collision2D.gameObject);
            GameManager.Instance.AddToInventory(collision2D.gameObject);
            GameManager.Instance.fishCount++;
            GameManager.Instance.UpdateFishCountText();
            GameManager.Instance.SaveGameData();
            fishCount++;  
            UpdateFishCountText();
        }

        if (collision2D.gameObject.CompareTag("deadfish3"))
        {
            Destroy(collision2D.gameObject);
            GameManager.Instance.AddToInventory(collision2D.gameObject);
            GameManager.Instance.fishCount++;
            GameManager.Instance.UpdateFishCountText();
            GameManager.Instance.SaveGameData();
            fishCount++;
            UpdateFishCountText();
        }
    }
    void UpdateFishCountText()
    {
        PlayerPrefs.SetInt("FishCount", fishCount);
        PlayerPrefs.Save();
        fishCountText.text = "Fish: " + fishCount;
    }
}



