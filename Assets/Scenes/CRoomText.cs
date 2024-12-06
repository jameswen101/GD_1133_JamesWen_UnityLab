using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CRoomText : MonoBehaviour
{
    
    private TMP_Text Message;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyApproaching()
    {
        Message.text = "ENEMY APPROACHING";
        Message.color = Color.red;
        //Message.text.SetActive(true);
    }
}
