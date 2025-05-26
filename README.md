# ProgPOEPart1

# Link for Repository
https://github.com/NkomazanaSiyabonga/ProgPOEPart1

Operating Manual for Chatbot Assistant
# Cybersecurity Awareness Bot

# Cybersecurity Awareness Chatbot

## 🛡️ Overview

This is a **Console-based C# Chatbot** that educates users about cybersecurity best practices in an interactive and engaging way. It responds to user input with advice on topics such as password safety, phishing scams, digital footprints, cyberbullying, and more.

The chatbot is designed to:
- Help users understand cybersecurity in a conversational tone.
- Use keyword detection to identify and respond to specific topics.
- Provide random tips from a curated list for each cybersecurity topic.
- Recognize simple sentiments like curiosity or fear and respond accordingly.
- Use ASCII art and audio to create a friendly and inviting user experience.

---

## 🧠 Features

- **User Greeting & Personalization**: Asks for the user's name and uses it throughout the chat.
- **Typewriter Text Animation**: Simulates typing for bot messages to enhance realism.
- **Audio Welcome Message**: Plays a `.wav` file to welcome the user (if available).
- **Topic Matching**: Matches user input to cybersecurity topics using aliases.
- **Sentiment Detection**: Adjusts responses based on emotional cues like “worried” or “curious”.
- **Randomized Tips**: Provides a random relevant tip from a list for each recognized topic.
- **Clean Console UI**: Uses color-coded text and section dividers to enhance readability.

---

## 💻 Technologies Used

- **Language**: C#
- **Framework**: .NET (Console Application)
- **Audio Playback**: `System.Media.SoundPlayer`
- **Text Effects**: `Thread.Sleep` for typewriter animation
- **Data Structures**: Dictionaries and Lists for topic aliases and responses

---

## 🔧 How It Works

1. **Startup**: The app displays ASCII art and plays a welcome sound.
2. **User Name**: The user is prompted to enter their name.
3. **Chat Loop**:
   - The bot asks how it can help.
   - User input is analyzed:
     - If it matches a known topic → the bot responds with a random tip.
     - If it contains emotional keywords → the bot acknowledges the sentiment.
     - If the input is unclear → fallback responses guide the user.
   - Loop continues until the user types "bye" or "exit".
4. **Goodbye**: The bot says farewell and exits.

---

## 🧪 Example Topics the Bot Can Handle

- Password Safety
- Phishing Scams
- Online Privacy
- Digital Footprint
- Cyber Bullying
- Skills for Cybersecurity Careers
- Types of Viruses
- What to do if you’ve been hacked
- General Cybersecurity Tips

---

## ▶️ How to Run the Project

1. **Clone or Download the Repo**
2. Open the `.csproj` file in Visual Studio or run it via command line.
3. Ensure the `Welcome.wav` file is placed at:


User commands for the ChatBot

Command	Description
hi, hello	      Show main menu options
password	      Get password safety tips
phishing	      Learn about phishing scams
browsing	      Safe internet browsing tips
cybersecurity	  General cybersecurity advice
thank you      	Get a polite response
no	            Return to main menu
bye, exit	      End the conversation

# References for code
Website: DeepSeek, DeepseekChat, 2025, https://chat.deepseek.com/a/chat/s/81cb1c9d-3bbe-4328-9747-c111435805c7
Website(Youtube), Bro Code, 2021, https://www.youtube.com/watch?v=wxznTygnRfQ
Website(Youtube), The Code City, 2024, https://www.youtube.com/watch?v=4dkNn93DIx4
