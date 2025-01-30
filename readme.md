# Stock Data Scraping

This project is a .NET worker service that fetches data from the Dhaka Stock Exchange (DSE) website every minute and stores it in a SQL Server database.  It utilizes the HTML Agility Pack for web scraping.

## Overview

This application runs as a background worker service, continuously scraping DSE data.  It retrieves real-time stock information, parses the HTML content, and inserts the extracted data into a SQL Server database.  This allows for automated and regular updates of stock market data.

## Features

* **Scheduled Data Fetching:**  The worker service fetches data from the DSE website every minute.
* **Web Scraping:**  Uses the HTML Agility Pack to parse the HTML structure of the DSE website and extract relevant stock information.
* **Data Storage:**  Stores the scraped data in a SQL Server database.
* **Background Service:** Runs as a Windows service or Linux daemon, ensuring continuous operation.
* **Configuration:**  Uses configuration files (e.g., `appsettings.json`) to manage settings like database connection details and scraping targets. (This should be expanded upon in the actual project).

## Technologies Used

* **.NET:** The core framework for the worker service.
* **HTML Agility Pack:**  Used for parsing the HTML content of the DSE website.
* **SQL Server:** The database used to store the scraped stock data.
* **Worker Service:**  Hosts the background data scraping process.
* **Logging Framework:**  A logging framework like Serilog or NLog can be used for detailed logging. (Highly recommended).
* **Dependency Injection:**  Dependency injection should be used for managing dependencies. (Highly recommended).
