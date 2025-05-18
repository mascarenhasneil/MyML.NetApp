# MyML.NetApp

MyML.NetApp is a sample ML.NET application that demonstrates how to train, evaluate, and consume a machine learning model using .NET 9.0.

## Table of Contents
- [MyML.NetApp](#mymlnetapp)
  - [Table of Contents](#table-of-contents)
  - [Overview](#overview)
  - [Project Structure](#project-structure)
  - [Setup](#setup)
    - [Prerequisites](#prerequisites)
    - [Build](#build)
    - [First Run](#first-run)
  - [Usage](#usage)
    - [Train and Evaluate Model](#train-and-evaluate-model)
    - [Consume Model](#consume-model)
  - [Testing](#testing)
  - [Localization](#localization)
  - [Troubleshooting](#troubleshooting)
  - [Changelog](#changelog)
  - [Contributing](#contributing)
    - [Submitting Issues](#submitting-issues)
    - [Code Style](#code-style)
  - [License](#license)
  - [Contact](#contact)

## Overview
This project shows how to use ML.NET to build, train, evaluate, and consume a machine learning model. It uses a sample dataset (`wikipedia-detox-250-line-data.tsv`) for demonstration purposes. All model-building and utility logic is centralized in a shared library for maintainability and testability.

## Project Structure
- `MyML.NetApp/` - Main application for consuming the trained model
- `MyML.NetAppML.ConsoleApp/` - Console app for making predictions using the trained model
- `MyML.NetAppML.Model/` - Model input/output classes and model consumption logic
- `MyML.NetAppML.Lib/` - Shared library containing all model-building, training, and utility logic
- `MyML.NetAppML.Tests/` - xUnit test project for all core logic
- `Data/` - Sample data files

## Setup
### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio or VS Code

### Build
```sh
dotnet build MyML.NetApp.sln
```

### First Run
1. Clone this repository:
   ```sh
   git clone https://github.com/yourusername/MyML.NetApp.git
   cd MyML.NetApp
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the solution:
   ```sh
   dotnet build MyML.NetApp.sln
   ```
4. (Optional) Train a new model by calling `ModelBuilder.CreateModel()` from your own script or app.
5. Ensure `MLModel.zip` exists in `MyML.NetAppML.Model` (retrain if needed).

## Usage
### Train and Evaluate Model
- See the shared library's `ModelBuilder.CreateModel()` for training logic.
- The trained model is saved as `MLModel.zip` in the `MyML.NetAppML.Model` directory.

### Consume Model
- Run the console app to make predictions using the trained model:
  ```sh
  dotnet run --project MyML.NetAppML.ConsoleApp
  ```
- Or run the main application:
  ```sh
  dotnet run --project MyML.NetApp
  ```

## Testing
Run all unit tests with:
```sh
dotnet test MyML.NetAppML.Tests/MyML.NetAppML.Tests.csproj
```
All core logic is covered by xUnit tests, including model input/output, prediction, and utility methods.

## Localization
All user-facing strings are managed via `.resx` resource files for easy localization and code quality compliance.

## Troubleshooting
- **Model file not found:** Ensure `MLModel.zip` exists in the `MyML.NetAppML.Model` directory. Retrain if needed.
- **ML.NET version issues:** All projects target .NET 9.0 and use ML.NET 1.5.0. Ensure your environment matches.
- **Test failures or hangs:** Ensure your test data includes at least two distinct class labels for multiclass classification.

## Changelog
See [CHANGELOG.md](CHANGELOG.md) for a detailed list of changes and release history.

## Contributing
We welcome contributions from the community! To get started:
1. **Fork** this repository and clone your fork locally.
2. **Create a new branch** for your feature or bugfix:
   ```sh
   git checkout -b my-feature-branch
   ```
3. **Make your changes** and add tests as appropriate.
4. **Run the test suite** to ensure nothing is broken:
   ```sh
   dotnet test MyML.NetAppML.Tests/MyML.NetAppML.Tests.csproj
   ```
5. **Commit and push** your changes to your fork.
6. **Open a Pull Request (PR)** against the `master` branch with a clear description of your changes.

### Submitting Issues
- If you find a bug or have a feature request, please [open an issue](https://github.com/yourusername/MyML.NetApp/issues) with as much detail as possible.
- Include steps to reproduce, expected behavior, and screenshots/logs if relevant.

### Code Style
- Follow the existing code style and conventions enforced by `.editorconfig` and analyzers.
- Write clear, concise commit messages and PR descriptions.

## License
This project is licensed under the MIT License.

## Contact
For questions or feedback, please contact the project maintainer:
- [Neil Mascarenhas](https://github.com/mascarenhasneil)
