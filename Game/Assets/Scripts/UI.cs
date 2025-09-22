using UnityEngine;

public class UI : MonoBehaviour
{
    
    [SerializeField] Pingu pingu;

    public void switchSkin (int ID)
    {
        pingu.changeSkin(ID);
    }
}
