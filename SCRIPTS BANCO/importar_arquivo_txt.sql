SELECT CAST('' AS VARCHAR(MAX)) TEXTO INTO #TEXTO

BULK INSERT #TEXTO
FROM 'C:\temp\ARQUIVO_IMPORTACAO_USUARIO.TXT'
WITH
(
FIRSTROW = 2,
ROWTERMINATOR = '\n'
)

--Declaração das variáveis utilizadas pelo cursor
DECLARE @linha           VARCHAR(MAX)
DECLARE @primeiro_espaco INT
DECLARE @ultimo_espaco   INT
DECLARE @nome            VARCHAR(MAX)
DECLARE @email	         VARCHAR(MAX)
DECLARE @login           VARCHAR(MAX)
--Declaração do cursor
DECLARE lerArquivo CURSOR FOR
	SELECT
		LTRIM(RTRIM(TEXTO))
	FROM #TEXTO

--Abrir cursor para leitura
OPEN lerArquivo

--Lendo a primeira linha
FETCH NEXT from lerArquivo INTO @linha
WHILE @@FETCH_STATUS = 0
BEGIN

IF(@linha <> '')
BEGIN
	SET @primeiro_espaco = CHARINDEX(' ', @linha)
	SET @ultimo_espaco = CHARINDEX(' ', REVERSE(@linha))
	SET @login = SUBSTRING(@linha, 1, @primeiro_espaco)
	SET @email = REVERSE(SUBSTRING(REVERSE(@linha), 1, @ultimo_espaco))
	SET @nome = LTRIM(RTRIM(REPLACE(REPLACE(@linha, @email, ''), @login, '')))

	IF((
		SELECT 
			COUNT(*) 
		FROM 
			USUARIO 
		WHERE LOGIN = @login) = 0)
	BEGIN
		INSERT INTO USUARIO VALUES(@login, @nome, @email, '', 0, GETDATE())
	END
	ELSE
		UPDATE
			USUARIO
		SET
			NOME = @nome,
			EMAIL = @email,
			LOGIN = @login
		WHERE LOGIN = @login
END
FETCH NEXT FROM lerArquivo INTO @linha
END

CLOSE lerArquivo
DEALLOCATE lerArquivo

DROP TABLE #TEXTO

SELECT * FROM USUARIO