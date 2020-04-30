--GERAR MEDIA DE AVALIA��O POR GENERO DE FILME

SELECT
	NOME_GENERO
	
	,SUM(CAST(FILMES.AVALIACAO AS DECIMAL(25,2)))
	,COUNT(1)
	
	,AVG(CAST(FILMES.AVALIACAO AS DECIMAL(25,2)))
	
	,SUM(CAST(FILMES.AVALIACAO AS DECIMAL(25,2)))/CAST(COUNT(1) AS DECIMAL(25,2))
	--SELECT *,REPLACE(AVALIACAO,'.',',')
FROM TB_GENERO_FILME GENEROS
INNER JOIN VW_FILMES_DADOS FILMES
ON FILMES.TITULO_FILME = GENEROS.TITULO_FILME
GROUP BY
	NOME_GENERO
ORDER BY 1


SELECT
	DIRETOR
	
	,SUM(CAST(FILMES.DURACAO AS DECIMAL(25,2)))
	,COUNT(1)
	
	,AVG(CAST(FILMES.DURACAO AS DECIMAL(25,2)))
	
	,SUM(CAST(FILMES.DURACAO AS DECIMAL(25,2)))/CAST(COUNT(1) AS DECIMAL(25,2))
	--SELECT *,REPLACE(AVALIACAO,'.',',')
FROM VW_FILMES_DADOS FILMES
GROUP BY
	DIRETOR
ORDER BY 5 DESC

SELECT *
FROM VW_FILMES_DADOS
ORDER BY
CAST(DURACAO AS INT)