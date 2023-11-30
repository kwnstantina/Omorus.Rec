# Omorus.Rec
Recommendation system  with neo4j and .net 6 for Omorus App.


## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Download Neo4j Desktop](#downloadNeo4j)
  - [Start Neo4j Desktop](#StartNeo4jDesktop)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [Neo4j](https://neo4j.com/download/) database running

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/kwnstantina/Omorus.Rec.git

2. Navigate to the Project

   ```bash
   cd Omorus.Rec


3. Build the project
   ```bash
     cd Omorus.Rec

4. Add the configurations to appSettings.json

    ```bash
    {
    "Neo4jSettings":
     {
       "Uri": "bolt://localhost:7687",
       "Username": "your_username",
       "Password": "your_password"
     }
    }

### Download Neo4j Desktop

1. Visit the [Neo4j Download Center](https://neo4j.com/download/) in your web browser.

2. Choose the appropriate download for your operating system (Windows, macOS, or Linux).

3. Follow the installation instructions for your operating system:

   - **Windows:** Double-click the installer and follow the on-screen instructions.

   - **macOS:** Open the downloaded `.dmg` file and drag the Neo4j icon to your Applications folder.

   - **Linux:** Follow the installation instructions for your specific distribution. You might need to use terminal commands to install and start Neo4j.
  
### Start Neo4j Desktop

1. Once Neo4j is installed, open the Neo4j Desktop application.

2. If this is your first time using Neo4j Desktop, you'll need to sign up for a Neo4j account. Follow the on-screen instructions to create an account or log in.

3. After logging in, click on the "Add Database" button.

4. Choose the version of Neo4j you want to install and set a name for your database.

5. Click on the "Create" button to create the database.

6. Start the database by clicking on the "Start" button.

Now you have Neo4j Desktop installed and running on your machine. You can use it to manage your Neo4j databases and visualize data.

## Contributing
Fork the project.
Create your feature branch: git checkout -b feature/YourFeature
Commit your changes: git commit -m 'Add some feature'
Push to the branch: git push origin feature/YourFeature
Open a pull request.

## License
This project is licensed under the MIT License.


Feel free to customize the sections based on your specific project needs. The README should be concise, informative, and help users and contributors get started with your project.


