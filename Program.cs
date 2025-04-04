using System;//provides the foundation of the .NET framework, including the Console class
using System.Collections.Generic;//provides classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections
using System.Diagnostics;//provides classes that allow you to interact with system processes, event logs, and performance counters
using System.IO; //provides file handling capabilities like reading/writing files
using System.Media; //enables sound play 
using System.Runtime.InteropServices;//provides functionality to access unmanaged COM objects

namespace DidizaCyberSecurity
{

    public class CybersecurityChatbot
    {

        private const string APP_NAME = "Didiza Cyber Guardian";
        private const string VERSION = "1.1.0";

        private static readonly Dictionary<string, string> CyberTopics = new Dictionary<string, string>
{
    {"password",  "Use at least 12 characters with letters, numbers, and symbols. Avoid using names, birthdays, or common words like 'password123'. Enable password managers to generate and store strong passwords securely. Example: 'D1d1z@2024!CyberH3ro'."},

    {"phishing", "Phishing is when scammers trick you into revealing personal information via fake emails or messages. Always verify links before clicking and check for spelling errors in email domains. Example: A fake bank email asking for your login details, such as 'yourbank-security.com' instead of 'yourbank.com'."},

    {"safe browsing", "Avoid clicking unknown links and ensure the site uses HTTPS for secure connections. Install browser security extensions to detect malicious websites. Example: Instead of 'http://example.com', use 'https://example.com' to encrypt your data."},

    {"2fa", "Two-Factor Authentication (2FA) adds a second step to logins, such as an SMS code or authentication app. This prevents hackers from accessing your account even if they steal your password. Example: When logging into Gmail, you receive a verification code on your phone that you must enter to gain access."},

    {"ransomware", "Ransomware is malware that locks your files and demands payment for their release. Never pay the ransom; instead, restore files from a secure backup. Example: The WannaCry attack encrypted hospitals' data, demanding payment in Bitcoin, disrupting medical operations worldwide."},

    {"vpn", "A VPN encrypts your internet traffic, hiding your browsing activity from hackers and ISPs. Use a reputable paid VPN service rather than free ones, which may log your data. Example: Using a VPN while connected to public Wi-Fi prevents attackers from stealing your banking credentials."},

    {"public wi-fi", "Public Wi-Fi is risky as hackers can intercept data and launch man-in-the-middle attacks. Avoid logging into banking or personal accounts while connected to unsecured networks. Tip: Use a VPN to add an extra layer of encryption to your connection."},

    {"social engineering", "Hackers manipulate people into revealing sensitive information through deception. Be cautious of unsolicited phone calls, messages, or emails requesting login credentials. Example: A scammer posing as IT support calls you and asks for your password to 'fix' a non-existent issue."},

    {"data backups", "Regularly back up important files to prevent data loss from cyberattacks or system failures. Store backups on an external hard drive or a secure cloud service with encryption. Example: Using Google Drive or OneDrive ensures you can recover your files if your device is compromised."},

    {"software updates", "Keeping software updated patches security vulnerabilities that hackers exploit. Enable automatic updates for your operating system, browser, and antivirus software. Example: Updating Windows ensures you get the latest security fixes against known exploits like zero-day attacks."},

    {"privacy settings", "Adjust social media settings to limit who can see your personal information. Disable location tracking and restrict data sharing with third-party apps. Example: Make your Facebook profile private so only friends can view your posts and personal details."},

    {"mobile security", "Only install apps from official stores like Google Play and Apple App Store. Regularly check app permissions to ensure they aren’t accessing unnecessary data. Example: A flashlight app shouldn’t need access to your contacts or messages."},

    {"email security", "Verify sender details before clicking links or downloading attachments in emails. Look for spoofed email addresses that mimic trusted companies but have slight variations. Example: An email from 'support@yourbank.com' is legitimate, but 'bankhelp@gmail.com' is likely a scam."},

    {"iot security", "Change default passwords on smart devices like cameras, routers, and doorbells to prevent hacking. Regularly update firmware to patch security flaws and disable unnecessary remote access. Example: Setting a strong password on your Wi-Fi camera prevents attackers from spying on you remotely."}
};


        private static void SpeakWelcomeMessage()
        {
            try
            {

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    SpeakOnWindows("Welcome to Didiza Chatbot. I am your online guardian, I am here to help you with everything cybersecurity.");
                }
                else
                {

                    Console.WriteLine("Welcome to Didiza Chatbot. I am your online guardian, I am here to help you with everything cybersecurity.");
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage("Could not generate voice greeting", ex);
            }
        }

        private static void SpeakOnWindows(string message)
        {
            try
            {

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-Command \"Add-Type -AssemblyName System.speech; $speak = New-Object System.Speech.Synthesis.SpeechSynthesizer; $speak.Speak('{message}')\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Speech synthesis failed: {ex.Message}");
            }
        }

        public static void Main()
        {
            Console.Title = $"{APP_NAME} - Digital Safety Assistant";

            SpeakWelcomeMessage();

            // Visual welcome
            DisplayWelcomeBanner();

            // Gets user name
            string userName = PromptForName();

            // Main interaction loop
            RunChatbotInteraction(userName);
        }

        private static void DisplayWelcomeBanner()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
        ██████╗██╗   ██╗██████╗ ███████╗██████╗ ███████╗███████╗ ██████╗
        ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗██╔════╝██╔════╝██╔════╝
        ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝███████╗█████╗  ██║    
        ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗╚════██║██╔══╝  ██║    
        ╚██████╗   ██║   ██████╔╝███████╗██║  ██║███████║███████╗╚██████╗
         ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝
        ");
            Console.ResetColor();
        }

        private static string PromptForName()
        {
            string userName;
            do
            {
                Console.Write("\nEnter your name: ");
                userName = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(userName))
                {
                    break;
                }

                DisplayErrorMessage("Name cannot be empty", null);
            } while (true);

            Console.Clear();
            DisplayPersonalizedWelcome(userName);
            return userName;
        }

        private static void DisplayPersonalizedWelcome(string userName)
        {
            Console.WriteLine("\n==============================================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Welcome, {userName}! I'm here to help you stay safe online.");
            Console.ResetColor();
            Console.WriteLine("=============================================================\n");

            DisplayAvailableTopics();
        }

        private static void DisplayAvailableTopics()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nAvailable Topics:");
            foreach (var topic in CyberTopics.Keys)
            {
                Console.WriteLine($"- {char.ToUpper(topic[0]) + topic.Substring(1)} Security");
            }
            Console.WriteLine("\nType 'topics' anytime to see this list again");
            Console.ResetColor();
        }

        private static void RunChatbotInteraction(string userName)
        {
            while (true)
            {
                Console.Write("\nAsk me a question about cybersecurity (or type 'exit' to quit): ");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput)) continue;

                if (userInput == "exit")
                {
                    DisplayExitMessage(userName);
                    break;
                }

                if (userInput == "topics")
                {
                    DisplayAvailableTopics();
                    continue;
                }

                RespondToUserQuery(userInput);
            }
        }

        private static void RespondToUserQuery(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Finding the most relevant topic
            bool topicFound = false;
            foreach (var topic in CyberTopics)
            {
                if (input.Contains(topic.Key))
                {
                    Console.WriteLine(topic.Value);
                    topicFound = true;
                    break;
                }
            }

            // If no specific topic found, perform web search
            if (!topicFound)
            {
                Console.WriteLine("I don't have specific information on that topic yet. Let me search the web for you!");
                SearchWebResource(input);
            }

            Console.ResetColor();
        }

        private static void SearchWebResource(string query)
        {
            try
            {
                string searchQuery = Uri.EscapeDataString($"cybersecurity {query}");
                string url = $"https://www.google.com/search?q={searchQuery}";
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                DisplayErrorMessage("Error opening web search", ex);
            }
        }

        private static void DisplayExitMessage(string userName)
        {
            Console.WriteLine($"\nGoodbye, {userName}! Stay safe online.\n");
            Console.ResetColor();
        }

        private static void DisplayErrorMessage(string message, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            if (ex != null)
            {
                Console.WriteLine($"Details: {ex.Message}");
            }
            Console.ResetColor();
        }
    }
}