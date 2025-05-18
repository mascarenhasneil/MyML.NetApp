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
  - [Usage](#usage)
    - [Train and Evaluate Model](#train-and-evaluate-model)
    - [Consume Model](#consume-model)
  - [Testing](#testing)
  - [Localization](#localization)
  - [Troubleshooting](#troubleshooting)
  - [Contributing](#contributing)
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

## Usage
### Train and Evaluate Model
1. (Optional) If you want to retrain the model, use the shared library's `ModelBuilder.CreateModel()` method in your own script or app.
2. The trained model is saved as `MLModel.zip` in the `MyML.NetAppML.Model` directory.

### Consume Model
1. Run the console app to make predictions using the trained model:
   ```sh
   dotnet run --project MyML.NetAppML.ConsoleApp
   ```
2. Or run the main application:
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

## Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements.

## License
This project is licensed under the MIT License.

## Contact
For questions or feedback, please contact the project maintainer.
