using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEvents : MonoBehaviour
{
    Text status;

    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();
         status = GameObject.Find("authStatus").GetComponent<Text>();
        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Button btn = GameObject.Find("SignInButton").GetComponent<Button>();
        btn.onClick.AddListener(signIn);

    }

    void signIn()
    {
        Social.localUser.Authenticate((bool success) =>
        {
            // handle success or failure
            if (success)
            {
                Debug.Log("succes");
                status.text = "succes";
            }
            else
            {
                Debug.Log("failure");
                status.text = "failed";
            }
        });
    }
}