using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;

    private List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;


    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public int spawnInterval;

    private float timer;


    // Start is called before the first frame update
    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 postition)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (postition.x < powerUpAreaMin.x || 
            postition.x > powerUpAreaMax.x ||
            postition.y < powerUpAreaMin.y ||
            postition.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(postition.x, postition.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
