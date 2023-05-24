using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using TMPro;

namespace OpenAIAPIManagement
{
    [Serializable]
    public class OpenAIAPIRequest
    {
        public string model = "gpt-3.5-turbo";
        public Message[] messages;
        public float temperature = 0.5f;
        public int max_tokens = 50;
        public float top_p = 1f;
        public float presence_penalty = 0f;
        public float frequency_penalty = 0f;

        public OpenAIAPIRequest(string model_, Message[] messages_, float temperature_, int max_tokens_, float top_p_, float presence_penalty_, float frequency_penalty_)
        {
            this.model = model_;
            this.messages = messages_;
            this.temperature = temperature_;
            this.max_tokens = max_tokens_;
            this.top_p = top_p_;
            this.presence_penalty = presence_penalty_;
            this.frequency_penalty = frequency_penalty_;
        }
    }

    [Serializable]
    public class Message
    {
        public string role = "user";
        public string content = "What is your purpose?";

        public Message(string role_, string content_)
        {
            this.role = role_;
            this.content = content_;
        }
    }

    public class ChatGPTIntegration : MonoBehaviour
    {
        [SerializeField]
        private string _apiKey = "YOUR_API_KEY";

        [SerializeField]
        private string _apiURL = "API_ENDPOINT_URL";

        [SerializeField]
        private string _userInputText;

        [SerializeField]
        private List<string> _chatData = new List<string>();

        [SerializeField]
        private string _userPostfix = "[USER]";

        [SerializeField]
        private string _aiPostfix = "[AI]";

        public ChatGPTUI chatUI;




        public async Task<Message> SendMessageToChatGPT(Message[] message, float temperature, int max_tokens, float top_p, float presence_penalty, float frequency_penalty)
        {
            OpenAIAPIRequest requestObject = new OpenAIAPIRequest("gpt-4", message, temperature, max_tokens, top_p, presence_penalty, frequency_penalty);
            string requestJson = JsonUtility.ToJson(requestObject);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            HttpResponseMessage response = await client.PostAsync(_apiURL, new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                OpenAIAPIRequest responseObj = JsonUtility.FromJson<OpenAIAPIRequest>(responseJson);
                Message responseMessage = responseObj.messages[0];
                Debug.Log("ChatGPT: " + responseMessage.content);
                return responseMessage;
            }
            else
            {
                Debug.LogError("Error: " + response.StatusCode);
                return new Message("Error", "Status" + response.StatusCode);
            }
        }


        public async void ProcessMessageFromInputField(string userMessage, Action<Message> callback)
        {
            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                _chatData.Clear();
                _chatData.Add(userMessage + _userPostfix);
                callback.Invoke(new Message("user", userMessage));
                Message userMessageObj = new Message("user", userMessage);
                Message chatAgentResponse = await SendMessageToChatGPT(new Message[] { userMessageObj }, 0.7f, 256, 1f, 0f, 0f);
                callback.Invoke(chatAgentResponse);
            }
        }
    }
}
