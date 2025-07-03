## Google Translate Console App (Clean Architecture)

A simple console application that translates text using the Google Cloud Translation API.  
Built following Clean Architecture principles for better separation of concerns and testability.

### Features

- Translate text between languages using Google Cloud Translation API.
- Built with Clean Architecture for separation of concerns and scalability.
- Uses MediatR for CQRS and decoupled communication between layers.
- Console-based UI.

### How It Works

1. You run the console app.
2. You enter the source language, target language, and the text to translate.
3. The app calls the Google Cloud Translation API and displays the translated text.

### Architecture Overview

- **Application Layer**: Holds commands, queries, interfaces, and MediatR handlers.
- **API Layer**: Handles input and output; sends requests to MediatR (acts as a mediator client).
- **Infrastructure Layer**: Implements external services (e.g., Google Translate).
- **Presentation Layer**: Console interface for user interaction.

### Requirements

- .NET 8 or higher
- Google Cloud Project with Translation API enabled
- API key or service account credentials

## How to Run the Project Locally

### Getting Started

1. Clone the repository to your local machine.

```bash
git clone https://github.com/Mkrager/Google-Translate-Console-Application.git
```

2. Set up your development environment. Make sure you have the necessary tools and packages installed.

3. Configure the project settings and dependencies. You may need to create configuration files for sensitive information like API keys.

4. Install the required packages using your package manager of choice (e.g., npm, yarn, NuGet).

5. Run the application locally for development and testing.

```bash
dotnet run
```
