using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScreen : GameScreen
{
    #region Fields
    [SerializeField] GameObject teamScreen;
    [SerializeField] GameObject matchScreen;
    [SerializeField] GameObject attackScreen;
    #endregion

    #region Executes
    public void SetTeamMatchScreen(bool isTeamSelected)
    {
        dismissAll();
        teamScreen.SetActive(!isTeamSelected);
        matchScreen.SetActive(isTeamSelected);

    }
    public void SetMatchAttackScreen(bool isMatchSelected)
    {
        dismissAll();
        matchScreen.SetActive(!isMatchSelected);
        attackScreen.SetActive(isMatchSelected);
    }
    private void dismissAll()
    {
        teamScreen.SetActive(false);
        matchScreen.SetActive(false);
        attackScreen.SetActive(false);
    }
    #endregion
}
