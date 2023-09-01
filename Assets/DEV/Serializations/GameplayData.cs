using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Gameplay Data", menuName = "KumkuatGamesCase/Gameplay Data")]
public class GameplayData : ScriptableObject
{
    #region Fields

    [Header("Sprite List")]
    [SerializeField] private List<Sprite> logos;
    [SerializeField] private List<Sprite> flags;
    [SerializeField] private List<Sprite> profiles;
    #endregion

    #region Getters
    public List<Sprite> Logos => logos;
    public List<Sprite> Flags => flags;
    public List<Sprite> Profiles => profiles;
    #endregion
}
