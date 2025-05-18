# Changelog

All notable changes to this project will be documented in this file.

## [V2] - 2025-05-18
### Added
- Created a shared library project (`MyML.NetAppML.Lib`) for all model-building, training, and utility logic.
- Added comprehensive xUnit test coverage for all core logic, including model input/output, prediction, and utility methods.
- Added exception handling to `ModelBuilder.Predict` for missing model file scenarios.
- Added a test to verify `Predict` throws `FileNotFoundException` if the model file is missing.
- Improved and expanded the `README.md` with project structure, usage, testing, and troubleshooting sections.
- Added localization support for user-facing strings using `.resx` resource files.
- Added code style and analyzer enforcement via `.editorconfig` and `Directory.Build.props`.

### Changed
- Upgraded all projects to .NET 9.0 and updated NuGet package references.
- Refactored model-building logic out of the ConsoleApp into the shared library for better maintainability and testability.
- Updated all test data to ensure multiclass classification tests do not hang (at least two class labels provided).
- Improved error handling and code quality throughout the codebase (null checks, sealed classes, resource centralization).
- Updated test project to use xunit 2.6.0 and fixed warnings related to string comparison in assertions.
- Updated `ModelBuilder.CreateModel` to use the same pipeline as `BuildTrainingPipeline` for consistency.
- Removed obsolete files (e.g., `Class1.cs` in the shared library, old `ModelBuilder.cs` in ConsoleApp).

### Fixed
- Fixed test errors due to namespace mismatches and missing named namespaces.
- Fixed test reliability by ensuring `MLModel.zip` is copied to the test output directory.
- Fixed schema mismatch and infinite loop issues in ML.NET tests by providing valid test data.

## [V1] - Initial Release
- Initial ML.NET solution with:
  - Console app for model prediction
  - Model input/output and consumption logic
  - Sample data and basic project structure
  - Basic README and .NET Core 3.1 support
