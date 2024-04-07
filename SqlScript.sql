-- Create UpGamingDB Database
CREATE DATABASE UpGamingDB;
GO

-- Use UpGamingDB Database
USE UpGamingDB;
GO

-- Create User Table
CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    UserName NVARCHAR(50) UNIQUE
);
GO

-- Create Scores Table with Foreign Key Constraint
CREATE TABLE Scores (
    ScoreId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT,
    Score INT,
    CreateDate DATETIME,
    FOREIGN KEY (UserId) REFERENCES [User](Id)
);
GO
