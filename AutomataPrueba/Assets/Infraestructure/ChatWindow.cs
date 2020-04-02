using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class eMessage
{
    public string text;
    public Text textObject;
}
public class ChatWindow : MonoBehaviour
{
    public int maxeMessages = 25;
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    List<eMessage> eMessageList = new List<eMessage>();
    Color[] colors = { Color.white,Color.yellow, Color.red, Color.blue };
    public enum eMessageTYPE
    {
        REGULAR,
        DANGER,
        ERROR,
        HELP
    }
    public void SendeMessageToChat(string text, eMessageTYPE type)
    {

        if(eMessageList.Count >= maxeMessages)
        {
            Destroy(eMessageList[0].textObject.gameObject);
            eMessageList.Remove(eMessageList[0]);
            
        }
        eMessage neweMessage = new eMessage();
        neweMessage.text = text;
    

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        neweMessage.textObject = newText.GetComponent<Text>();
        neweMessage.textObject.color = colors[(int)type];
        neweMessage.textObject.text = neweMessage.text;
        eMessageList.Add(neweMessage);

        
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (chatBox.text != "")
            {
            #if _CONSOLE
                GameManager.instance.console.DispatcheMessage(chatBox.text);
            #endif
                chatBox.text = "";
            }
        }
    }
}