using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField inputFirstName;
    public InputField inputFamilyName;
    public InputField inputEmail;
    public InputField inputPassword;
    public InputField inputConfirmPassword;

    private string url = "http://localhost/register.php";

    public void NewUser()
    {
        StartCoroutine(RegisterUser());
    }

    bool ValidateData()
    {
        bool valid = true;
        if(inputFirstName.text=="")
        {
            valid = false;
        }
        if(inputFamilyName.text == "")
        {
            valid = false;
        }
        if(inputEmail.text == "")
        {
            valid = false;
        }
        if(inputPassword.text == "")
        {
            valid = false;
        }
        if (inputConfirmPassword.text == "" || inputConfirmPassword.text!=inputPassword.text)
        {
            valid = false;
        }
        return valid;
    }

    IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        if(ValidateData())
        {
            form.AddField("firstName", inputFirstName.text);
            form.AddField("familyName", inputFamilyName.text);
            form.AddField("email", inputEmail.text);
            form.AddField("password", inputPassword.text);
            WWW www = new WWW(url, form);
            yield return www;
        }
        else
        {
            Debug.Log("Nope");
        }
        
    }

}
