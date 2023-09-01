using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Attack : SpawnableObject
{
    #region Fields
    [SerializeField] Image player1Photo;
    [SerializeField] Image player2Photo;
    [SerializeField] TextMeshProUGUI player1Name;
    [SerializeField] TextMeshProUGUI player2Name;
    [SerializeField] TextMeshProUGUI player1Score;
    [SerializeField] TextMeshProUGUI player2Score;
    [SerializeField] GameObject attackButton;
    [SerializeField] GameObject vsImage;
    #endregion

    #region Executes
    public void SetAttackInfo(Sprite p1, Sprite p2, int p1Score, int p2Score)
    {
        player1Photo.sprite = p1;
        player2Photo.sprite = p2;
        player1Name.text = p1.name;
        player2Name.text = p2.name;
        player1Score.text = p1Score.ToString();
        player2Score.text = p2Score.ToString();
    }
    public void IsThisPlayerAttack(bool isThisPlayerMatch)
    {
        attackButton.SetActive(isThisPlayerMatch);
        vsImage.SetActive(!isThisPlayerMatch);
    }
    #endregion
}
