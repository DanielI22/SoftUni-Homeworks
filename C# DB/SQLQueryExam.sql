--DDL
CREATE DATABASE CigarShop
CREATE TABLE Sizes 
(
	Id INT Primary Key Identity,
	[Length] INT CHECK([Length] >= 10 AND [Length] <= 25) Not NULL,
	RingRange DECIMAL(18,2) CHECK(RingRange >= 1.5 AND RingRange <= 7.5) Not Null
)

CREATE TABLE Tastes 
(
	Id INT Primary Key Identity,
	TasteType varchar(20) NOT NULL,
	TasteStrength varchar(15) NOT NULL,
	ImageURL nvarchar(100) NOT NULL
)

CREATE TABLE Brands 
(
	Id INT Primary Key Identity,
	BrandName varchar(30) UNIQUE NOT NULL,
	BrandDescription varchar(MAX)
)

CREATE TABLE Cigars 
(
	Id INT Primary Key Identity,
	CigarName varchar(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL nvarchar(100) NOT NULL
)

CREATE TABLE Addresses 
(
	Id INT Primary Key Identity,
	Town varchar(30) NOT NULL,
	Country nvarchar(30) NOT NULL,
	Streat nvarchar(100) NOT NULL,
	ZIP varchar(20) NOT NULL
)

CREATE TABLE Clients 
(
	Id INT Primary Key Identity,
	FirstName nvarchar(30) NOT NULL,
	LastName nvarchar(30) NOT NULL,
	Email nvarchar(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars 
(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
	Primary Key(ClientId, CigarId)
)


--Insert
Insert INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) Values 
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

Insert INTO Addresses(Town, Country, Streat, ZIP) Values 
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', 1000),
('Athens', 'Greece', '4342 McDonald Avenue', 10435),
('Zagreb', 'Croatia', '4333 Lauren Drive', 10000)


--UPDATE
UPDATE Cigars 
SET PriceForSingleCigar = PriceForSingleCigar*1.2
WHERE TastId = (Select Id From Tastes WHERE TasteType = 'Spicy')

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--DELETE
DELETE FROM Clients
WHERE AddressId IN (SELECT Id FROM Addresses WHERE Country LIKE 'C%')

DELETE FROM Addresses
WHERE Country LIKE 'C%'


--Querying
--5.
Select CigarName, PriceForSingleCigar, ImageURL
From Cigars
Order by PriceForSingleCigar, CigarName DESC

--6.
Select c.Id, CigarName, PriceForSingleCigar, TasteType, TasteStrength
From Cigars As c
Join Tastes As t
On c.TastId = t.Id
Where TasteType In ('Earthy', 'Woody')
Order By PriceForSingleCigar DESC

--7
Select Id, CONCAT(FirstName , ' ' , LastName) As ClientName, Email
From Clients
WHERE Clients.Id NOT IN(Select ClientId From ClientsCigars)
Order By ClientName

--8
Select TOP(5) CigarName, PriceForSingleCigar, ImageURL
From Cigars As c
Join Sizes As s
On c.SizeId = s.Id
WHERE s.Length >= 12 AND (c.CigarName LIKE '%ci%' OR PriceForSingleCigar > 50) And RingRange > 2.55
ORder by c.CigarName, PriceForSingleCigar DESC

--9
Select CONCAT(c.FirstName, ' ', c.LastName) As FullName, Country, ZIP, CONCAT('$',  MAX(PriceForSingleCigar)) AS CigarPrice
From Clients As c
Join Addresses As a On c.AddressId = a.Id
Join ClientsCigars as cc On c.Id = cc.ClientId
Join Cigars as ci On cc.CigarId = ci.Id
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY FirstName, LastName, Country, ZIP
ORDER BY FullName

--10
Select LastName,  AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM Clients As c
Join ClientsCigars as cc On c.Id = cc.ClientId
Join Cigars as ci On cc.CigarId = ci.Id
Join Sizes AS s On ci.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--11
GO
CREATE FUNCTION udf_ClientWithCigars(@name varchar(30))
	RETURNS INT
			AS
			BEGIN
				RETURN 
				(
					SELECT ISNULL((SELECT COUNT(*) 
					FROM Clients AS c
					JOIN ClientsCigars AS cc
					On c.Id = cc.ClientId
					WHERE c.FirstName = @name
					GROUP BY c.FirstName), 0)
				)
			END

GO
SELECT dbo.udf_ClientWithCigars('Betty')
SELECT dbo.udf_ClientWithCigars('Rachel')

GO

--12
CREATE PROCEDURE usp_SearchByTaste(@taste varchar(20))
	AS
	BEGIN
		Select CigarName, CONCAT('$', PriceForSingleCigar) AS Price, TasteType, BrandName, CONCAT(s.Length, ' cm') AS CigarLength, CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars AS c
		JOIN Tastes AS t On c.TastId = t.Id
		JOIN Brands AS b On c.BrandId = b.Id
		JOIN Sizes AS s On c.SizeId = s.Id
		WHERE TasteType = @taste
		ORDER BY CigarLength, CigarRingRange DESC
	END

	EXEC usp_SearchByTaste 'Woody'

