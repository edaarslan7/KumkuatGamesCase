using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeamController : Controller
{
    #region Fields
    [Header("Selected Team Fields")]
    [SerializeField] Image selectedTeamLogo;
    [SerializeField] TextMeshProUGUI selectedTeamName;
    [SerializeField] TextMeshProUGUI selectedTeamStar;
    [SerializeField] TextMeshProUGUI selectedTeamMembers;

    [SerializeField] Team teamPrefab;
    [SerializeField] ObjectPool teamPool;
    [SerializeField] GameObject teamSelectionUI;
    [SerializeField] GameObject selectedTeamUI;
    [SerializeField] Transform teamParent;
    [SerializeField] MemberController memberController;
    private List<Team> teams = new List<Team>();
    GameplayData gameplayData;
    #endregion

    #region Core
    public override void Initialize(GameplayData data)
    {
        gameplayData = data;
    }

    #endregion

    #region Executes
    public void CreateRandomTeams(int count)
    {
        SetUIScreens(false);
        for (int i = 0; i < count; i++)
        {
            int randomLogo = Random.Range(0, gameplayData.Logos.Count);
            int randomMaxCapacity = Random.Range(0, 30);
            int randomCurrentCapacity = Random.Range(0, randomMaxCapacity - 1);
            Sprite selectedLogo = gameplayData.Logos[randomLogo];
            Team team = teamPool.GetItem() as Team;
            team.SetTeamInfos(selectedLogo, selectedLogo.name, randomCurrentCapacity, randomMaxCapacity);
            team.SetActive();
            teams.Add(team);
            team.GetComponent<Button>().onClick.AddListener(() => isSelected(team));
        }
    }
    private void isSelected(Team team)
    {
        foreach (Team t in teams)
        {
            if (t == team)
            {
                SetUIScreens(true);
                selectedTeamLogo.sprite = team.Logo;
                selectedTeamName.text = team.TeamName;
                selectedTeamStar.text = team.Star;
                selectedTeamMembers.text = team.CurrentCapacity + "/" + team.MaxCapacity;
                memberController.CreateMembers(team);
            }
        }
    }
    public void SetUIScreens(bool isTeamSelected)
    {
        teamSelectionUI.SetActive(!isTeamSelected);
        selectedTeamUI.SetActive(isTeamSelected);
    }

    public void SetPlayerTeam()
    {
        PlayerDataModel.Data.PlayerTeam = selectedTeamName.text;
        PlayerDataModel.Data.Save();
    }
    #endregion
}
