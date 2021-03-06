using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GolfController : MonoBehaviour
{
    // Drag & Shoot
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    public TrajectoryLine tl;
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    // Shots
    public static int totalShots;
    public static bool canShoot;
    public TextMeshProUGUI shotsText;
    public Image golfClubImage;

    public GameObject pauseButton;

    // Collectible Items
    public static int amountOfGoldCoin;
    public static int amountOfBlueCoin;
    public static int totalCoins;
    public TextMeshProUGUI coinsText;
    public Image coinImage;

    public static int tempShots;
    public static int tempCoins;

    private void Start()
    {
        amountOfGoldCoin = 0;
        amountOfBlueCoin = 0;
        totalShots = 0;
        canShoot = true;

        // Drag & Shoot
        if (canShoot)
        {
            cam = Camera.main;
            tl = GetComponent<TrajectoryLine>();
        }
    }

    private void Update()
    {
        // Drag & Shoot
        if (canShoot)
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }

            if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
                tl.RenderLine(startPoint, currentPoint);
            }

            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;

                force = new Vector2(
                    Mathf.Clamp(
                        startPoint.x - endPoint.x,
                        minPower.x, maxPower.x),
                    Mathf.Clamp(
                        startPoint.y - endPoint.y,
                        minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                totalShots++;
                shotsText.text = totalShots.ToString();
                tl.EndLine();
            }
        }

        // Collectible Items
        // Change amount of total coints
        totalCoins = amountOfGoldCoin + amountOfBlueCoin;
        coinsText.text = totalCoins.ToString();
    }

    // When player go outside from scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Game over condition
        if (collision.tag == "FrameBorder")
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);

            Destroy(coinsText);
            Destroy(shotsText);
            Destroy(coinImage);
            Destroy(golfClubImage);
        }

        // Game finish condition
        if (collision.tag == "Finish")
        {
            tempShots = totalShots;
            tempCoins = totalCoins;

            PlayerManager.isGameFinish = true;
            gameObject.SetActive(false);

            Destroy(coinsText);
            Destroy(shotsText);
            Destroy(coinImage);
            Destroy(golfClubImage);
            pauseButton.SetActive(false);
        }
    }
}
