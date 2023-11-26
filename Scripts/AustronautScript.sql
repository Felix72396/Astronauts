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
	Photo VARBINARY(MAX) CONSTRAINT DF_Photo_Astronaut DEFAULT NULL
)
GO

INSERT INTO Astronaut (FirstName, LastName, Nationality, [Description], BirthDate, [Status]) 
VALUES 
('Felix', 'Paniagua', 'Dominican', N'He is a well-known astronaut who traveled during Apollo 11 mission', '1996/07/23', 1),
('Alice', 'Johnson', 'American', N'Experienced astronaut specializing in space station research', '1985/04/12', 1),
('Carlos', 'Lopez', 'Mexican', N'Former engineer turned astronaut, fascinated by cosmic phenomena', '1990/09/08', 1),
('Elena', 'Garcia', 'Spanish', N'Passionate about astronomy and deep space exploration', '1988/12/30', 1),
('Yuki', 'Tanaka', 'Japanese', N'Astrophysicist fascinated by black holes and dark matter studies', '1993/06/15', 1),
('Hannah', 'Lee', 'South Korean', N'Youngest astronaut selected for upcoming Mars exploration', '1996/02/20', 0),
('Michael', 'Smith', 'Canadian', N'Veteran astronaut with multiple missions in space exploration', '1980/10/05', 1),
('Sophie', 'Chen', 'Chinese', N'Young prodigy in astrophysics, eager to explore the unknown', '1998/03/28', 0),
('Alexandre', 'Ferreira', 'Brazilian', N'Enthusiastic advocate for interstellar colonization', '1984/08/17', 1),
('Yasmine', 'Abdel-Hamid', 'Egyptian', N'Expert in astrobiology and the search for extraterrestrial life', '1991/11/09', 1)
GO

CREATE TABLE Mission
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(40) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL
)
GO

INSERT INTO Mission ([Title], [Description]) 
VALUES 
('Apollo 11', N'The Apollo 11 mission was a historic spaceflight organized by NASA, which achieved the first crewed landing on the Moon. Launched on July 16, 1969, it marked a significant moment in human history and space exploration.'),
('Voyager 1', N'Launched by NASA in 1977, Voyager 1 is the farthest human-made object from Earth, traveling in interstellar space.'),
('Mars Rover Mission', N'A series of missions designed to explore the Martian surface, seeking evidence of past life and preparing for future human exploration.'),
('Hubble Space Telescope', N'Launched in 1990, the Hubble Space Telescope has revolutionized astronomy by capturing breathtaking images of our universe.'),
('Cassini-Huygens', N'A joint NASA-ESA mission that explored Saturn and its moons, providing invaluable data and stunning images.'),
('International Space Station (ISS)', N'A collaborative project involving multiple space agencies for scientific research and international cooperation in space.'),
('Challenger Space Shuttle', N'A tragic event in 1986 when the Space Shuttle Challenger exploded shortly after launch, resulting in the loss of the entire crew.'),
('New Horizons', N'A NASA spacecraft that performed a flyby of Pluto and is now exploring the Kuiper Belt.'),
('Rosetta Mission', N'ESA mission that made history by landing a probe on a comet, providing insights into the early solar system.'),
('James Webb Space Telescope', N'An upcoming space telescope set to be launched, promising to revolutionize our understanding of the cosmos with its advanced capabilities.');
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
(1, 1), -- Astronaut ID 1 with Mission ID 1
(2, 1), -- Astronaut ID 2 with Mission ID 1
(3, 2), -- Astronaut ID 3 with Mission ID 2
(4, 2), -- Astronaut ID 4 with Mission ID 2
(5, 3), -- Astronaut ID 5 with Mission ID 3
(6, 3), -- Astronaut ID 6 with Mission ID 3
(7, 4), -- Astronaut ID 7 with Mission ID 4
(8, 4), -- Astronaut ID 8 with Mission ID 4
(9, 5), -- Astronaut ID 9 with Mission ID 5
(10, 5), -- Astronaut ID 10 with Mission ID 5
(1, 6), -- Astronaut ID 1 with Mission ID 6
(2, 6), -- Astronaut ID 2 with Mission ID 6
(3, 7), -- Astronaut ID 3 with Mission ID 7
(4, 7), -- Astronaut ID 4 with Mission ID 7
(5, 8); -- Astronaut ID 5 with Mission ID 8
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
(1, 3, N'https://www.youtube.com/channel/UCBA87FGanoBbnNwytr4QKrg'),
(2, 1, N'https://www.facebook.com/alice.johnson'),
(2, 4, N'https://www.tiktok.com/@aliceinspace'),
(3, 2, N'https://twitter.com/carlos_lopez'),
(3, 5, N'https://www.linkedin.com/in/carlos-lopez-astronaut'),
(4, 3, N'https://www.youtube.com/user/elenatheexplorer'),
(5, 4, N'https://www.tiktok.com/@yukiinspace'),
(5, 1, N'https://www.facebook.com/yuki.tanaka.astro'),
(6, 3, N'https://www.youtube.com/user/hannahinspace'),
(6, 2, N'https://twitter.com/hannah_lee_astro'),
(7, 5, N'https://www.linkedin.com/in/michael-smith-astronaut'),
(8, 4, N'https://www.tiktok.com/@sophie_the_astronomer'),
(8, 1, N'https://www.facebook.com/sophiechen'),
(9, 3, N'https://www.youtube.com/user/alexandreinspace'),
(10, 2, N'https://twitter.com/yasmine_astro')
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
