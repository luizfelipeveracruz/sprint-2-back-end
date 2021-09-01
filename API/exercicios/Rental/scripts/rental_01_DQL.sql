USE RENTAL_M;
GO

Select * FROM EMPRESA;
GO

Select * FROM CLIENTE;
GO

Select * FROM MARCA;
GO

Select * FROM MODELO;
GO

Select * FROM VEICULO;
GO

SELECT * FROM ALUGUEL;
GO

SELECT DataDevol, DataAluguel, primeiroNome, sobreNome, nomeModelo
FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN MODELO
ON ALUGUEL.idVeiculo = MODELO.idModelo;
GO

SELECT primeiroNome, sobreNome, DataDevol, DataAluguel, nomeModelo 
FROM ALUGUEL
INNER JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idAluguel
INNER JOIN MODELO
ON ALUGUEL.idVeiculo = MODELO.idModelo
WHERE CLIENTE.primeiroNome = 'Lucas' AND sobreNome = 'Aragão';
GO

SELECT primeiroNome, sobreNome, DataDevol, DataAluguel, nomeModelo 
FROM ALUGUEL
INNER JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idAluguel
INNER JOIN MODELO
ON ALUGUEL.idVeiculo = MODELO.idModelo
WHERE CLIENTE.primeiroNome = 'Saulo' AND sobreNome = 'Santos';
GO