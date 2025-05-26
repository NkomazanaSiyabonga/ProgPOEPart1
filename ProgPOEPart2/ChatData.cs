using System.Collections.Generic;

namespace ProgPOEPart1
{
    internal static class ChatData
    {
        public static Dictionary<string, string> TopicAliases = new Dictionary<string, string>
        {
            { "viruses", "types of viruses" },
            { "virus", "types of viruses" },
            { "password", "password" },
            { "passwords", "password" },
            { "phishing", "phishing" },
            { "privacy", "online privacy" },
            { "footprint", "digital footprint" },
            { "cyber bullying", "cyber bullying" },
            { "skills", "skills needed for cyber security careers" },
            { "incident response", "hacked" },
            { "hacked", "hacked" },
            { "cybersecurity tips", "general cybersecurity tips" }
        };

        public static Dictionary<string, List<string>> TopicResponses = new Dictionary<string, List<string>>
        {
            { "phishing", new List<string>
                {
                    "Be cautious of emails asking for personal information.",
                    "Always verify links before clicking.",
                    "Watch out for spelling errors or urgent language."
                }
            },
            { "password", new List<string>
                {
                    "Use a strong password with a mix of characters.",
                    "Avoid using the same password across sites.",
                    "Do not include personal info in passwords."
                }
            },
            { "online privacy", new List<string>
                {
                    "Review app permissions and avoid oversharing.",
                    "Use privacy-focused browsers and search engines.",
                    "Enable privacy settings on social media."
                }
            },
            { "digital footprint", new List<string>
                {
                    "Be mindful of what you post online.",
                    "Limit personal information shared publicly.",
                    "Review and clean your online presence regularly."
                }
            },
            { "cyber bullying", new List<string>
                {
                    "Report abuse and block the bully.",
                    "Don't respond, save evidence, and report.",
                    "Be kind online. Think before posting."
                }
            },
            { "skills needed for cyber security careers", new List<string>
                {
                    "Learn networking, ethical hacking, and coding.",
                    "Certifications like CEH and CISSP help.",
                    "Stay updated on cybersecurity trends."
                }
            },
            { "types of viruses", new List<string>
                {
                    "Examples: file infectors, macros, trojans.",
                    "Worms spread without user interaction.",
                    "Ransomware locks data and demands payment."
                }
            },
            { "hacked", new List<string>
                {
                    "Disconnect from the internet and inform IT.",
                    "Change your passwords and run antivirus.",
                    "Keep logs of what happened and actions taken."
                }
            },
            { "general cybersecurity tips", new List<string>
                {
                    "* Use multi-factor authentication.",
                    "* Keep software updated.",
                    "* Avoid public Wi-Fi without VPN.",
                    "* Be cautious of email attachments.",
                    "* Back up your data regularly."
                }
            }
        };
    }
}
