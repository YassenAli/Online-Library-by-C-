# Online Library by C#

## Overview

This project, **Online Library**, was developed as part of our database course at the faculty. The project is designed and implemented using C# with a user-friendly GUI.


## Project Details

### LoginRegistrationForm

This folder contains the main application with various forms and a database:

- **LoginRegistrationForm.sln**: Solution file for the project.
- **Form1.cs**: Login form.
- **MainForm.cs**: Main form after user login.
- **SignupForm.cs**: Form for user registration.
- **ModifyForm.cs**: Form to modify user details.
- **ShowDataForm.cs**: Form to display data.
- **UpdateUserDetailsForm.cs**: Form to update user details.
- **UserMainForm.cs**: Main form for the user.
- **onlineLibrary.mdf**: Database file.

### Other Files

- **ConceptualModel.pdf**: Conceptual data model of the project.
- **PhysicalModel.pdf**: Physical data model of the project.
- **Team Members.docx**: Document containing the team members' information.
- **crebas.sql**: SQL script to create the database.
- **report.pdf**: Detailed report of the project.

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository:
   ```bash
   git clone https://github.com/YassenAli/Online-Library-by-C-sharp.git
   ```
2. Open the LoginRegistrationForm/LoginRegistrationForm.sln file in Visual Studio.

3. Restore NuGet packages and build the solution:
  - In Visual Studio, go to Tools > NuGet Package Manager > Package Manager Console.
  - Run the command:
      ```powershell
      Update-Package -reinstall
      ```

4. Set the startup project:
  - Right-click on the solution in Solution Explorer.
  - Select `Set Startup Projects...`.
  - Choose Multiple startup projects and set LoginRegistrationForm as the startup project.

5. Run the application by pressing `F5` or clicking the `Start` button.

## Team Members

- You will find their names in `Team Members.docx` file

## Acknowledgements

- Our faculty for providing the resources and guidance.
- All team members for their contributions and hard work.
