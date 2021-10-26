using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // Collectible Items
    public int numChanceToHit = 5;
    public int coin { get { return currentChanceToHit; } }
    int currentChanceToHit;

    public static int amountOfGoldCoin;
    public static int amountOfBlueCoin;
    int totalCoins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        // Drag & Shoot
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();

        // Collectible Items
        currentChanceToHit = numChanceToHit;
    }

    private void Update()
    {
        // Drag & Shoot
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
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
            tl.EndLine();
        }

        // Collectible Items
        totalCoins = amountOfGoldCoin + amountOfBlueCoin;
        coinsText.text = totalCoins.ToString();
    }

    // Change num of chance to hit the golf
    public void ChangeChanceToHit(int amount)
    {
        currentChanceToHit = Mathf.Clamp(currentChanceToHit + amount, 0, numChanceToHit);
        Debug.Log(currentChanceToHit + "/" + numChanceToHit);
    }
}
