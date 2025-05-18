# MyML.NetApp

MyML.NetApp is a sample ML.NET application that demonstrates how to train, evaluate, and consume a machine learning model using .NET Core.

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
  - [Contributing](#contributing)
  - [License](#license)
  - [Contact](#contact)

## Overview
This project shows how to use ML.NET to build, train, evaluate, and consume a machine learning model. It uses a sample dataset (`wikipedia-detox-250-line-data.tsv`) for demonstration purposes.

## Project Structure
- `MyML.NetApp/` - Main application
- `MyML.NetAppML.ConsoleApp/` - Console app for model building
- `MyML.NetAppML.Model/` - Model input/output classes and model consumption logic
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
1. Run the console app to train and evaluate the model:
   ```sh
   dotnet run --project MyML.NetAppML.ConsoleApp
   ```
2. The trained model will be saved as `MLModel.zip` in the `MyML.NetAppML.Model` directory.

### Consume Model
1. Run the main application to consume the trained model:
   ```sh
   dotnet run --project MyML.NetApp
   ```

## Contributing
Contributions are welcome! Please open issues or submit pull requests for improvements.

## License
This project is licensed under the MIT License.

## Contact
For questions or feedback, please contact the project maintainer.
