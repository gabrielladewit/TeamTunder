using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{

    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);

       PlayGamesPlatform.DebugLogEnabled = true;

       PlayGamesPlatform.Activate();

        signIn();

    }

    void signIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
            if (success)
            {
                Debug.Log("succes");
                UnlockAchievement("CgkIxPu6y84TEAIQBA");
                ShowAchievement.showAchievement("Welcome");
            }
            else
            {
                Debug.Log("failure");
            }
        });
    }

    public void showSpecificLeaderboard(string leaderboardId)
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardId);
    }

    #region Achievements
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { });
    }

    public void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
}