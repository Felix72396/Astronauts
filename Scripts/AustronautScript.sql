USE SocialMedia
GO
DROP DATABASE AstronautDB
GO
CREATE DATABASE AstronautDB
GO
USE AstronautDB
GO
CREATE TABLE Astronaut
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL,
	Nationality VARCHAR(20) NOT NULL,
	[Description] NVARCHAR(200),
	BirthDate DATE NOT NULL,
	[Status] BIT NOT NULL,
	Photo VARBINARY(MAX)
)
GO
INSERT INTO Astronaut (FirstName, LastName, Nationality, [Description], BirthDate, [Status]) 
VALUES 
('Felix', 'Paniagua', 'Dominican', N'He is al well-known astronaut who Traveled during Apolo 11 mission', '1996/07/23', 1)
GO
CREATE TABLE Mission
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(500) NOT NULL
)
GO
INSERT INTO Mission ([Description]) 
VALUES 
(N'The Apollo 11 mission was a historic spaceflight organized by NASA, 
which achieved the first crewed landing on the Moon. Launched on July 16,
1969, it marked a significant moment in human history and space exploration.')
GO
CREATE TABLE AstronautMission
(
	AstronautId INT,
    MissionId INT,
    CONSTRAINT FK_Astronaut1 FOREIGN KEY (AstronautId) REFERENCES Astronaut(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Mission1 FOREIGN KEY (MissionId) REFERENCES Mission(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT PK_Astronaut_Mission1 PRIMARY KEY (AstronautId, MissionId)
)
GO
INSERT INTO AstronautMission (AstronautId, MissionId) 
VALUES 
(1, 1)
GO
CREATE TABLE SocialMedia
(
	Id INT PRIMARY KEY IDENTITY,
	[Description] VARCHAR(20) NOT NULL
)
GO
INSERT INTO SocialMedia ([Description]) 
VALUES 
('Facebook'),
('Twitter'),
('Youtube'),
('Tiktok'),
('LinkedIn')

GO
CREATE TABLE AstronautSocialMedia
(
	AstronautId INT CONSTRAINT FK_Astronaut2 FOREIGN KEY (AstronautId) REFERENCES Astronaut(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	SocialMediaId INT CONSTRAINT FK_SocialMedia1 FOREIGN KEY (SocialMediaId) REFERENCES SocialMedia(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	Link NVARCHAR(100),
	CONSTRAINT PK_Astronaut_SocialMedia1 PRIMARY KEY (AstronautId, SocialMediaId)
)
GO
INSERT INTO AstronautSocialMedia (AstronautId, SocialMediaId, Link) 
VALUES 
(1, 5, N'https://www.linkedin.com/in/felix-paniagua-3b7a439a/'),
(1,3, N'https://www.youtube.com/channel/UCBA87FGanoBbnNwytr4QKrg')
GO
CREATE TABLE [Security]
(
Id INT PRIMARY KEY IDENTITY,
[User] VARCHAR(30) NOT NULL,
UserName VARCHAR(30) NOT NULL,
[Password] NVARCHAR(200) NOT NULL,
[Role] VARCHAR(15) NOT NULL
)
GO
INSERT INTO [Security] VALUES ('admin', 'Felix Paniagua', '12345', 'Administrator')
