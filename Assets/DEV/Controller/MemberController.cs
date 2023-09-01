using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MemberController : Controller
{
    #region Fields
    GameplayData gameplayData;
    [SerializeField] Member memberPrefab;
    [SerializeField] Transform memberParent;
    [SerializeField] ObjectPool memberPool;
    List<Member> members = new List<Member>();
    #endregion
    #region Core
    public override void Initialize(GameplayData data)
    {
        gameplayData = data;
    }
    #endregion
    #region Executes
    public void CreateMembers(Team team)
    {
        for (int i = 0; i < team.CurrentCapacity; i++)
        {
            int randomFlag = Random.Range(0, gameplayData.Flags.Count);
            int randomProfile = Random.Range(0, gameplayData.Profiles.Count);
            int randomHour = Random.Range(1, 25);
            Member member = memberPool.GetItem() as Member;
            member.ObjectCreated();
            team.AddMemberToTeam(member);
            member.SetMemberInfo(gameplayData.Profiles[randomProfile], gameplayData.Flags[randomFlag],
            gameplayData.Profiles[randomProfile].name, randomHour.ToString(), i);
            //member.SetActive();
            members.Add(member);
        }
    }
    public void ClearMembers()
    {
        foreach (Member member in members)
        {
            member.Dismiss();
        }
        members.Clear();
    }
    public void ShowMembers(Team team)
    {
        foreach (Member m in team.MembersList)
        {
            members.Add(m);
            m.SetActive();
        }
    }
    #endregion
}
