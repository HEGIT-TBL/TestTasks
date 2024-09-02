CREATE DATABASE Shop_Db;
GO

USE Shop_Db;

CREATE TABLE Categories
(
    CategoryId INT IDENTITY (1,1) PRIMARY KEY,
    Name       VARCHAR(128) NOT NULL
);

CREATE TABLE Products
(
    ProductId INT IDENTITY (1,1) PRIMARY KEY,
    Name      VARCHAR(128) NOT NULL
);

CREATE TABLE ProductCategories
(
    ProductID  INT NOT NULL,
    CategoryID INT NOT NULL,
    PRIMARY KEY (ProductID, CategoryID),
    FOREIGN KEY (ProductID) REFERENCES Products (ProductID) ON DELETE CASCADE,
    FOREIGN KEY (CategoryID) REFERENCES Categories (CategoryID) ON DELETE CASCADE
);

INSERT INTO Categories (Name)
VALUES ('OneCategory_To_NoProducts'),
       ('OneCategory_To_OneProduct'),
       ('OneCategory_To_ManyProducts'),
       ('ManyCategories_To_OneProduct_1'),
       ('ManyCategories_To_OneProduct_2'),
       ('ManyCategories_To_ManyProducts_1'),
       ('ManyCategories_To_ManyProducts_2');

INSERT INTO Products (Name)
VALUES ('OneProduct_To_NoCategories'),
       ('OneProduct_To_OneCategory'),
       ('OneProduct_To_ManyCategories'),
       ('ManyProducts_To_OneCategory_1'),
       ('ManyProducts_To_OneCategory_2'),
       ('ManyProducts_To_ManyCategories_1'),
       ('ManyProducts_To_ManyCategories_2');

INSERT INTO ProductCategories (ProductID, CategoryID)
VALUES (2, 2),
       (3, 4),
       (3, 5),
       (4, 3),
       (5, 3),
       (6, 6),
       (6, 7),
       (7, 6),
       (7, 7);