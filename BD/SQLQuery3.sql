--SELECT *
--FROM Rute
--WHERE IDTren=1584

--SELECT*
--FROM Trenuri
--WHERE IDTren=1584

--UPDATE Rute
--SET IDTren=1584
--WHERE IDTren=1686 AND IDRuta > 260

--SELECT *
--FROM Statii
--WHERE Nume_statie='Cernavoda Pod'

SELECT IDRuta,count(*)
FROM Program
GROUP BY IDRuta
HAVING COUNT(*)>1

SELECT *
FROM Program
WHERE IDRuta=493
