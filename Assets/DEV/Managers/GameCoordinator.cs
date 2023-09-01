using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameplayData gameData;
    [SerializeField] private List<Controller> controllers;
    #endregion

    #region Core
    public void Initialize()
    {
        controllers.ForEach(x => x.Initialize(gameData));
    }
    public void StartGame()
    {
        TeamController teamController = controllers[0] as TeamController;
        if(PlayerDataModel.Data.PlayerTeam == "")
        {
            UIManager.Instance.UpdateTeamMatchScreen(false);
            teamController.CreateRandomTeams(CONSTANTS.TEAM_COUNT);
        }
        else
        {
            UIManager.Instance.UpdateTeamMatchScreen(true);
            CreateMatches();
        }
    }
    #endregion

    #region Executes
    public void CreateMatches()
    {
        MatchController matchController = controllers[1] as MatchController;
        matchController.CreateRandomMatch(CONSTANTS.MATCH_COUNT);
    }
    #endregion
}
