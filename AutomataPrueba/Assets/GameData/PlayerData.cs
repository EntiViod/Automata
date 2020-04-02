using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum HeroEnum
{
    SOLDIER76
}
[CreateAssetMenu(fileName ="Create",menuName ="PlayerData/Create",order = 0)]
public class PlayerData : ScriptableObject
{
    public float reloadingTime;
    public float totalBullets;
    public float shootingCooldown;
    public float life;
    public GameObject image;
    public GameObject projectileType;
    public GameObject[] abilities;

}
