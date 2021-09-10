USE inLock_Games_Manha;
GO
--Listar todos os est�dios
SELECT * FROM ESTUDIO
GO

--Listar todos os jogos
SELECT * FROM JOGOS
GO

--Listar todos os TipoUsu�rios
SELECT * FROM TIPOUSUARIOS
GO

--Listar todos os usu�rios
SELECT * FROM USUARIOS
GO

--Listar todos os jogos e seus respectivos est�dios;
SELECT nomeJogo, nomeEstudio FROM JOGOS
INNER JOIN ESTUDIO E
ON JOGOS.idEstudio = E.idEstudio

--Buscar e trazer na lista todos os est�dios com os respectivos jogos.
--Obs.: Listar todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
SELECT nomeEstudio, nomeJogo FROM ESTUDIO
LEFT JOIN JOGOS J
ON ESTUDIO.idEstudio = J.idEstudio

--Buscar um usu�rio por e-mail e senha
SELECT email, senha FROM USUARIOS
WHERE email = 'admin@admin.com' AND senha = 'admin'

SELECT email, senha FROM USUARIOS
WHERE email = 'cliente@cliente.com' AND senha = 'cliente'

--Buscar um jogo por idJogo
SELECT idJogo, nomeJogo FROM JOGOS
WHERE idJogo = '1'

SELECT idJogo, nomeJogo FROM JOGOS
WHERE idJogo = '2'

--Buscar um est�dio por idEstudio
SELECT * FROM estudio
WHERE idEstudio = '1'

SELECT * FROM estudio
WHERE idEstudio = '2'

SELECT * FROM estudio
WHERE idEstudio = '3'
