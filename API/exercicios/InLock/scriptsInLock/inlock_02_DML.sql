USE inLock_Games_Manha;
GO

INSERT INTO ESTUDIO(idEstudio, nomeEstudio)
VALUES (1,'Blizzard'), (2,'Rockstar Studios'), (3,'Square Enix');
GO

SELECT * FROM ESTUDIO


INSERT INTO JOGOS(idJogo, idEstudio, nomeJogo, descrição, dataLancamento, valor)
VALUES (1, 1, 'Diablo 3', 'é um jogo que contém bastante
ação e é viciante, seja você um novato ou um fã.', '15-05-2012', 99.00),
(2, 2, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western.', '26-10-2018', 120.00);
GO

SELECT * FROM JOGOS


INSERT INTO TIPOUSUARIOS(idTipoUsuario, titulo)
VALUES (1,'Administrador'), (2,'Cliente');
GO

SELECT * FROM TIPOUSUARIOS


INSERT INTO USUARIOS(idUsuario, idTipoUsuario, email, senha)
VALUES (1, 1, 'admin@admin.com', 'admin'), (2, 2, 'cliente@cliente.com', 'cliente');
GO

SELECT * FROM USUARIOS