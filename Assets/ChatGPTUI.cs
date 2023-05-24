using UnityEngine;
using UnityEngine.UI;
using OpenAIAPIManagement;
using System.Threading.Tasks;
using TMPro;

public class ChatGPTUI : MonoBehaviour
{
    public GameObject userInputField;
    public Button sendButton;
    public TextMeshProUGUI chatDisplayText;

    public ChatGPTIntegration chatGPTIntegration;

    private void Start()
    {
        chatGPTIntegration = GetComponent<ChatGPTIntegration>();

        sendButton.onClick.AddListener(SendMessage);
    }

    private void SendMessage()
    {
        string userMessage = userInputField.GetComponent<TMP_InputField>().text;
        if (!string.IsNullOrWhiteSpace(userMessage))
        {
            userInputField.GetComponent<TMP_InputField>().text = string.Empty;
            chatGPTIntegration.ProcessMessageFromInputField(userMessage, DisplayChatResponse);
        }
    }

    public void DisplayChatResponse(Message chatResponse)
    {
        chatDisplayText.text = chatResponse.content;

    }
}
