
--������ ���� ������ �ϰ� �Է�
--���Ͽ� ��ϵǾ� �ִ� ���� �����Ѵ�. 

use dentop

DECLARE @iDate VARCHAR(10), @iDW VARCHAR(10)
SELECT @iDate ='2016', @iDW='5' --ex 1=�� 2=�� 3=ȭ 4=�� 5=�� 6=�� 7=��

--�Ⱓ�ȿ� �ʿ��� ���ϸ� ã�´�. 

SELECT a.Date AS HolDate
		 , DatePart(DW, Date) AS WeekNum
		 , DATENAME(DW, Date) AS HolName
	  INTO #TempDate
	  FROM(
			SELECT CONVERT(VARCHAR(8), DATEADD(Day, ROW_NUMBER() OVER(order by a.n, b.n)-1, @iDate+'0101'), 112) Date		
			  FROM Sdummy a, Sdummy b
			 WHERE a.n <= '20'
			   AND b.n <= '20'	
		   )a
	 WHERE a.Date <= @iDate + '1231'
       AND (  DatePart(DW, a.Date) = @iDW)
       
-- #TempDate ���� ������ insert

INSERT INTO	Holiday(HolDate,HolName,Remarks,SundayYn,Valid,AddID,AddDate,UpdID,UpdDate, InxTreatFlag)
SELECT a.HolDate, a.HolName, '', 'N', 'Y', 'cwjoen',GetDate(),'','', 'N'
  FROM #TempDate a			
 WHERE NOT EXISTS (SELECT 'x' FROM Holiday c WHERE c.HolDate = a.HolDate)	
 
 DROP TABLE #TempDate