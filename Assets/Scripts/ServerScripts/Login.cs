using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField inputEmail;
    public InputField inputPassword;
    public Text emailError;
    public Text passwordError;

    private string url = "http://localhost/login.php";
    private string message;


    private void Start()
    {
        if (PlayerPrefs.HasKey("userEmail"))
        {
            SceneManager.LoadSceneAsync("MapScene");
        }
    }

    public void SignIn()
    {
        StartCoroutine(LogIn());
    }

    void ResetErrorText()
    {
        emailError.gameObject.SetActive(false);
        passwordError.gameObject.SetActive(false);
    }

    bool ValidateData()
    {
        bool valid = true;
        ResetErrorText();

        if (inputEmail.text == "")
        {
            valid = false;
            emailError.gameObject.SetActive(true);
        }
        else if (!inputEmail.text.Contains("@") || !inputEmail.text.Contains("."))
        {
            emailError.text = "Невалиден имейл адрес!";
            emailError.gameObject.SetActive(true);
        }

        if (inputPassword.text == "")
        {
            valid = false;
            passwordError.gameObject.SetActive(true);
        }

        return valid;
    }

    IEnumerator LogIn()
    {
        if (ValidateData())
        {
            WWWForm form = new WWWForm();
            form.AddField("email", inputEmail.text);
            form.AddField("password", inputPassword.text);
            WWW www = new WWW(url, form);
            yield return www;
            message = www.text;
            Debug.Log(message);

            if (message == "Нерегистриран имейл адрес!")
            {
                emailError.text = message;
                emailError.gameObject.SetActive(true);
            }
            else if (message == "Грешна парола!")
            {
                passwordError.text = message;
                passwordError.gameObject.SetActive(true);
            }
            else if (message == "Добре дошли!")
            {
                PlayerPrefs.SetString("userEmail", inputEmail.text);
                PlayerPrefs.Save();
                SceneManager.LoadSceneAsync("MapScene");
            }
        }
    }

    public void GoToRegisterScene()
    {
        SceneManager.LoadSceneAsync("RegisterScene");
    }
}
