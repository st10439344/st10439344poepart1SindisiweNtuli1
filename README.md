# Didiza Cyber Guardian 🔒🤖

![Didiza Banner](https://i.imgur.com/JkQq3Zy.png)

An intelligent cybersecurity chatbot that educates users about online safety and digital security best practices.

[![.NET Version](https://img.shields.io/badge/.NET-6.0-blue)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)](https://github.com/yourusername/didiza-cyber-guardian/pulls)

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Knowledge Base](#knowledge-base)
- [Database Setup](#database-setup)
- [Contributing](#contributing)
- [License](#license)

## Features ✨

- **Interactive Cybersecurity Guidance** - Expert advice on 15+ security topics
- **Personalized Experience** - Remembers user interests across sessions
- **Sentiment Analysis** - Detects user emotions and responds empathetically
- **SQL Database** - Stores user preferences and interaction history
- **Voice Greeting** - Optional TTS welcome (Windows only)
- **Smart Matching** - Understands questions even with imperfect phrasing

## Installation ⚙️

### Prerequisites
- [.NET 6.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for persistent storage)

### Setup
```bash
# Clone the repository
git clone https://github.com/yourusername/didiza-cyber-guardian.git
cd didiza-cyber-guardian

# Configure database connection (optional)
# Update the connection string in CybersecurityChatbot.cs if needed
