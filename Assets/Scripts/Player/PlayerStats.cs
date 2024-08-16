using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private CharacterScriptObject characterData;
    
    public float currentHealth { get; private set; }
    public float currentRecovery { get; private set; }
    public float currentMoveSpeed { get; private set; }
    public float currentMight { get; private set; }
    public float currentProjectileSpeed { get; private set; }
    public float currentMagnet { get; private set; }

    public List<GameObject> spawnedWeapons;

    [Header("Experience/Level")]
    public int experience = 0;

    public int level = 1;
    public int experienceCap = 100;
    
    [Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    [Header("I-Frames")]
    public float invincibilityDuration;
    private float invincibilityTimer;
    private bool isInvincible;

    public List<LevelRange> levelRanges;
    
    void Awake()
    {
        characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;
        
        SpawnWeapon(characterData.StartingWeapon);
    }

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    void Update()
    {
        if (invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
        
        Recover();
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }

    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level>=range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvincible)
        {
            currentHealth -= dmg;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Debug.Log("PLAYER IS DEAD");
    }

    public void RestoreHealth(float amount)
    {
        if (currentHealth<characterData.MaxHealth)
        {
            currentHealth += amount;
            if (currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    void Recover()
    {
        if (currentHealth < characterData.MaxHealth)
        {
            currentHealth += currentRecovery * Time.deltaTime;

            if (currentHealth > characterData.MaxHealth)
            {
                currentHealth = characterData.MaxHealth;
            }
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        GameObject spawnedWeapon = Instantiate(weapon);
        spawnedWeapon.transform.SetParent(transform);
        spawnedWeapons.Add(spawnedWeapon);
    }
}
