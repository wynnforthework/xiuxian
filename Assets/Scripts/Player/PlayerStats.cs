using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private CharacterScriptObject characterData;
    
    public float currentHealth { get; internal set; }
    public float currentRecovery { get; internal set; }
    public float currentMoveSpeed { get; internal set; }
    public float currentMight { get; internal set; }
    public float currentProjectileSpeed { get; internal set; }
    public float currentMagnet { get; internal set; }

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

    private InventoryManager inventory;
    public int weaponIndex;
    public int passiveItemIndex;
    
    public GameObject firstPassiveItemTest, secondPassiveItemTest;

    void Awake()
    {
        characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();

        inventory = GetComponent<InventoryManager>();
        
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;
        
        SpawnWeapon(characterData.StartingWeapon);
        SpawnPassiveItem(firstPassiveItemTest);
        SpawnPassiveItem(secondPassiveItemTest);
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
        if (weaponIndex>= inventory.weaponSlots.Count - 1)
        {
            Debug.LogError("Inventory slots already full");
            return;
        }
        GameObject spawnedWeapon = Instantiate(weapon);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddWeapon(weaponIndex,spawnedWeapon.GetComponent<WeaponController>());

        weaponIndex++;
    }
    
    public void SpawnPassiveItem(GameObject passiveItem)
    {
        if (passiveItemIndex>= inventory.weaponSlots.Count - 1)
        {
            Debug.LogError("Inventory slots already full");
            return;
        }
        GameObject spawnedWeapon = Instantiate(passiveItem);
        spawnedWeapon.transform.SetParent(transform);
        inventory.AddPassiveItem(passiveItemIndex,spawnedWeapon.GetComponent<PassiveItem>());

        passiveItemIndex++;
    }
}
