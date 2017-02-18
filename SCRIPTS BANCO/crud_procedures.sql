/********** LISTAR USUARIOS *********/
CREATE PROCEDURE SP_LISTAR_USUARIOS
AS
	SELECT * FROM USUARIO
/***********************************/

/********** SELECIONAR USUARIO **********/
CREATE PROCEDURE SP_SELECIONAR_USUARIO
	@id int
AS
	SELECT * FROM USUARIO
		WHERE ID_USUARIO = @id
/***************************************/        

/*************************** ADICIONAR USUARIO ***************************/
CREATE PROCEDURE SP_ADICIONAR_USUARIO
	@login varchar(20),
	@nome varchar(250),
	@email varchar(150),
	@senha varchar(50),
	@ativo bit
AS
	INSERT INTO USUARIO(LOGIN, NOME, EMAIL, SENHA, ATIVO, DT_INCLUSAO)
		VALUES(@login, @nome, @email, @senha, @ativo, GETDATE())
/************************************************************************/

/***************** ATUALIZAR USUARIO *******************/
CREATE PROCEDURE SP_ATUALIZAR_USUARIO
	@id int,
	@login varchar(20) = null,
	@nome varchar(250) = null,
	@email varchar(150) = null,
	@senha varchar(50) = null,
	@ativo bit = 0
AS
	UPDATE USUARIO
		SET 
			LOGIN = ISNULL(@login, LOGIN),
			NOME = ISNULL(@nome, NOME),
			EMAIL = ISNULL(@email, EMAIL),
			SENHA = ISNULL(@senha, SENHA),
			ATIVO = @ativo
        WHERE ID_USUARIO = @id        
/*****************************************************/          

/********** REMOVER USUARIO ********/
CREATE PROCEDURE SP_REMOVER_USUARIO
	@id int
AS
	DELETE FROM USUARIO
		WHERE ID_USUARIO = @id
/***********************************/        

