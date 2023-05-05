CREATE DATABASE ReservationsProject;

USE ReservationsProject

CREATE TABLE Users (
   UserID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   [Name] NVARCHAR(50),
   Email NVARCHAR(200),
   Cellphone NVARCHAR(50),
   [Type] NVARCHAR(50),
   BirthDate Date,
   Status NVARCHAR(50),
   IsHost BIT,
   CreateDate Date,
   DeleteDate Date
);

CREATE TABLE ReservationsFurnitures (
   ReservationFurnitureID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   ReservationID UNIQUEIDENTIFIER,
   FurnitureID UNIQUEIDENTIFIER
);

CREATE TABLE Reservations (
   ReservationID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   BuildingID UNIQUEIDENTIFIER,
   ClientID UNIQUEIDENTIFIER,
   EventDate Date,
   StartTime DateTime2(7),
   EndTime DateTime2(7),
   TotalPrice FLOAT,
   TotalHours INT,
   EventType NVARCHAR(200)
);

CREATE TABLE Furnitures (
   FurnitureID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,   
   [Description] NVARCHAR(200),
   HourlyRate FLOAT
);

CREATE TABLE Buildings (
   BuildingID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
   OwnerID UNIQUEIDENTIFIER,
   [Address] NVARCHAR(MAX),
   [Description] NVARCHAR(200),
   Capacity INT,
   HourlyRate FLOAT
);


--SEEDS
INSERT INTO Users (UserID, [Name], Email, Cellphone, [Type], BirthDate, Status, IsHost, CreateDate, DeleteDate)
VALUES
    (NEWID(), 'John Doe', 'johndoe@example.com', '555-1234', 'RegularUser', '1985-05-10', 'Available', 0, GETDATE(), NULL),
    (NEWID(), 'Jane Smith', 'janesmith@example.com', '555-5678', 'RegularUser', '1990-02-15', 'Available', 1, GETDATE(), NULL),
    (NEWID(), 'Bob Johnson', 'bobjohnson@example.com', '555-9876', 'RegularUser', '1978-09-22', 'Due', 0, GETDATE(), NULL),
    (NEWID(), 'Sara Lee', 'saralee@example.com', '555-4321', 'Company', '1989-07-08', 'Due', 1, GETDATE(), NULL),
    (NEWID(), 'Tom Jones', 'tomjones@example.com', '555-1111', 'Company', '1982-11-30', 'Canceled', 0, GETDATE(), NULL);


INSERT INTO Furnitures (FurnitureID, [Description], HourlyRate)
VALUES
    (NEWID(), 'Conference Table', 25.00),
    (NEWID(), 'Office Chair', 10.00),
    (NEWID(), 'Sofa', 15.00),
    (NEWID(), 'Coffee Table', 5.00),
    (NEWID(), 'Whiteboard', 8.00);
	
INSERT INTO Buildings (BuildingID, OwnerID, Address, Description, Capacity, HourlyRate)
VALUES
    (NEWID(), Null, '123 Main St', 'Office Building', 100, 50.0),
    (NEWID(), null, '456 Elm St', 'Theater', 50, 35.0),
    (NEWID(), null, '789 Oak St', 'Retail Space', 200, 75.0),
    (NEWID(), null, '321 Pine St', 'Warehouse', 500, 25.0),
    (NEWID(), null, '555 Broadway', 'Restaurant', 75, 100.0);
