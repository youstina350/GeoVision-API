# 🌍 GeoVision API

<p align="center">

Backend for the **GeoVision GIS Platform** built with **ASP.NET Core 8** using **Clean Architecture** principles.

GeoVision aggregates multiple geospatial and environmental data providers into a unified REST API powering the GeoVision Frontend.

</p>

---

# 🚀 Overview

GeoVision API is a scalable GIS backend designed to integrate multiple external geospatial services while providing secure authentication and a clean software architecture.

The API currently supports:

- 🌍 Earthquake Monitoring
- 🌦 Weather Monitoring
- 🌎 NASA Planetary Data
- 🔥 NASA EONET Natural Events
- 🛰 Sentinel Hub Integration
- 🔐 JWT Authentication & Authorization

---

# ✨ Features

## 🔐 Authentication & Security

- User Registration
- User Login
- JWT Authentication
- JWT Authorization
- Secure Token Generation
- Protected API Endpoints
- Swagger JWT Authentication
- Global Exception Middleware
- CORS Configuration

---

## 🌍 Earthquake Module

Integrated with **USGS Earthquake API**

Provides:

- Latest Earthquakes
- Magnitude
- Coordinates
- Depth
- Tsunami Status
- Official USGS Link

---

## 🌦 Weather Module

Integrated with **OpenWeatherMap API**

Provides:

- Current Weather
- Temperature
- Humidity
- Wind Speed
- Weather Description

---

## 🌎 NASA Planetary Module

Integrated with **NASA Planetary API**

Provides planetary and astronomy-related data.

---

## 🔥 Natural Events Module

Integrated with **NASA EONET API**

Provides active natural events including:

- Wildfires
- Volcanoes
- Floods
- Landslides
- Storms
- Sea & Lake Ice
- Dust & Haze

---

## 🛰 Sentinel Hub Module

Integrated with **Sentinel Hub**

Supports satellite imagery and remote sensing services.

---

# 🏗 Architecture

```
                  Client
                     │
                     ▼
             ASP.NET Core API
                     │
        ┌────────────┼────────────┐
        ▼            ▼            ▼
 Authentication  GIS Modules  Middleware
        │
        ▼
 JWT Authentication
        │
        ▼
 Services Layer
        │
        ▼
 Repository Layer
        │
        ▼
 SQL Server
        │
        ▼
 External APIs
```

---

# 📂 Solution Structure

```
GeoVision

│
├── GeoVision.API
│   ├── Controllers
│   ├── Middleware
│   ├── Program.cs
│   └── appsettings.json
│
├── GeoVision.Application
│   ├── Configurations
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── GeoVision.Core
│   └── Interfaces
│
├── GeoVision.Infrastructure
│   ├── Integrations
│   │   ├── Earthquake
│   │   ├── Weather
│   │   ├── Nasa
│   │   ├── Eonet
│   │   └── SentinelHub
│   ├── Persistence
│   ├── Repositories
│   └── Security
│
└── GeoVision.Domain
```

---

# 🛠 Technologies

- ASP.NET Core 9
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- REST API
- HttpClient Factory
- Dependency Injection
- Options Pattern

---

# 📦 Design Patterns

- Clean Architecture
- Repository Pattern
- Dependency Injection
- Service Layer
- DTO Pattern
- Interface Segregation
- Options Pattern

---

# 🌐 External APIs

## 🌍 USGS Earthquake API

Provides real-time earthquake monitoring.

**Base URL**

```
https://earthquake.usgs.gov/fdsnws/event/1/
```

---

## 🌦 OpenWeatherMap API

Provides current weather information.

**Base URL**

```
https://api.openweathermap.org/data/2.5/
```

---

## 🌎 NASA Planetary API

Provides NASA planetary and astronomy data.

**Base URL**

```
https://api.nasa.gov/planetary/
```

---

## 🔥 NASA EONET API

Provides active natural events worldwide.

**Base URL**

```
https://eonet.gsfc.nasa.gov/api/v3/
```

---

## 🛰 Sentinel Hub API

Provides satellite imagery services.

**Base URL**

```
https://services.sentinel-hub.com
```

---

# 🔐 Authentication

GeoVision uses **JWT Bearer Authentication**.

## Register

```http
POST /api/auth/register
```

## Login

```http
POST /api/auth/login
```

Returns

```json
{
  "token": "JWT_TOKEN"
}
```

---

# 🌍 Earthquake Endpoint

```http
GET /api/earthquake
```

Returns recent earthquake data.

---

# 🌦 Weather Endpoint

```http
GET /api/weather
```

Returns current weather data.

---

# 🔥 EONET Endpoint

```http
GET /api/eonet
```

Returns active natural events.

---

# 🌎 NASA Endpoint

```http
GET /api/nasa
```

Returns NASA planetary data.

---

# 🛰 Sentinel Hub Endpoint

```http
GET /api/sentinel
```

Returns satellite imagery data.

---

# ⚙ Configuration

The project uses the **Options Pattern** for external services.

Example configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_SQL_SERVER_CONNECTION"
  },

  "Jwt": {
    "Issuer": "...",
    "Audience": "...",
    "Key": "..."
  },

  "UsgsApi": {
    "BaseUrl": "https://earthquake.usgs.gov/fdsnws/event/1/"
  },

  "WeatherApi": {
    "BaseUrl": "https://api.openweathermap.org/data/2.5/"
  },

  "NasaApi": {
    "BaseUrl": "https://api.nasa.gov/planetary/"
  },

  "EonetApi": {
    "BaseUrl": "https://eonet.gsfc.nasa.gov/api/v3/"
  },

  "SentinelHub": {
    "BaseUrl": "https://services.sentinel-hub.com"
  }
}
```

---

# 🗄 Database

Database Engine

- SQL Server

ORM

- Entity Framework Core

---

# 🧩 Middleware

The project includes:

- Global Exception Middleware
- Authentication Middleware
- Authorization Middleware
- HTTPS Redirection
- CORS Policy

---

# 📄 Swagger

Swagger UI is enabled in development and supports JWT Authentication.

---

# ▶ Running the Project

Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/GeoVision-API.git
```

Navigate to the project

```bash
cd GeoVision.API
```

Restore packages

```bash
dotnet restore
```

Apply migrations

```bash
dotnet ef database update
```

Run the project

```bash
dotnet run
```

Swagger

```
https://localhost:xxxx/swagger
```

---

# 📈 Future Improvements

- Refresh Tokens
- Email Verification
- Password Reset
- Role-Based Authorization
- Pagination
- Filtering
- Caching
- Logging
- Docker Support
- Unit Testing
- Integration Testing
- CI/CD Pipeline

---

# 🌐 Frontend

This API powers the **GeoVision Frontend** built with:

- React
- TypeScript
- React Query
- Leaflet
- Tailwind CSS
- Axios

---

# 👩‍💻 Author

**Youstina**

GeoVision is a full-stack GIS platform demonstrating backend development with **ASP.NET Core**, secure authentication using **JWT**, and integration with multiple real-time geospatial services following **Clean Architecture** principles.
