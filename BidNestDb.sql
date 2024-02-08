-- Create the BidNest database
CREATE DATABASE BidNest;

-- Use the BidNest database
USE BidNest;

-- Create the Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Address NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    DateOfBirth DATE,
    RegistrationDate DATETIME,
    Role NVARCHAR(50),
    ProfileImage VARBINARY(MAX),
    IsActive BIT,
    LastLoginDate DATETIME
);

CREATE TABLE Items (
    ItemID INT PRIMARY KEY,
    SellerID INT,  -- Foreign key referencing Users table
    Title NVARCHAR(255),
    Description NVARCHAR(MAX),
    StartDate DATETIME,
    EndDate DATETIME,
    InitialAmount DECIMAL(10, 2), -- Starting bid amount
    ClosingAmount DECIMAL(10, 2), -- Final bid amount
    CurrentBidAmount DECIMAL(10, 2),
    CONSTRAINT FK_Items_Seller FOREIGN KEY (SellerID) REFERENCES Users (UserID)
);

CREATE TABLE Bids (
    BidID INT PRIMARY KEY,
    BidderID INT,  -- Foreign key referencing Users table
    ItemID INT,    -- Foreign key referencing Items table
    BidAmount DECIMAL(10, 2),
    BidTime DATETIME,
    CONSTRAINT FK_Bids_Bidder FOREIGN KEY (BidderID) REFERENCES Users (UserID),
    CONSTRAINT FK_Bids_Item FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
);

CREATE TABLE ItemImages (
    ImageID INT PRIMARY KEY,
    ItemID INT,  -- Foreign key referencing Items table
    ImageData VARBINARY(MAX),
    CONSTRAINT FK_ItemImages_Item FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
);
ALTER TABLE Items
ADD Status NVARCHAR(50) DEFAULT 'Available';

CREATE TABLE Transactions (
    TransactionID INT PRIMARY KEY,
    BidID INT,         -- Foreign key referencing Bids table
    WinningBidderID INT, -- Foreign key referencing Users table
    WinningAmount DECIMAL(10, 2),
    TransactionTime DATETIME,
    CONSTRAINT FK_Transactions_Bid FOREIGN KEY (BidID) REFERENCES Bids (BidID),
    CONSTRAINT FK_Transactions_WinningBidder FOREIGN KEY (WinningBidderID) REFERENCES Users (UserID)
);
