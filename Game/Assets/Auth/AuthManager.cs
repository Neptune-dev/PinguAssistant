using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    [SerializeField] WebConfig webConfig;

    [SerializeField] InputField username;
    [SerializeField] InputField password;


    public void LogIn ()
    {
        StartCoroutine(LoginCoroutine());
    }

    public void NewPlayer ()
    {
        StartCoroutine(SinginCoroutine());
    }

    private IEnumerator LoginCoroutine ()
    {
        
        string uri = webConfig.webServerAddress + "?req=login";

        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("pwd", password.text);


        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
        }
    }

    private IEnumerator SinginCoroutine ()
    {
        
        string uri = webConfig.webServerAddress + "?req=signin";

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
