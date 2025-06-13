
# Earthquake Info Web API

Este es el repositorio del **Backend (API REST)** para el proyecto *Earthquake Info Web Portal* desarrollado en la asignatura de Sistemas Inteligentes.

El objetivo de esta API es exponer, a través de endpoints REST, los datos sísmicos almacenados en una Base de datos SQLite, permitiendo realizar consultas flexibles mediante parámetros como fechas, coordenadas y magnitudes.

👉 Este repositorio corresponde **únicamente a la API REST + Base de Datos SQLite**. 

Otros componentes del proyecto se encuentran en los siguientes repositorios:

### Webscrapping (Python Script)
Script para obtener los datos desde el sitio web de terremotos [GlobalCMT](https://www.globalcmt.org/CMTsearch.html)
- [Repositorio Web Scraping](https://github.com/coralinegrl/buscador-terremotos-scraper)
### Frontend (Vue)
Cliente Web para la visualización e interacción del usuario con el Sistema de Terremotos a través de consultas filtradas. Consume los datos a través de la API REST.
- [Repositorio Frontend](https://github.com/coralinegrl/buscador-terremotos-frontend)

---

## Requerimientos

- **[ASP.NET Core 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)** (Web API REST)
- **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)** (ORM para interacción con la Base de datos)
- **[Postman](https://www.postman.com/downloads/)** o similar, para probar la API y consultar sus endpoints.
- **[SQLite](https://www.sqlite.org/index.html)** (Base de datos local embebida)

---

## Características de la API

- Exposición de endpoint REST `/api/earthquakes` para consultar datos sísmicos.
- Filtros opcionales acumulables por:
    - Fecha (inicio/fin)
    - Latitud (mín/máx)
    - Longitud (mín/máx)
    - Magnitud (mín/máx)
- Respuesta en formato **JSON**.
- Base de datos SQLite cargada automáticamente a partir del archivo `earthquakes.json` generado por el Web Scraping.

---

## Clonar el repositorio

Dentro de una carpeta donde desees alojar el proyecto, abre una consola (cmd o terminal) y ejecuta:

```bash
git clone https://github.com/xPrismatico/earthquakes-backend
```

Luego navega a la carpeta del proyecto:

```bash
cd earthquakes-backend
```

---

## Ejecutar la API

Para iniciar la API, simplemente ejecuta:

```bash
dotnet run
```

Esto iniciará el servidor en la URL por defecto:

```
https://localhost:5001
```

El Endpoint disponible para obtener los terremotos será:

```
https://localhost:5001/api/earthquakes
```

---

## Endpoints

### Terremotos

- `GET /api/earthquakes`: Obtiene la lista de terremotos almacenados en la base de datos. A estos se puede aplicar una serie de filtros utilizando los QueryParams (utiliza Postman para esto)

#### Parámetros Query disponibles (acumulables):

| Parámetro           | Tipo    | Descripción                                       |
|---------------------|---------|--------------------------------------------------|
| `startDate`         | Date (yyyy-MM-dd) | Fecha de inicio del rango de búsqueda              |
| `endDate`           | Date (yyyy-MM-dd) | Fecha final del rango de búsqueda                  |
| `minLatitude`       | double  | Latitud mínima                                    |
| `maxLatitude`       | double  | Latitud máxima                                    |
| `minLongitude`      | double  | Longitud mínima                                   |
| `maxLongitude`      | double  | Longitud máxima                                   |
| `minMagnitude`      | double  | Magnitud mínima (Mw)                              |
| `maxMagnitude`      | double  | Magnitud máxima (Mw)                              |

#### Ejemplo de uso con filtros (Postman o navegador):

```http
GET https://localhost:5001/api/earthquakes?startDate=1979-01-01&endDate=1979-01-13&minLatitude=-40&maxLatitude=-20&minLongitude=-75&maxLongitude=-65&minMagnitude=5.0&maxMagnitude=6.5
```

#### Ejemplo de respuesta (JSON):

```json
[
  {
    "id": 1,
    "date": "1979-01-01",
    "latitude": -30.2,
    "longitude": -70.5,
    "depth": 15.0,
    "magnitude": 5.8
  }
]
```

---

## Formato de datos

Cada terremoto en la base de datos tiene el siguiente formato JSON:

```json
{
    "id": int,
    "date": "yyyy-MM-dd",
    "latitude": double,
    "longitude": double,
    "depth": double,
    "magnitude": double
}
```

Estos datos provienen originalmente del archivo `earthquakes.json` generado por el proceso de Web Scraping.

---

## Notas

- Este repositorio corresponde **exclusivamente a la API REST** para manejar consultas que se quieran hacer desde el Frontend a la Base de datos.
- El Web Scraping y el Frontend son módulos separados que interactúan con esta API.
- La base de datos es local y se carga automáticamente al correr la API.

---
