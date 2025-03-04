# IFMS (Intervention File Management System)

IFMS is a web-based application designed to efficiently manage intervention files. Built using **React** for the frontend and **ASP.NET Web API** for the backend, it operates seamlessly within **Docker containers**.

## 🚀 Features
- **File Management**: Upload, store, and retrieve intervention files.
- **API-First Approach**: Backend powered by ASP.NET Web API.
- **Modern UI**: Responsive React frontend.
- **Containerized Deployment**: Simplified setup and scalability with Docker.

---

## 📦 Project Structure
```
IFMS/
│── frontend/      # React application
│── IFMS(web api),Domain,Infrastructure,Application       # ASP.NET Web API
│── docker-compose.yml  # Docker configuration
│── README.md      # Project documentation
```

---

## 🛠️ Setup and Installation

### 1️⃣ Prerequisites
Ensure you have the following installed:
- [Docker](https://www.docker.com/get-started)
- [Node.js](https://nodejs.org/) (for frontend development)
- [.NET 9 SDK](https://dotnet.microsoft.com/) (for backend development)

---

### 2️⃣ Clone the Repository
```sh
git clone [https://github.com/GergoHalasz/IFMS.git](https://github.com/GergoHalasz/IFMS.git)
cd IFMS
```

---

### 3️⃣ Run the Project with Docker
Launch the application using Docker Compose:
```sh
docker-compose up --build
```
This command initializes both the frontend and backend services.
The backend will be accessible at: `http://localhost:5010/`
The frontend will be available at: `http://localhost:3000`
---

## 📄 API Endpoints
The Web API provides the following key endpoints:
- `GET /api/contract` - Retrieve all contracts.
- `GET /api/intervention` - Retrieve all interventions.
- `GET /api/intervention{id}` - Retrieve an intervention.
- `PUT /api/intervention{id}` - Update an intervention.
- `PUT /api/intervention/{id}/assign` - Assign a technician to intervention.

For detailed API documentation, visit `http://localhost:5010/`.
