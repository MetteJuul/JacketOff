CREATE TABLE Guest(
guestID int IDENTITY PRIMARY KEY,
email varchar(50) NOT NULL UNIQUE,
)

CREATE TABLE RegisteredGuest(
guestID int NOT NULL PRIMARY KEY,
firstName varchar(30) NOT NULL,
lastName varchar(30) NOT NULL,
phoneNumber nchar(8) NOT NULL,
passwordHash varchar(200) NOT NULL,
FOREIGN KEY (guestID) REFERENCES Guest(guestID)
)

CREATE TABLE Reservation(
reservationID int IDENTITY PRIMARY KEY,
guestID_FK int NOT NULL,
orderTime smallDateTime NOT NULL,
arrivalTime smallDateTime NOT NULL,
amountOfJackets int NOT NULL,
amountOfBags int NOT NULL,
price decimal(18,2) NOT NULL,
wardrobeID_FK varchar(20) NOT NULL,
FOREIGN KEY (guestID_FK) REFERENCES Guest(guestID),
FOREIGN KEY (wardrobeID_FK) REFERENCES Wardrobe(wardrobeID)
)

CREATE TABLE Wardrobe(
wardrobeID varchar(20) NOT NULL PRIMARY KEY,
maxAmountOfItems int NOT NULL
)

CREATE TABLE Type(
typeID int IDENTITY PRIMARY KEY,
price decimal(18,2) NOT NULL,
typeName varchar(20) NOT NULL
)

CREATE TABLE [Order](
orderID int IDENTITY PRIMARY KEY,
typeID_FK int NOT NULL,
guestID_FK int NOT NULL,
wardrobeID_FK varchar(20) NOT NULL,
ticketNumber int NOT NULL,
link varchar(200) NOT NULL,
checkInTime smallDateTime NOT NULL,
pickUpTime smallDateTime,
paid bit NOT NULL,

FOREIGN KEY(typeID_FK) REFERENCES [Type](typeID),
FOREIGN KEY(guestID_FK) REFERENCES RegisteredGuest(GuestID),
FOREIGN KEY (wardrobeID_FK) REFERENCES Wardrobe(wardrobeID)
)

CREATE TABLE WardrobeControl(
	wardrobeID_FK VARCHAR(20) NOT NULL,
	[date]  SMALLDATETIME NOT NULL,
	[count] INT NOT NULL,
	PRIMARY KEY (wardrobeID_FK, [date]),
	FOREIGN KEY (wardrobeID_FK) REFERENCES Wardrobe(wardrobeID),
);