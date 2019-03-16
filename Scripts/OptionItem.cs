using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionItem : MonoBehaviour
{
    const float HOVERFACTOR = 1.2f;
    SoundsManager SoundsManager;
    private void Awake()
    {
        SoundsManager = GameObject.Find("SoundsManager").GetComponent<SoundsManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        SoundsManager.SendMessage("PlayHoverSound");
        gameObject.transform.localScale *= HOVERFACTOR;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale /= HOVERFACTOR;
    }

    private void OnMouseUp()
    {
        switch(gameObject.name)
        {
            case "PlayOption":
                SoundsManager.SendMessage("PlayClickSound");
                break;
            case "PrefsOption":
                SoundsManager.SendMessage("PlayClickSound");
                break;
            case "CreditsOption":
                SoundsManager.SendMessage("PlayClickSound");
                break;
            case "ExitOption":
                SoundsManager.SendMessage("PlayClickSound");
                Application.Quit();
                break;
        }
    }
}
