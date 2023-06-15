# ChatGPT-Integration
Exploring the integration of ChatGPT in Unity using the OpenAI API
# ChatGPT Unity Integration

This repository contains a Unity project that demonstrates the integration of OpenAI's ChatGPT model with Unity using C# scripts. The project allows users to interact with the ChatGPT model through a Unity canvas and receive responses in real-time.

## Prerequisites

- Unity 3D (Version X.X.X)
- OpenAI API Key (Get it from [OpenAI](https://openai.com/))

## Getting Started

1. Clone the repository to your local machine.
2. Open the Unity project using Unity 3D.
3. In the Unity editor, navigate to the `ChatGPTManager` game object in the Hierarchy panel.
4. Assign your OpenAI API Key to the `ChatGPTIntegration` script component.
5. Run the Unity project.

## Usage

!! AFTER RUNNING, BUT BEFORE ENTERING MESSAGE, MAKE SURE YOU DRAG AND DROP THE CHATGPTMANAGER GAME OBJECT INTO THE CHATGPTUIMANAGER GAME OBJECT FIELD CALLED "CHAT GPT INTEGRATION"!!

- Enter your message in the input field on the canvas.
- Press the button to send the message to the ChatGPT model.
- The response from the model will be displayed in the chat display area.

## Customization

- You can customize the behavior of the ChatGPT model by modifying the parameters in the `SendMessageToChatGPT` method of the `ChatGPTIntegration` script.
- You can also customize the UI elements and styles by modifying the Unity canvas and associated components.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
