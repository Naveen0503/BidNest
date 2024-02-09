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
CREATE TABLE Shipping (
    ShippingID INT PRIMARY KEY,
    ItemID INT,          -- Foreign key referencing Items table
    ShippingAddress NVARCHAR(255),
    ShippingStatus NVARCHAR(50),  -- E.g., 'Shipped', 'In Transit', 'Delivered'
    TrackingNumber NVARCHAR(50),
    CONSTRAINT FK_Shipping_Item FOREIGN KEY (ItemID) REFERENCES Items (ItemID)
);

INSERT INTO Users (UserID, Username, Email, Password, FirstName, LastName, Address, PhoneNumber, DateOfBirth, RegistrationDate, Role, IsActive, LastLoginDate)
VALUES
    (1, 'seller1', 'seller1@email.com', 'sellerpass', 'John', 'Doe', '123 Main St', '123-456-7890', '1990-01-15', '2022-01-01 08:00:00', 'Seller', 1, '2022-01-10 12:30:00'),
    (2, 'bidder1', 'bidder1@email.com', 'bidderpass', 'Jane', 'Smith', '456 Oak Ave', '987-654-3210', '1985-05-22', '2022-01-02 10:15:00', 'Bidder', 1, '2022-01-11 09:45:00');

INSERT INTO Items (ItemID, SellerID, Title, Description, StartDate, EndDate, InitialAmount, ClosingAmount, CurrentBidAmount)
VALUES
    (1, 1, 'Laptop', 'Brand new laptop', '2022-02-01 12:00:00', '2022-02-10 18:00:00', 500.00, 0.00, 0.00),
    (2, 1, 'Smartphone', 'Latest smartphone model', '2022-02-05 09:00:00', '2022-02-15 15:00:00', 300.00, 0.00, 0.00),
    (3, 1, 'Camera', 'Professional camera', '2022-02-10 15:00:00', '2022-02-20 20:00:00', 800.00, 0.00, 0.00);
INSERT INTO Bids (BidID, BidderID, ItemID, BidAmount, BidTime)
VALUES
    (1, 2, 1, 550.00, '2022-02-05 14:30:00'),
    (2, 2, 2, 320.00, '2022-02-10 10:45:00'),
    (3, 2, 3, 850.00, '2022-02-15 18:30:00');
-- Assuming binary image data for simplicity (replace with actual binary data)
INSERT INTO ItemImages (ImageID, ItemID, ImageData)
VALUES
    (1, 1, 0x0123456789ABCDEF),
    (2, 2, 0xFEDCBA9876543210),
    (3, 3, 0xA1B2C3D4E5F67890);
