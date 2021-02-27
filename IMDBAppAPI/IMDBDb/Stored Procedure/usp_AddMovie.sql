USE [IMDBDb]
GO

/****** Object: SqlProcedure [dbo].[usp_AddMovie] Script Date: 25-02-2021 06:26:59 PM ******/

CREATE PROCEDURE usp_AddMovie @Name NVARCHAR(MAX)
	,@YearOfRelease INT
	,@Plot NVARCHAR(MAX)
	,@ProducerId INT
	,@CoverImage NVARCHAR(MAX)
	,@ActorIds VARCHAR(MAX)
	,@GenreIds VARCHAR(MAX)
AS
BEGIN
	DECLARE @MovieId INT

	--Insertion into Movie TABLE
	INSERT INTO [dbo].[Movies] (
		Name
		,YearOfRelease
		,Plot
		,ProducerId
		,CoverImage
		,CreateAt
		)
	VALUES (
		@Name
		,@YearOfRelease
		,@Plot
		,@ProducerId
		,@CoverImage
		,GETDATE()
		)

	-- Getting Inserted MOVIE Id using SCOPE_IDENTITY()
	SET @MovieId = SCOPE_IDENTITY()

	-- INSERT INTO MAPPING TABLE
	-- INSERT INTO ActorMovies
	
		INSERT INTO [dbo].[ActorMovies] (
			MovieId
			,ActorId
			,CreateAt
			)
		SELECT @MovieId [MovieId]
			,[value] [ActorId]
			,GETDATE() [CreateAt]
		FROM string_split(@ActorIds, ',')

	-- INSERT INTO GenreMovies

		INSERT INTO [dbo].[GenreMovies] (
			MovieId
			,GenreId
			,CreateAt
			)
		SELECT @MovieId [MovieId]
			,[value] [GenreId]
			,GETDATE() [CreateAt]
		FROM string_split(@GenreIds, ',')

	select @MovieId
END
