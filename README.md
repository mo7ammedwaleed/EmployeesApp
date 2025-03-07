# EmployeesApp

A comprehensive employee management application built with **ASP.NET Core 7** and **Entity Framework Core**. The app offers a full CRUD (Create, Read, Update, Delete) functionality and is designed following the **Repository Design Pattern**.

## Features

- 🧑‍💼 **Employee Management:** Add, edit, delete, and view employee details.
- 🔍 **Search and Filter:** Easily search and filter through employee data.
- 💾 **Database Integration:** Uses **Entity Framework Core** for data management.
- 🧠 **Repository Pattern:** Implements a clean architecture for maintainability and scalability.
- 🛡️ **Validation and Error Handling:** Ensures robust data integrity.

## Tech Stack

- **Backend:** ASP.NET Core 7
- **ORM:** Entity Framework Core
- **Design Pattern:** Repository Pattern

## Getting Started

### Prerequisites

- .NET SDK 7.0 or later
- SQL Server (or any supported database)
- IDE (e.g., Visual Studio, VS Code)

### Installation

1. **Clone the Repository:**
```bash
git clone https://github.com/mo7ammedwaleed/EmployeesApp.git
cd EmployeesApp
```

2. **Set up the Database:**
- Configure the connection string in `appsettings.json`.
- Apply migrations:
```bash
dotnet ef database update
```

3. **Run the Application:**
```bash
dotnet run
```

4. Open `https://localhost:5001` in your browser.

## Usage

- Navigate to the Employees section to manage employee data.
- Perform CRUD operations via the intuitive interface.

## Contributing

1. Fork the repository.
2. Create a new branch (`feature/YourFeature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.

## License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for more information.

## Contact

For any inquiries, please reach out to (mailto:mwaleedx1@gmail.com).

---

Let me know if you need any specific details added!
