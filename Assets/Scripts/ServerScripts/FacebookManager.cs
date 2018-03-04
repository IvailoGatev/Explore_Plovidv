using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;

public class FacebookManager : MonoBehaviour
{
    public GameObject user;
    AccessToken token;
    Text idtext;

    private void Start()
    {
        idtext = user.GetComponent<Text>();
        if (!FB.IsInitialized)
        {
            FB.Init();
        }
        else {
            FB.ActivateApp();
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }

    public void Login()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            FB.LogInWithReadPermissions(callback: OnLogIn);
        }
        else
        {
            //StartCoroutine(NoInternet());
        }
    }
    /*IEnumerator NoInternet()
    {
        obj3.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        obj3.SetActive(false);
    }*/
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            token = AccessToken.CurrentAccessToken;
        }
        else
        {
            Debug.Log("Inable to log");
        }
        DealWithFBMenus(FB.IsLoggedIn);
    }
    void DealWithFBMenus(bool isLoggedIn)
    {
        if(isLoggedIn==true)
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);

    }

    void DisplayUsername(IResult result)
    {

        Text UserName = user.GetComponent<Text>();

        if (result.Error == null)
        {

            UserName.text = "Здравей," + result.ResultDictionary["first_name"];

        }
        else {
            UserName.text=result.Error;
            Debug.Log(result.Error);
        }
    }
    public void Share()
    {
        FB.ShareLink(contentTitle: "Google Page message",
            contentURL: new System.Uri("https://www.google.bg/"),
            contentDescription: "Link to Google",
            callback: OnShare);
    }

    private void OnShare(IShareResult result)
    {
        if (result.Cancelled|| string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Share link error");
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            Debug.Log(result.PostId);
        }
        else
        {
            Debug.Log("Share succeed");
        }
    }

    public void Loggingout()
    {
        FB.LogOut();
        idtext.text = "Вход";
    }
}

