# SuperMarket System Simulator - Desktop

## 📋 Project Overview

This is a comprehensive desktop application that simulates a SuperMarket System. It provides a complete solution for managing supermarket operations including customer management, product inventory, order processing, and invoice generation.

## 🎯 Project Features

- **Customer Management**: Add, update, and manage customer information
- **Order Processing**: Create and manage customer orders
- **Order History**: Track and view complete order history
- **Invoice Generation**: Generate and manage customer invoices
- **Customer Reviews**: Collect and manage customer feedback
- **Application Management**: Comprehensive admin interface for system operations

## 💻 Technology Stack

- **Language**: C#
- **Platform**: Desktop (Windows Forms)
- **Database**: Microsoft SQL Server
- **Architecture**: N-Tier Architecture with Data Access Layer

## ⚙️ Setup Instructions

### Prerequisites
- Microsoft SQL Server installed and running
- .NET Framework (appropriate version)
- Visual Studio or compatible IDE

### Database Setup
1. **Restore Database**: You must restore the database from the Backup File
2. **Configure SQL Server Connection**: Enter your SQL Server information in the `clsDataAccessSetting` class

   ![Database Configuration](https://github.com/user-attachments/assets/199bba68-73f5-4c81-8787-6b6869f54f99)

3. **Alternative Configuration**: You can also edit the `App.Config` file to contain SQL Server credentials for better security:
   ```xml
   <add key="ServerName" value="your-server-name" />
   <add key="DatabaseName" value="your-database-name" />
   <add key="Username" value="your-username" />
   <add key="Password" value="your-password" />
   ```

## 📸 Overview

### Database Diagram
![DESKTOP-IK9MONC RetainCarsProject - Diagram_Base_ - Microsoft SQL Server Management Studio 16_09_2024 05_51_56 م](https://github.com/user-attachments/assets/3f582c17-0d7a-4c3d-8eea-d5df0900c867)

### Login Interface
![Login 27_07_2024 09_51_35 م](https://github.com/user-attachments/assets/a90ba0dd-0996-4ad5-94f7-fe2396040479)

### Main Dashboard
![Main Form 07_10_2024 10_07_26 م](https://github.com/user-attachments/assets/a9f9b5c7-82e0-4ef1-b696-a0a4045247cb)

### Order History
![OrderHistory 07_10_2024 10_09_21 م](https://github.com/user-attachments/assets/282f4c6c-6a50-4f3e-a44a-77150556af18)

### Customer Reviews
![AddCustomerReview 07_10_2024 10_10_08 م](https://github.com/user-attachments/assets/9fb8dd78-a036-4d1b-a97e-d70ebc335497)

### Order History (Additional View)
![OrderHistory 07_10_2024 10_09_21 م](https://github.com/user-attachments/assets/59168a3e-5819-4506-a57e-aa0723a0e11e)

### Invoice Search
![FindCustomerInvoice 07_10_2024 10_11_50 م](https://github.com/user-attachments/assets/93ec0d60-cd68-494f-b4cb-84a08f45c447)

### Application List
![ApplicationList 07_10_2024 10_11_32 م](https://github.com/user-attachments/assets/62b4d94e-89d8-41c6-bc93-f0e4bd3befb9)

## 📝 License

This project is provided as-is for educational and development purposes.

## 👨‍💻 Author

Amro Aladghem

---

**Thank you for your time and interest in this project!**
