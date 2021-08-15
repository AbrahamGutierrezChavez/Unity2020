using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetInputOnClick : MonoBehaviour
{
    public Button buttonClick;

    public InputField name;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        buttonClick.onClick.AddListener(GetInputOnClickHandler);
    }

    // Update is called once per frame
    public void GetInputOnClickHandler()
    {
        Debug.Log("log input ok" + name.text);
    }
}
