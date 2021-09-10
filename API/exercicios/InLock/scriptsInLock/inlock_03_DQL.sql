USE inLock_Games_Manha;
GO
--Listar todos os estúdios
SELECT * FROM ESTUDIO
GO

--Listar todos os jogos
SELECT * FROM JOGOS
GO

--Listar todos os TipoUsuários
SELECT * FROM TIPOUSUARIOS
GO

--Listar todos os usuários
SELECT * FROM USUARIOS
GO

--Listar todos os jogos e seus respectivos estúdios;
SELECT nomeJogo, nomeEstudio FROM JOGOS
INNER JOIN ESTUDIO E
ON JOGOS.idEstudio = E.idEstudio

--Buscar e trazer na lista todos os estúdios com os respectivos jogos.
--Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT nomeEstudio, nomeJogo FROM ESTUDIO
LEFT JOIN JOGOS J
ON ESTUDIO.idEstudio = J.idEstudio

--Buscar um usuário por e-mail e senha
SELECT email, senha FROM USUARIOS
WHERE email = 'admin@admin.com' AND senha = 'admin'

SELECT email, senha FROM USUARIOS
WHERE email = 'cliente@cliente.com' AND senha = 'cliente'

--Buscar um jogo por idJogo
SELECT idJogo, nomeJogo FROM JOGOS
WHERE idJogo = '1'

SELECT idJogo, nomeJogo FROM JOGOS
WHERE idJogo = '2'

--Buscar um estúdio por idEstudio
SELECT * FROM estudio
WHERE idEstudio = '1'

SELECT * FROM estudio
WHERE idEstudio = '2'

SELECT * FROM estudio
WHERE idEstudio = '3'
