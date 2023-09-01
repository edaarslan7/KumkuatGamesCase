using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Team : SpawnableObject
{
    #region Fields
    [SerializeField] Image logo;
    [SerializeField] TextMeshProUGUI teamName;
    [SerializeField] TextMeshProUGUI star;
    [SerializeField] TextMeshProUGUI members;
    private List<Member> membersList = new List<Member>();
    private int currentCapacity, maxCapacity;
    private int totalStar = 0;
    #endregion

    #region Getter
    public Sprite Logo => logo.sprite;
    public string TeamName => teamName.text;
    public string Star => star.text;
    public int CurrentCapacity => currentCapacity;
    public int MaxCapacity => maxCapacity;
    public List<Member> MembersList => membersList;
    #endregion

    #region Executes
    public void AddMemberToTeam(Member member)
    {
        membersList.Add(member);
    }
    public void SetTeamInfos(Sprite logo, string teamName, int currCapacity, int maxCapacity)
    {
        this.logo.sprite = logo;
        this.teamName.text = teamName;
        currentCapacity = currCapacity;
        this.maxCapacity = maxCapacity;
        members.text = currentCapacity + "/" + maxCapacity;
        

    }
    public void SetStar()
    {
        foreach (Member member in membersList)
        {
            totalStar += member.Star;
        }
        star.text = totalStar.ToString();
    }
    #endregion
}
