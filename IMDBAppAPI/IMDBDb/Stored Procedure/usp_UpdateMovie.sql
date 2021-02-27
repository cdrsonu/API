USE [IMDBDb]
GO

/****** Object: SqlProcedure [dbo].[usp_UpdateMovie] Script Date: 25-02-2021 06:28:02 PM ******/

CREATE PROCEDURE usp_UpdateMovie @Id INT
	,@Name NVARCHAR(MAX)
	,@YearOfRelease INT
	,@Plot NVARCHAR(MAX)
	,@ProducerId INT
	,@CoverImage NVARCHAR(MAX)
	,@ActorIds VARCHAR(MAX)
	,@GenreIds VARCHAR(MAX)
AS
BEGIN
	-- UPDATE Movie ENTRY IN TABLE
	UPDATE [dbo].[Movies]
	SET Name = @Name
		,YearOfRelease = @YearOfRelease
		,Plot = @Plot
		,ProducerId = @ProducerId
		,CoverImage = @CoverImage
		,UpdatedAt = GETDATE()
	WHERE Id = @Id

	-- REMOVE ALL ENTRY FROM MAPPING TABLES BY @MovieId
	-- REMOVE FROM ActorMovies
	DELETE
	FROM [dbo].[ActorMovies]
	WHERE MovieId = @Id

	-- REMOVE FROM GenreMovies
	DELETE
	FROM [dbo].[GenreMovies]
	WHERE MovieId = @Id

	-- INSERT INTO MAPPING TABLE
	-- INSERT INTO ActorMovies
	INSERT INTO [dbo].[ActorMovies] (
		MovieId
		,ActorId
		,UpdatedAt
		)
	SELECT @Id [MovieId]
		,[value] [ActorId]
		,GETDATE() [UpdatedAt]
	FROM string_split(@ActorIds, ',')

	-- INSERT INTO GenreMovies
	INSERT INTO [dbo].[GenreMovies] (
		MovieId
		,GenreId
		,UpdatedAt
		)
	SELECT @Id [MovieId]
		,[value] [GenreId]
		,GETDATE() [UpdatedAt]
	FROM string_split(@GenreIds, ',')
END
