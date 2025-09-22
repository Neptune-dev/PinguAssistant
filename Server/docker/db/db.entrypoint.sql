CREATE DATABASE Pingu;
USE Pingu;

CREATE TABLE Users (
    ID int NOT NULL AUTO_INCREMENT,
    Username varchar(50) NOT NULL,
    Pwd varchar(255) NOT NULL,
    isAdmin int NOT NULL,
    PRIMARY KEY (ID)
);