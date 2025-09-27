using UnityEngine;
using UnityEngine.Events;

public class Btn : MonoBehaviour
{
    [SerializeField] UnityEvent onTrigger;

    void Call()
    {
        onTrigger.Invoke();
    }
}
