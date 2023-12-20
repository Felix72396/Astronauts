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
('Felix', 'Paniagua', 'Dominican', N'He is a well-known astronaut who traveled during Apollo 11 mission.', '1996/07/23', 1),
('Alice', 'Johnson', 'American', N'Experienced astronaut specializing in space station research.', '1985/04/12', 1),
('Carlos', 'Lopez', 'Mexican', N'Former engineer turned astronaut, fascinated by cosmic phenomena.', '1990/09/08', 1),
('Elena', 'Garcia', 'Spanish', N'Passionate about astronomy and deep space exploration.', '1988/12/30', 1),
('Yuki', 'Tanaka', 'Japanese', N'Astrophysicist fascinated by black holes and dark matter studies.', '1993/06/15', 1),
('Hannah', 'Lee', 'South Korean', N'Youngest astronaut selected for upcoming Mars exploration.', '1996/02/20', 0),
('Michael', 'Smith', 'Canadian', N'Veteran astronaut with multiple missions in space exploration.', '1980/10/05', 1),
('Sophie', 'Chen', 'Chinese', N'Young prodigy in astrophysics, eager to explore the unknown.', '1998/03/28', 0),
('Alexandre', 'Ferreira', 'Brazilian', N'Enthusiastic advocate for interstellar colonization.', '1984/08/17', 1),
('Yasmine', 'Abdel-Hamid', 'Egyptian', N'Expert in astrobiology and the search for extraterrestrial life.', '1991/11/09', 1),
('Nadia', 'Khan', 'Indian', N'Pioneer in space medicine and zero-gravity physiology.', '1989/09/05', 1),
('Antonio', 'Lopez', 'Spanish', N'Spacecraft engineer with a passion for Martian geology.', '1992/01/15', 1),
('Olga', 'Ivanova', 'Russian', N'Experienced cosmonaut specializing in long-duration spaceflights.', '1981/07/18', 1),
('David', 'Nguyen', 'Vietnamese', N'Expert in space robotics and automated systems for planetary exploration.', '1987/03/27', 1),
('Mia', 'Andersson', 'Swedish', N'Astronaut with expertise in lunar geology and mineralogy.', '1994/05/12', 1),
('Luca', 'Martinez', 'Italian', N'Passionate about astrobiology and the search for signs of life on Mars.', '1990/11/03', 1),
('Hiroshi', 'Yamamoto', 'Japanese', N'Experienced pilot and astronaut trainer for deep space missions.', '1983/12/01', 1),
('Aisha', 'Abdullah', 'Emirati', N'First female astronaut from the UAE, focusing on space station maintenance.', '1997/02/25', 0),
('Kim', 'Chen', 'South Korean', N'Expert in space propulsion systems and advanced spacecraft design.', '1986/08/08', 1),
('Ibrahim', 'Mahmoud', 'Egyptian', N'Prominent researcher in astrochemistry and cosmic dust analysis.', '1995/06/21', 1),
('Raul', 'Gonzalez', 'Mexican', N'Pioneering astronaut in space tourism and zero-gravity experiences.', '1992/09/14', 1),
('Fatima', 'Ahmed', 'Saudi Arabian', N'Expert in extraterrestrial geology and mineral resource exploration.', '1989/04/27', 1),
('Mark', 'Andersen', 'Danish', N'Pioneer in space agriculture and self-sustainable habitats.', '1991/10/31', 1),
('Wei', 'Chung', 'Taiwanese', N'Innovator in space debris removal and satellite maintenance technology.', '1987/07/02', 1),
('Ana', 'Garcia', 'Portuguese', N'Astronaut passionate about space ecology and sustainable space travel.', '1993/08/19', 1),
('Mohammed', 'Khan', 'Pakistani', N'Advocate for international collaboration in space exploration.', '1985/12/11', 1),
('Isabella', 'Rossi', 'Italian', N'Expert in Martian climate research and atmospheric studies.', '1988/06/08', 1),
('Chang', 'Lee', 'Singaporean', N'Astronaut specializing in microgravity materials science experiments.', '1996/01/23', 1),
('Ravi', 'Patel', 'Indian', N'Astronaut with expertise in extravehicular activities and spacewalks.', '1990/03/17', 1),
('Julia', 'Kovács', 'Hungarian', N'Pioneer in space psychology and crew behavior dynamics in long-duration missions.', '1986/05/09', 1),
('Paulo', 'Silva', 'Portuguese', N'Advocate for space exploration for sustainable resource mining.', '1994/11/28', 1),
('Anna', 'Petrov', 'Russian', N'Experienced cosmonaut focusing on space station maintenance and repairs.', '1982/02/14', 1),
('Liam', 'O''Connor', 'Irish', N'Pioneer in space weather prediction and solar storm monitoring.', '1993/09/06', 1);
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
('James Webb Space Telescope', N'An upcoming space telescope set to be launched, promising to revolutionize our understanding of the cosmos with its advanced capabilities.'),
('Artemis Program', N'A NASA-led program aiming to return humans to the Moon by 2024, paving the way for future missions to Mars.'),
('Juno Mission', N'A NASA spacecraft orbiting Jupiter, studying its atmosphere, magnetic field, and composition.'),
('Kepler Space Telescope', N'A space observatory launched by NASA to search for exoplanets in our galaxy.'),
('SpaceX Starship Project', N'A project by SpaceX intended for deep space travel, with ambitions for missions to Mars and beyond.'),
('Pioneer Program', N'A series of NASA missions that explored the outer solar system and beyond, paving the way for future explorations.'),
('Dragonfly Mission', N'A planned mission by NASA to send a rotorcraft to explore the surface of Saturn’s moon, Titan.'),
('Europa Clipper', N'A NASA mission set to explore Jupiter’s moon, Europa, to investigate its potential for habitability.'),
('Lunar Gateway', N'A planned space station in lunar orbit, designed to support human and robotic missions to the Moon.'),
('Solar Orbiter', N'A joint ESA-NASA mission studying the Sun and its heliosphere.'),
('OSIRIS-REx', N'A NASA mission to collect samples from the asteroid Bennu and return them to Earth.'),
('BepiColombo', N'A joint ESA-JAXA mission to Mercury, studying its composition, geophysics, and magnetosphere.'),
('Tiangong Space Station', N'A Chinese space station designed for scientific research and international collaboration.'),
('Perseverance Mars Rover', N'A NASA rover exploring Mars, searching for signs of past microbial life and collecting samples.'),
('Venus Express', N'An ESA mission that studied Venus’s atmosphere, plasma environment, and surface features.'),
('InSight Mars Lander', N'A NASA lander designed to study the interior of Mars and understand its geology.'),
('Lunar Reconnaissance Orbiter', N'A NASA spacecraft orbiting the Moon, mapping its surface and seeking resources for future missions.'),
('ASTERIA', N'A NASA spacecraft demonstrating new technologies for future exoplanet missions.'),
('Dawn Mission', N'A NASA mission that explored the protoplanets Vesta and Ceres in the asteroid belt.'),
('Soyuz Program', N'A long-standing Russian space program for crewed missions to space stations and beyond.'),
('Mars Sample Return', N'A planned mission by NASA and ESA to collect and return samples from the Martian surface.');
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
(1, 1), (1, 2), (2, 3), (2, 4), 
(3, 5), (3, 6), (4, 7), (4, 8), 
(5, 9), (5, 10), (6, 11), (6, 12), 
(7, 13), (7, 14), (8, 15), (8, 16), 
(9, 17), (9, 18), (10, 19), (10, 20),
(11, 21), (11, 22), (12, 23), (12, 24), 
(13, 25), (13, 26), (14, 27), (14, 28), 
(15, 29), (15, 30), (16, 1), (16, 2), 
(17, 3), (17, 4), (18, 5), (18, 6), 
(19, 7), (19, 8), (20, 9), (20, 10),
(21, 11), (21, 12), (22, 13), (22, 14), 
(23, 15), (23, 16), (24, 17), (24, 18), 
(25, 19), (25, 20), (26, 21), (26, 22), 
(27, 23), (27, 24), (28, 25), (28, 26), 
(29, 27), (29, 28), (30, 29), (30, 30),
(31, 1), (31, 2), (32, 3), (32, 4), (33, 5), 
(33, 6), (31, 7), (31, 8), (32, 9), (32, 10),
(33, 11), (33, 12), (31, 13), (31, 14), 
(32, 15), (32, 16), (33, 17), (33, 18), 
(31, 19), (31, 20), (32, 21), (32, 22), 
(33, 23), (33, 24), (31, 25), (31, 26), 
(32, 27), (32, 28), (33, 29), (33, 30)
GO

CREATE TABLE SocialMedia
(
	Id INT PRIMARY KEY IDENTITY,
	AstronautId INT NOT NULL CONSTRAINT FK_Astronaut2 FOREIGN KEY (AstronautId) REFERENCES Astronaut(Id) ON DELETE CASCADE ON UPDATE CASCADE,
	[Description] VARCHAR(40) NOT NULL,
	Link NVARCHAR(100) UNIQUE NOT NULL,
	CONSTRAINT UNQ_AstronauId_Description UNIQUE(AstronautId, [Description])
)
GO

INSERT INTO SocialMedia (AstronautId, [Description], Link) 
VALUES 
(1, 'LinkedIn', N'https://www.linkedin.com/in/felix-paniagua-3b7a439a/'),
(1, 'Youtube', N'https://www.youtube.com/channel/UCBA87FGanoBbnNwytr4QKrg'),
(2, 'Facebook', N'https://www.facebook.com/alice.johnson'),
(2, 'TikTok', N'https://www.tiktok.com/@aliceinspace'),
(3, 'Twitter', N'https://twitter.com/carlos_lopez'),
(4, 'YouTube', N'https://www.youtube.com/user/elenatheexplorer'),
(5, 'TikTok', N'https://www.tiktok.com/@yukiinspace'),
(6, 'YouTube', N'https://www.youtube.com/user/hannahinspace'),
(6, 'Twitter', N'https://twitter.com/hannah_lee_astro'),
(7, 'LinkedIn', N'https://www.linkedin.com/in/michael-smith-astronaut'),
(8, 'TikTok', N'https://www.tiktok.com/@sophie_the_astronomer'),
(8, 'Facebook', N'https://www.facebook.com/sophiechen'),
(9, 'YouTube', N'https://www.youtube.com/user/alexandreinspace'),
(10, 'Twitter', N'https://twitter.com/yasmine_astro'),
(11, 'Facebook', N'https://www.facebook.com/nadia.khan'),
(11, 'TikTok', N'https://www.tiktok.com/@nadiainspace'),
(12, 'LinkedIn', N'https://www.linkedin.com/in/antonio-lopez-astronaut'),
(13, 'YouTube', N'https://www.youtube.com/user/olga_the_cosmonaut'),
(14, 'TikTok', N'https://www.tiktok.com/@david_nguyen'),
(15, 'Facebook', N'https://www.facebook.com/mia.andersson.astro'),
(15, 'LinkedIn', N'https://www.linkedin.com/in/mia-andersson-astro'),
(16, 'Twitter', N'https://twitter.com/luca_martinez'),
(17, 'YouTube', N'https://www.youtube.com/user/hiroshiinspace'),
(18, 'Facebook', N'https://www.facebook.com/aisha.abdullah'),
(18, 'LinkedIn', N'https://www.linkedin.com/in/aisha-abdullah-astro'),
(19, 'TikTok', N'https://www.tiktok.com/@kim_chen_astro'),
(20, 'YouTube', N'https://www.youtube.com/user/ibrahiminspace'),
(21, 'LinkedIn', N'https://www.linkedin.com/in/raul-gonzalez-astronaut'),
(22, 'Facebook', N'https://www.facebook.com/fatima.ahmed.astro'),
(22, 'TikTok', N'https://www.tiktok.com/@mark_andersen_astro'),
(23, 'LinkedIn', N'https://www.linkedin.com/in/wei-chung-astronaut'),
(24, 'YouTube', N'https://www.youtube.com/user/anainspace'),
(25, 'TikTok', N'https://www.tiktok.com/@mohammed_khan'),
(25, 'Facebook', N'https://www.facebook.com/isabella.rossi.astro'),
(26, 'LinkedIn', N'https://www.linkedin.com/in/chang-lee-astro'),
(27, 'Twitter', N'https://twitter.com/ravi_patel_astro'),
(27, 'Facebook', N'https://www.facebook.com/julia.kovacs.astro'),
(28, 'TikTok', N'https://www.tiktok.com/@paulo_silva_astro'),
(29, 'LinkedIn', N'https://www.linkedin.com/in/anna-petrov-astro'),
(30, 'YouTube', N'https://www.youtube.com/user/liaminspace');

GO

-- GO
-- CREATE TABLE AstronautSocialMedia
-- (
-- 	AstronautId INT CONSTRAINT FK_Astronaut2 FOREIGN KEY (AstronautId) REFERENCES Astronaut(Id) ON DELETE CASCADE ON UPDATE CASCADE,
-- 	SocialMediaId INT CONSTRAINT FK_SocialMedia1 FOREIGN KEY (SocialMediaId) REFERENCES SocialMedia(Id) ON DELETE CASCADE ON UPDATE CASCADE,
-- 	Link NVARCHAR(100),
-- 	CONSTRAINT PK_Astronaut_SocialMedia1 PRIMARY KEY (AstronautId, SocialMediaId)
-- )
-- GO

-- INSERT INTO AstronautSocialMedia (AstronautId, SocialMediaId, Link) 
-- VALUES 
-- (1, 5, N'https://www.linkedin.com/in/felix-paniagua-3b7a439a/'),
-- (1, 3, N'https://www.youtube.com/channel/UCBA87FGanoBbnNwytr4QKrg'),
-- (2, 1, N'https://www.facebook.com/alice.johnson'),
-- (2, 4, N'https://www.tiktok.com/@aliceinspace'),
-- (3, 2, N'https://twitter.com/carlos_lopez'),
-- (3, 5, N'https://www.linkedin.com/in/carlos-lopez-astronaut'),
-- (4, 3, N'https://www.youtube.com/user/elenatheexplorer'),
-- (5, 4, N'https://www.tiktok.com/@yukiinspace'),
-- (5, 1, N'https://www.facebook.com/yuki.tanaka.astro'),
-- (6, 3, N'https://www.youtube.com/user/hannahinspace'),
-- (6, 2, N'https://twitter.com/hannah_lee_astro'),
-- (7, 5, N'https://www.linkedin.com/in/michael-smith-astronaut'),
-- (8, 4, N'https://www.tiktok.com/@sophie_the_astronomer'),
-- (8, 1, N'https://www.facebook.com/sophiechen'),
-- (9, 3, N'https://www.youtube.com/user/alexandreinspace'),
-- (10, 2, N'https://twitter.com/yasmine_astro'),
-- (11, 1, N'https://www.facebook.com/nadia.khan'),
-- (11, 4, N'https://www.tiktok.com/@nadiainspace'),
-- (12, 5, N'https://www.linkedin.com/in/antonio-lopez-astronaut'),
-- (13, 3, N'https://www.youtube.com/user/olga_the_cosmonaut'),
-- (14, 4, N'https://www.tiktok.com/@david_nguyen'),
-- (15, 1, N'https://www.facebook.com/mia.andersson.astro'),
-- (15, 5, N'https://www.linkedin.com/in/mia-andersson-astro'),
-- (16, 2, N'https://twitter.com/luca_martinez'),
-- (17, 3, N'https://www.youtube.com/user/hiroshiinspace'),
-- (18, 1, N'https://www.facebook.com/aisha.abdullah'),
-- (18, 5, N'https://www.linkedin.com/in/aisha-abdullah-astro'),
-- (19, 4, N'https://www.tiktok.com/@kim_chen_astro'),
-- (20, 3, N'https://www.youtube.com/user/ibrahiminspace'),
-- (21, 5, N'https://www.linkedin.com/in/raul-gonzalez-astronaut'),
-- (22, 1, N'https://www.facebook.com/fatima.ahmed.astro'),
-- (22, 4, N'https://www.tiktok.com/@mark_andersen_astro'),
-- (23, 5, N'https://www.linkedin.com/in/wei-chung-astronaut'),
-- (24, 3, N'https://www.youtube.com/user/anainspace'),
-- (25, 4, N'https://www.tiktok.com/@mohammed_khan'),
-- (25, 1, N'https://www.facebook.com/isabella.rossi.astro'),
-- (26, 5, N'https://www.linkedin.com/in/chang-lee-astro'),
-- (27, 2, N'https://twitter.com/ravi_patel_astro'),
-- (27, 1, N'https://www.facebook.com/julia.kovacs.astro'),
-- (28, 4, N'https://www.tiktok.com/@paulo_silva_astro'),
-- (29, 5, N'https://www.linkedin.com/in/anna-petrov-astro'),
-- (30, 3, N'https://www.youtube.com/user/liaminspace')
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

INSERT INTO [Security] VALUES ('admin', 'Felix Paniagua', '10000.5SD7C+FTFQWldE8WvrRErw==.PvQSKtcpwisycwxkNwHAWpkWnv9Wx2heYGPnejW9zDA=', 'Administrator')
