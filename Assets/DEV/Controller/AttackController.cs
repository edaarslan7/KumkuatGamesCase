using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackController : Controller
{
    #region Fields
    GameplayData gameplayData;
    [SerializeField] ObjectPool attackPool;
    private List<Attack> attackList = new List<Attack>();
    private Attack playerAttack;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        gameplayData = data;
    }
    #endregion

    #region Executes
    public void CreateRandomMatches(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Attack attack = attackPool.GetItem() as Attack;

            attack.SetAttackInfo(selectRandomPlayerPhoto(), selectRandomPlayerPhoto(), selectRandomScore(), selectRandomScore());
            attack.SetActive();
            attackList.Add(attack);
        }
        SelectRandomAttackForPlayer();

    }
    private Sprite selectRandomPlayerPhoto()
    {
        int playerPhoto = Random.Range(0, gameplayData.Profiles.Count);
        Sprite selectedPhoto = gameplayData.Profiles[playerPhoto];
        return selectedPhoto;
    }
    private int selectRandomScore()
    {
        int score = Random.Range(0, 1000);
        return score;
    }
    public void ResetAttack()
    {
        foreach (Attack attack in attackList)
        {
            attack.Dismiss();
            attack.IsThisPlayerAttack(false);
        }
    }
    public void SelectRandomAttackForPlayer()
    {
        int randomIndex = Random.Range(0, attackList.Count);
        playerAttack = attackList[randomIndex];
        playerAttack.IsThisPlayerAttack(true);
    }
    #endregion
}
