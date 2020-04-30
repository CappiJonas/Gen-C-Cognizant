--Exercício 1

CREATE TABLE TB_IMOVEL(Id_imovel BIGINT IDENTITY NOT NULL
					 , qtd_quartos BIGINT
					 , qtd_suites BIGINT
					 , qtd_vagas BIGINT
					 , num_m2 CHAR(11)
					 , id_endereco INT NOT NULL)

--Exercício 2

ALTER TABLE TB_IMOVEL
ADD CONSTRAINT PK_TransactionHistoryArchive_TransactionID PRIMARY KEY CLUSTERED(Id_imovel)

--Exercício 3

CREATE TABLE tb_plataforma (cod_plataforma TINYINT IDENTITY PRIMARY KEY
						  , nome_plataforma VARCHAR(15))

CREATE TABLE tb_segmento (cod_segmento SMALLINT IDENTITY PRIMARY KEY
						, nome_segmento VARCHAR(30)
						, tb_plataforma_cod_plataforma TINYINT FOREIGN KEY REFERENCES tb_plataforma(cod_plataforma))

CREATE TABLE tb_eventos (cod_evento INT IDENTITY PRIMARY KEY
					   , dt_evento DATETIME
					   , descricao_evento VARCHAR(300)
					   , solucao_evento VARCHAR(300)
					   , comentario_evento VARCHAR(150)
					   , tb_segmento_cod_segmento SMALLINT FOREIGN KEY REFERENCES tb_segmento(cod_segmento)
					   , tb_usuario_id_usuario INT FOREIGN KEY REFERENCES tb_usuario(id_usuario))

CREATE TABLE tb_usuario (id_usuario INT IDENTITY PRIMARY KEY
					   , nome_usuario VARCHAR(50)
					   , tb_endereco_cod_endereco INT FOREIGN KEY REFERENCES tb_endereco(cod_endereco))

 

CREATE TABLE tb_telefone_usuario (cod_telefone INT IDENTITY PRIMARY KEY
						  , num_ddd CHAR(2)
						  , num_telefone CHAR(9)
						  , tipo_telefone CHAR(2)
						  , tb_usuario_id_usuario INT FOREIGN KEY REFERENCES tb_usuario(id_usuario))

CREATE TABLE tb_estado (cod_estado TINYINT IDENTITY PRIMARY KEY
					  , nome_estado CHAR(2))

CREATE TABLE tb_cidade (cod_cidade SMALLINT IDENTITY PRIMARY KEY
					  , nom_cidade VARCHAR(45)
					  , tb_estado_cod_estado TINYINT FOREIGN KEY REFERENCES tb_estado(cod_estado))

CREATE TABLE tb_bairro (cod_bairro INT IDENTITY PRIMARY KEY
					  , nome_bairro VARCHAR(45)
					  , tb_cidade_cod_cidade SMALLINT FOREIGN KEY REFERENCES tb_cidade(cod_cidade))

CREATE TABLE tb_endereco (cod_endereco INT IDENTITY PRIMARY KEY
						, nome_endereco VARCHAR(45)
						, num_endereco TINYINT
						, cep CHAR(8)
						, tb_bairro_cod_bairro INT FOREIGN KEY REFERENCES tb_bairro(cod_bairro))

CREATE TABLE tb_consultor (id_consultor INT IDENTITY PRIMARY KEY
						 , nome_consultor VARCHAR(45)
						 , tb_endereco_cod_endereco INT FOREIGN KEY REFERENCES tb_endereco(cod_endereco))

CREATE TABLE tb_telefone_consultor (cod_telefone INT IDENTITY PRIMARY KEY
								  , num_ddd CHAR(2)
								  , num_telefone CHAR(9)
								  , tipo_telefone CHAR(2)
								  , tb_consultor_id_consultor INT FOREIGN KEY REFERENCES tb_consultor(id_consultor))

--Exercício 4

ALTER TABLE TB_IMOVEL
   ADD CONSTRAINT FK_TB_IMOVEL FOREIGN KEY (id_endereco)
      REFERENCES tb_endereco (cod_endereco)

--Exercício 5

----INSERT da tb_plataforma

INSERT INTO tb_plataforma(nome_plataforma)
VALUES('PS4')

INSERT INTO tb_plataforma(nome_plataforma)
VALUES('NARUTO')

INSERT INTO tb_plataforma(nome_plataforma)
VALUES('HOMEM-ARANHA')

INSERT INTO tb_plataforma(nome_plataforma)
VALUES('JOHN WICK')

INSERT INTO tb_plataforma(nome_plataforma)
VALUES('PITICAS')

----INSERT da tb_segmento

INSERT INTO tb_segmento(nome_segmento, tb_plataforma_cod_plataforma)
VALUES('LOJAS', 5)

INSERT INTO tb_segmento(nome_segmento, tb_plataforma_cod_plataforma)
VALUES('MANGÁ E/OU ANIMES', 2)

INSERT INTO tb_segmento(nome_segmento, tb_plataforma_cod_plataforma)
VALUES('COMICS', 3)

INSERT INTO tb_segmento(nome_segmento, tb_plataforma_cod_plataforma)
VALUES('JOGOS', 1)

INSERT INTO tb_segmento(nome_segmento, tb_plataforma_cod_plataforma)
VALUES('FILMES', 6)

----INSERT da tb_estado

INSERT INTO tb_estado(nome_estado)
VALUES ('SP')

INSERT INTO tb_estado(nome_estado)
VALUES ('RJ')

INSERT INTO tb_estado(nome_estado)
VALUES ('ES')

INSERT INTO tb_estado(nome_estado)
VALUES ('PR')

INSERT INTO tb_estado(nome_estado)
VALUES ('SE')

----INSERT DA tb_cidade

INSERT INTO tb_cidade (nom_cidade, tb_estado_cod_estado)
VALUES('SÃO PAULO', 1)

INSERT INTO tb_cidade (nom_cidade, tb_estado_cod_estado)
VALUES('CURITIBA', 4)

INSERT INTO tb_cidade (nom_cidade, tb_estado_cod_estado)
VALUES('CATANDUVA', 1)

INSERT INTO tb_cidade (nom_cidade, tb_estado_cod_estado)
VALUES('SÃO JOSÉ DOS PINHAIS', 4)

INSERT INTO tb_cidade (nom_cidade, tb_estado_cod_estado)
VALUES('PACATUBA', 5)

----INSERT da tb_bairro

INSERT INTO tb_bairro(nome_bairro, tb_cidade_cod_cidade)
VALUES ('URUCURI', 5)

INSERT INTO tb_bairro(nome_bairro, tb_cidade_cod_cidade)
VALUES ('BOQUEIRÃO', 2)

INSERT INTO tb_bairro(nome_bairro, tb_cidade_cod_cidade)
VALUES ('HIGIENÓPOLIS', 3)

INSERT INTO tb_bairro(nome_bairro, tb_cidade_cod_cidade)
VALUES ('JD BRASIL', 1)

INSERT INTO tb_bairro(nome_bairro, tb_cidade_cod_cidade)
VALUES ('PARQUE DA FONTE', 4)

---- INSERT da tb_endereco

INSERT INTO tb_endereco(nome_endereco, num_endereco, cep, tb_bairro_cod_bairro)
VALUES ('RUA RIO GRANDE DO SUL', 140, '15804040', 3)

INSERT INTO tb_endereco(nome_endereco, num_endereco, cep, tb_bairro_cod_bairro)
VALUES ('RUA LEANDRO MACIEL', 162, '49970000', 1)

INSERT INTO tb_endereco(nome_endereco, num_endereco, cep, tb_bairro_cod_bairro)
VALUES ('RUA DO BIGUAZAL', 110, '15804040', 4)

INSERT INTO tb_endereco(nome_endereco, num_endereco, cep, tb_bairro_cod_bairro)
VALUES ('RUA ACUTILELE', 37, '02227010', 4)

INSERT INTO tb_endereco(nome_endereco, num_endereco, cep, tb_bairro_cod_bairro)
VALUES ('RUA RIO GRANDE DO NORTE', 171, '15804050', 3)

----INSERT da tb_usuario

INSERT INTO tb_usuario(nome_usuario, tb_endereco_cod_endereco)
VALUES('JONAS', 8)

INSERT INTO tb_usuario(nome_usuario, tb_endereco_cod_endereco)
VALUES('AMAURICIO', 4)

INSERT INTO tb_usuario(nome_usuario, tb_endereco_cod_endereco)
VALUES('JOSÉ', 2)

INSERT INTO tb_usuario(nome_usuario, tb_endereco_cod_endereco)
VALUES('CLAUDIA', 4)

INSERT INTO tb_usuario(nome_usuario, tb_endereco_cod_endereco)
VALUES('HINDRIELE', 8)

----INSERT da tb_eventos

INSERT INTO tb_eventos (dt_evento, descricao_evento, solucao_evento, comentario_evento, tb_segmento_cod_segmento, tb_usuario_id_usuario)
VALUES('23-07-2019', 'EVENTO GEEK', 'BGS 2020','BOM', 4, 1)

INSERT INTO tb_eventos (dt_evento, descricao_evento, solucao_evento, comentario_evento, tb_segmento_cod_segmento, tb_usuario_id_usuario)
VALUES('23-07-2018', 'EVENTO GEEK', 'BGS 2019','BOM', 2, 5)

INSERT INTO tb_eventos (dt_evento, descricao_evento, solucao_evento, comentario_evento, tb_segmento_cod_segmento, tb_usuario_id_usuario)
VALUES('07-10-2020', 'EVENTO GEEK', 'BGS 2018','BOM', 3, 3)

INSERT INTO tb_eventos (dt_evento, descricao_evento, solucao_evento, comentario_evento, tb_segmento_cod_segmento, tb_usuario_id_usuario)
VALUES('07-10-2020', 'EVENTO GEEK', 'CCXP 2020','BOM', 3, 1)

INSERT INTO tb_eventos (dt_evento, descricao_evento, solucao_evento, comentario_evento, tb_segmento_cod_segmento, tb_usuario_id_usuario)
VALUES('23-07-2020', 'EVENTO GEEK', 'CCXP 2019','BOM', 5, 1)

----INSERT da tb_telefone_usuario

INSERT INTO tb_telefone_usuario (num_ddd, num_telefone, tipo_telefone, tb_usuario_id_usuario)
VALUES('33', '758930284', 'RE', 3)

INSERT INTO tb_telefone_usuario (num_ddd, num_telefone, tipo_telefone, tb_usuario_id_usuario)
VALUES('76', '456389208', 'CO', 1)

INSERT INTO tb_telefone_usuario (num_ddd, num_telefone, tipo_telefone, tb_usuario_id_usuario)
VALUES('25', '278407389', 'RE', 4)

INSERT INTO tb_telefone_usuario (num_ddd, num_telefone, tipo_telefone, tb_usuario_id_usuario)
VALUES('19', '947820938', 'CO', 5)

INSERT INTO tb_telefone_usuario (num_ddd, num_telefone, tipo_telefone, tb_usuario_id_usuario)
VALUES('48', '749628187', 'RE', 2)

----INSERT da tb_consultor

INSERT INTO tb_consultor(nome_consultor, tb_endereco_cod_endereco)
VALUES('VITOR', 4)

INSERT INTO tb_consultor(nome_consultor, tb_endereco_cod_endereco)
VALUES('ALEXANDRE', 2)

INSERT INTO tb_consultor(nome_consultor, tb_endereco_cod_endereco)
VALUES('HUGO', 8)

INSERT INTO tb_consultor(nome_consultor, tb_endereco_cod_endereco)
VALUES('SIMONE', 3)

INSERT INTO tb_consultor(nome_consultor, tb_endereco_cod_endereco)
VALUES('SAMANTHA', 9)

----INSERT da tb_telefone_consultor

INSERT INTO tb_telefone_consultor(num_ddd, num_telefone, tipo_telefone, tb_consultor_id_consultor)
VALUES('64', '263748561', 'CO', 2)

INSERT INTO tb_telefone_consultor(num_ddd, num_telefone, tipo_telefone, tb_consultor_id_consultor)
VALUES('51', '473108573', 'CO', 3)

INSERT INTO tb_telefone_consultor(num_ddd, num_telefone, tipo_telefone, tb_consultor_id_consultor)
VALUES('64', '463892648', 'RE', 2)

INSERT INTO tb_telefone_consultor(num_ddd, num_telefone, tipo_telefone, tb_consultor_id_consultor)
VALUES('01', '979710909', 'CO', 4)

INSERT INTO tb_telefone_consultor(num_ddd, num_telefone, tipo_telefone, tb_consultor_id_consultor)
VALUES('55', '23456712', 'CO', 5)

----INSERT da TB_IMOVEL

INSERT INTO TB_IMOVEL(qtd_quartos, qtd_suites, qtd_vagas, num_m2, id_endereco)
VALUES(2, 0, 0, '40,5', 8)

INSERT INTO TB_IMOVEL(qtd_quartos, qtd_suites, qtd_vagas, num_m2, id_endereco)
VALUES(3, 1, 2, '50', 3)

INSERT INTO TB_IMOVEL(qtd_quartos, qtd_suites, qtd_vagas, num_m2, id_endereco)
VALUES(5, 2, 4, '100', 2)

INSERT INTO TB_IMOVEL(qtd_quartos, qtd_suites, qtd_vagas, num_m2, id_endereco)
VALUES(2, 0, 1, '42', 9)

INSERT INTO TB_IMOVEL(qtd_quartos, qtd_suites, qtd_vagas, num_m2, id_endereco)
VALUES(1, 0, 0, '10', 4)

--Exercício 6

----UPDATE da tb_plataforma

UPDATE tb_plataforma SET nome_plataforma = 'XBOX ONE'

----UPDATE da tb_segmento

UPDATE tb_segmento SET nome_segmento = 'GAMES'

----UPDATE da tb_evento

UPDATE tb_eventos SET comentario_evento = 'EXCELENTE'

----UPDATE da tb_usuario

UPDATE tb_usuario SET tb_endereco_cod_endereco = 4

----UPDATE da tb_telefone_usuario

UPDATE tb_telefone_usuario SET num_ddd = 11

----UPDATE da tb_endereco

UPDATE tb_endereco SET num_endereco = 100

----UPDATE da tb_estado

UPDATE tb_estado SET nome_estado = 'MA'

----UPDATE da tb_cidade

UPDATE tb_cidade SET nom_cidade = 'SÃO LUÍS'

----UPDATE da tb_bairro

UPDATE tb_bairro SET nome_bairro = 'ALAMEDA DO SONHOS'

----UPDATE da tb_consultor

UPDATE tb_consultor SET nome_consultor = 'MADALENA'

----UPDATE da tb_telefone_consultor

UPDATE tb_telefone_consultor SET num_ddd = 20

----UPDATE da TB_IMOVEL

UPDATE TB_IMOVEL SET num_m2 = '200'

--Exercício 7

ALTER TABLE TB_IMOVEL
ADD imobiliaria VARCHAR(100)

--Exercicio 8

SELECT*FROM USUARIO A INNER JOIN USUARIO_NOVOS_DADOS B ON B.CPF = A.CPF

SELECT*FROM tb_eventos A INNER JOIN tb_segmento B ON B.cod_segmento = A.tb_segmento_cod_segmento
						 INNER JOIN tb_plataforma C ON C.cod_plataforma = B.tb_plataforma_cod_plataforma
						 LEFT JOIN tb_usuario D ON D.id_usuario = A.tb_usuario_id_usuario
						 LEFT JOIN tb_telefone_usuario E ON E.tb_usuario_id_usuario = D.id_usuario
						 INNER JOIN tb_endereco F ON F.cod_endereco = D.tb_endereco_cod_endereco
						 INNER JOIN tb_bairro G ON G.cod_bairro = F.tb_bairro_cod_bairro
						 INNER JOIN tb_cidade H ON H.cod_cidade = G.tb_cidade_cod_cidade
						 INNER JOIN tb_estado I ON I.cod_estado = H.tb_estado_cod_estado
						 RIGHT JOIN tb_consultor J ON J.tb_endereco_cod_endereco = F.cod_endereco
						 LEFT JOIN tb_telefone_consultor K ON K.tb_consultor_id_consultor = J.id_consultor


--Exercício 9

CREATE FUNCTION SELECIONARFUN(@pNOME CHAR(11))	
RETURNS TABLE
AS
RETURN(
		
	SELECT A.cod_evento AS COD_EVENTO, A.dt_evento AS DT_EVENTO, A.descricao_evento AS DESCRICAO_EVENTO, A.solucao_evento AS SOLUCAO_EVENTO, A.comentario_evento AS COMENTARIO_EVENTO, A.tb_segmento_cod_segmento AS TB_SEGMENTO_COD_SEGMENTO, A.tb_usuario_id_usuario AS TB_USUARIO_ID_USUARIO1, 
		   B.cod_segmento AS COD_SEGMENTO, B.nome_segmento AS NOME_SEGMENTO, B.tb_plataforma_cod_plataforma AS TB_PLATAFORMA_COD_PALATAFORMA,
		   C.cod_plataforma AS COD_PLATAFORMA, C.nome_plataforma AS NOME_PLATAFORMA,
		   D.id_usuario AS ID_USUARIO, D.nome_usuario AS NOME_USUARIO, D.tb_endereco_cod_endereco AS TB_ENDERECO_COD_ENDERECO1,
		   E.cod_telefone COD_TELEFONE, E.num_ddd NUM_DDD, E.num_telefone NUM_TELEFONE, E.tipo_telefone TIPO_TELEFONE, E.tb_usuario_id_usuario AS TB_USUARIO_ID_USUARIO,
		   F.cod_endereco AS COD_ENDERECO, F.nome_endereco AS NOME_ENDERECO, F.num_endereco AS NUM_ENDERECO, F.cep AS CEP, F.tb_bairro_cod_bairro AS TB_BAIRRO_COD_BAIRRO,
		   G.cod_bairro AS COD_BAIRRO, G.nome_bairro AS NOME_BAIRRO, G.tb_cidade_cod_cidade AS TB_CIDADE_COD_CIDADE,
		   H.cod_cidade AS COD_CIDADE, H.nom_cidade AS NOME_CIDADE, H.tb_estado_cod_estado AS TB_ESTADO_COD_ESTADO,
		   I.cod_estado AS COD_ESTADO, I.nome_estado AS NOME_ESTADO,
		   J.id_consultor ID_CONSULTOR, J.nome_consultor AS NOME_CONSULTOR, J.tb_endereco_cod_endereco AS TB_ENDERECO_COD_ENDERECO,
		   K.cod_telefone COD_TELEFONEC, K.num_ddd AS NUM_DDD_C, K.num_telefone AS NUM_TELEFONEC, K.tipo_telefone AS TIPO_TELEFONEC, K.tb_consultor_id_consultor AS TB_CONSULTOR_ID_CONSULTOR
		   FROM  tb_eventos A INNER JOIN tb_segmento B ON cod_segmento = tb_segmento_cod_segmento
						      INNER JOIN tb_plataforma C ON C.cod_plataforma = B.tb_plataforma_cod_plataforma
							  LEFT JOIN tb_usuario D ON D.id_usuario = A.tb_usuario_id_usuario
							  LEFT JOIN tb_telefone_usuario E ON E.tb_usuario_id_usuario = D.id_usuario
							  INNER JOIN tb_endereco F ON F.cod_endereco = D.tb_endereco_cod_endereco
						      INNER JOIN tb_bairro G ON G.cod_bairro = F.tb_bairro_cod_bairro
						      INNER JOIN tb_cidade H ON H.cod_cidade = G.tb_cidade_cod_cidade
							  INNER JOIN tb_estado I ON I.cod_estado = H.tb_estado_cod_estado
							  RIGHT JOIN tb_consultor J ON J.tb_endereco_cod_endereco = F.cod_endereco	
							  LEFT JOIN tb_telefone_consultor K ON K.tb_consultor_id_consultor = J.id_consultor	
)
--Exercício 10

CREATE PROCEDURE SELECIONARPROC @vCHAMADO CHAR(50)
AS
BEGINSELECT NOME_USUARIOWHERE dbo.SELECIONARFUN(NOME_USUARIO) LIKE '%' + @vCHAMADO + '%'
END

--Desafio Final

SELECT C.cod_plataforma AS COD_PLATAFORMA, C.nome_plataforma AS NOME_PLATAFORMA,
	   I.cod_estado AS COD_ESTADO, I.nome_estado AS NOME_ESTADO		   
		   FROM  tb_eventos A INNER JOIN tb_segmento B ON cod_segmento = tb_segmento_cod_segmento
						      INNER JOIN tb_plataforma C ON C.cod_plataforma = B.tb_plataforma_cod_plataforma
							  LEFT JOIN tb_usuario D ON D.id_usuario = A.tb_usuario_id_usuario
							  LEFT JOIN tb_telefone_usuario E ON E.tb_usuario_id_usuario = D.id_usuario
							  INNER JOIN tb_endereco F ON F.cod_endereco = D.tb_endereco_cod_endereco
						      INNER JOIN tb_bairro G ON G.cod_bairro = F.tb_bairro_cod_bairro
						      INNER JOIN tb_cidade H ON H.cod_cidade = G.tb_cidade_cod_cidade
							  INNER JOIN tb_estado I ON I.cod_estado = H.tb_estado_cod_estado
							  RIGHT JOIN tb_consultor J ON J.tb_endereco_cod_endereco = F.cod_endereco	
							  LEFT JOIN tb_telefone_consultor K ON K.tb_consultor_id_consultor = J.id_consultor	
--Desafio final 2 


SELECT
	CAST(C.cod_plataforma as nchar) AS COD_PLATAFORMA, C.nome_plataforma AS NOME_PLATAFORMA,
	   I.cod_estado AS COD_ESTADO, I.nome_estado AS NOME_ESTADO,
CASE WHEN cod_plataforma = 1 THEN 'um'
END AS cod_plataforma
		   FROM  tb_eventos A INNER JOIN tb_segmento B ON cod_segmento = tb_segmento_cod_segmento
						      INNER JOIN tb_plataforma C ON C.cod_plataforma = B.tb_plataforma_cod_plataforma
							  LEFT JOIN tb_usuario D ON D.id_usuario = A.tb_usuario_id_usuario
							  LEFT JOIN tb_telefone_usuario E ON E.tb_usuario_id_usuario = D.id_usuario
							  INNER JOIN tb_endereco F ON F.cod_endereco = D.tb_endereco_cod_endereco
						      INNER JOIN tb_bairro G ON G.cod_bairro = F.tb_bairro_cod_bairro
						      INNER JOIN tb_cidade H ON H.cod_cidade = G.tb_cidade_cod_cidade
							  INNER JOIN tb_estado I ON I.cod_estado = H.tb_estado_cod_estado
							  RIGHT JOIN tb_consultor J ON J.tb_endereco_cod_endereco = F.cod_endereco	
							  LEFT JOIN tb_telefone_consultor K ON K.tb_consultor_id_consultor = J.id_consultor	


