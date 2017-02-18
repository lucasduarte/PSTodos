DECLARE @linha VARCHAR(8000)
DECLARE @comando VARCHAR(8000)

DECLARE exportarArquivo CURSOR FOR
	SELECT
		LOGIN + ' ' + NOME + ' ' + EMAIL
	FROM
		USUARIO

OPEN exportarArquivo

FETCH NEXT FROM exportarArquivo INTO @linha
EXEC xp_cmdshell 'echo USUARIOS FRANQUIA > C:\temp\ARQUIVO_EXPORTACAO_USUARIOS.TXT'
WHILE @@FETCH_STATUS = 0
BEGIN
	IF(@linha <> '')
	BEGIN
		SET @comando = 'echo ' + @linha + ' >> C:\temp\ARQUIVO_EXPORTACAO_USUARIOS.TXT'
		EXEC xp_cmdshell @comando
	END
FETCH NEXT FROM exportarArquivo INTO @linha
END


CLOSE exportarArquivo
DEALLOCATE exportarArquivo
