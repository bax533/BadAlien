using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour 
{
    public bool gameStarted { get; set; }

    public int numOfSpawnedGreens { get; set; }
    public float timeToExpandGreen { get; set; }
    public int points { get; set; }

    public int score { get; set; }
    public float timeLeft { get; set; }


// missile speed upgrade variables
    public int missileSpeedCurrentLevel { get; private set; }
    public int[] missileSpeedUpgradePrices { get; private set; }
    public float[] missileSpeeds { get; private set; }
    public float currentMissileSpeed { get; private set; }

// explosion upgrade variables
    public int explosionRangeCurrentLevel { get; private set; }
    public int[] explosionRangeUpgradePrices { get; private set; }
    public float[] explosionRanges { get; private set; }
    public float currentExplosionRange { get; private set; }

// missile cooldown upgrade variables
    public int missileCooldownCurrentLevel { get; private set; }
    public int[] missileCooldownUpgradePrices { get; private set; }
    public float[] missileCooldowns { get; private set; }
    public float currentMissileCooldown { get; private set; }

// movement speed upgrade variables
    public int movementSpeedCurrentLevel { get; private set; }
    public int[] movementSpeedUpgradePrices { get; private set; }
    public float[] movementSpeeds { get; private set; }
    public float currentMovementSpeed { get; private set; }

    public static Singleton Instance { get; private set; }

    private void Awake() 
    { 
        gameStarted = false;
        // If there is an instance, and it's not me, delete myself.
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }

        Instance.numOfSpawnedGreens = 0;
        Instance.timeToExpandGreen = 20.0f;
        Instance.points = 9999;
        Instance.score = 0;

        Instance.missileSpeedCurrentLevel = 0;
        Instance.missileSpeedUpgradePrices = new int[4] {5, 10, 15, 20};
        Instance.missileSpeeds = new float[5] {10.0f, 19.0f, 35.0f, 60.0f, 120.0f};
        Instance.currentMissileSpeed = Instance.missileSpeeds[0];


        Instance.explosionRangeCurrentLevel = 0;
        Instance.explosionRangeUpgradePrices = new int[4] {10, 20, 30, 40};
        Instance.explosionRanges = new float[5] {1.0f, 1.35f, 1.7f, 2.05f, 2.5f};
        Instance.currentExplosionRange = Instance.explosionRanges[0];


        Instance.missileCooldownCurrentLevel = 0;
        Instance.missileCooldownUpgradePrices = new int[4] {15, 40, 80, 150};
        Instance.missileCooldowns = new float[5] {8.0f, 6.0f, 4.0f, 2.0f, 1.0f};
        Instance.currentMissileCooldown = Instance.missileCooldowns[0];


        Instance.movementSpeedCurrentLevel = 0;
        Instance.movementSpeedUpgradePrices = new int[2] {500, 100};
        Instance.movementSpeeds = new float[3] {0.0f, 17.5f, 30.0f};
        Instance.currentMovementSpeed = Instance.movementSpeeds[0];
    }

    private void Update()
    {
        if(!gameStarted)
            return;

        Instance.score = GameObject.FindGameObjectsWithTag("Green").Length;

        Instance.timeLeft -= Time.deltaTime;
        if(Instance.timeLeft <= 0.0f)
        {
            Instance.gameStarted = false;
            GameObject.Find("Earth").GetComponent<EarthScript>().UI_Canvas.SetActive(false);
            GameObject.Find("Earth").GetComponent<EarthScript>().End_Canvas.SetActive(true);
        }
    }

    public void UpgradeMissileSpeed()
    {
        Instance.points -= missileSpeedUpgradePrices[Instance.missileSpeedCurrentLevel];
        Instance.missileSpeedCurrentLevel += 1;
        Instance.currentMissileSpeed = Instance.missileSpeeds[Instance.missileSpeedCurrentLevel];
    }

    public void UpgradeExplosionRange()
    {
        Instance.points -= explosionRangeUpgradePrices[Instance.explosionRangeCurrentLevel];
        Instance.explosionRangeCurrentLevel += 1;
        Instance.currentExplosionRange = Instance.explosionRanges[Instance.explosionRangeCurrentLevel];
    }
    
    public void UpgradeMissileCooldown()
    {
        Instance.points -= missileCooldownUpgradePrices[Instance.missileCooldownCurrentLevel];
        Instance.missileCooldownCurrentLevel += 1;
        Instance.currentMissileCooldown = Instance.missileCooldowns[Instance.missileCooldownCurrentLevel];
    }
    
    public void UpgradeMovementSpeed()
    {
        Instance.points -= movementSpeedUpgradePrices[Instance.movementSpeedCurrentLevel];
        Instance.movementSpeedCurrentLevel += 1;
        Instance.currentMovementSpeed = Instance.movementSpeeds[Instance.movementSpeedCurrentLevel];
    }

    public void StartGame(float gameTime)
    {
        Instance.timeLeft = gameTime;
        Instance.gameStarted = true;
    }

    public void RegisterSpawnedGreen()
    {
        Instance.numOfSpawnedGreens += 1;
    }
}
