using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    [SerializeField] string userApiUrl;

    [SerializeField] InputField username;
    [SerializeField] InputField password;


    public void LogIn ()
    {
        StartCoroutine(GetUser());
    }

    public void NewPlayer ()
    {
        StartCoroutine(PostUser());
    }

    private IEnumerator GetUser ()
    {
        
        string uri = userApiUrl + "?username=" + username.text + "&pwd=" + password.text;

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
        }
    }

    private IEnumerator PostUser ()
    {
        
        string uri = userApiUrl;

        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("pwd", password.text);


        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
        }
    }
}
