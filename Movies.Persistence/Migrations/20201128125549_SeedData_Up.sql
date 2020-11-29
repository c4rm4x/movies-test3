INSERT INTO Genres VALUES ('Fiction');
INSERT INTO Genres VALUES ('Comedy');
INSERT INTO Genres VALUES ('Fantasy');
INSERT INTO Genres VALUES ('Mystery');

INSERT INTO Users VALUES ('Carmelo');
INSERT INTO Users VALUES ('Peter');
INSERT INTO Users VALUES ('Elizabeth');
INSERT INTO Users VALUES ('John');

INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('The Godfather', 1972, 235, 4.6);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('The Dark Knight', 2008, 152, 4.5);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('The Lord of the Rings', 2003, 242, 4.45);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Pulp Fiction', 1994, 154, 4.45);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Fight Club', 1999, 139, 4.4);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Forrest Gump', 1994, 142, 4.4);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('The Matrix', 1999, 136, 4.35);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Seven', 1995, 127, 4.3);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Life is Beautiful', 1997, 114, 4.3);
INSERT INTO Movies (Title, YearOfRelease, RunningTime, AverageRating) VALUES ('Parasite', 2019, 132, 4.3);

INSERT INTO MovieGenres (MovieID, GenreID) VALUES (2, 1);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (2, 3);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (3, 1);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (3, 3);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (4, 4);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (5, 1);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (6, 1);
INSERT INTO MovieGenres (MovieID, GenreID) VALUES (6, 2);

INSERT INTO Ratings (MovieID, UserID, [Value]) VALUES (1, 1, 5);
INSERT INTO Ratings (MovieID, UserID, [Value]) VALUES (1, 2, 4);
INSERT INTO Ratings (MovieID, UserID, [Value]) VALUES (2, 1, 4);
INSERT INTO Ratings (MovieID, UserID, [Value]) VALUES (3, 1, 4);
INSERT INTO Ratings (MovieID, UserID, [Value]) VALUES (4, 1, 3);