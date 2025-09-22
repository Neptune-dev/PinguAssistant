CREATE DATABASE Tarot;
USE Tarot;

CREATE TABLE Users (
    ID int NOT NULL AUTO_INCREMENT,
    FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
    Username varchar(50) NOT NULL,
    Email varchar(255),
    Birthdate DATE NOT NULL,
    Pwd varchar(255) NOT NULL,
    Elo int,
    isAdmin int NOT NULL,
    PRIMARY KEY (ID)
);