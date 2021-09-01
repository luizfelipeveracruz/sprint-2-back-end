USE RENTAL_M
GO

INSERT INTO EMPRESA (nomeEmpresa)
VALUES ('Rental');
GO

Select * FROM EMPRESA;
GO

INSERT INTO CLIENTE (primeiroNome, sobreNome)
VALUES ('Saulo','Santos'), ('Lucas','Aragão');
GO

Select * FROM CLIENTE;
GO

INSERT INTO MARCA (nomeMarca)
VALUES ('MITSUBISHI'), ('TOYOTA');
GO

Select * FROM MARCA;
GO

INSERT INTO MODELO (idMarca, nomeModelo)
VALUES (1, 'Lancer'), (2, 'Corolla');
GO

Select * FROM MODELO;
GO

INSERT INTO VEICULO (idModelo, idEmpresa, PLACA)
VALUES (1, 1, '999'), (1, 1, '888'), (2, 1, '777');
GO

Select * FROM VEICULO;
GO

DELETE FROM VEICULO

INSERT INTO ALUGUEL (idVeiculo, idCliente, idEmpresa, DataAluguel, DataDevol)
VALUES (1, 2, 1, '04-08-2021', '05-08-2021');
GO

SELECT * FROM ALUGUEL