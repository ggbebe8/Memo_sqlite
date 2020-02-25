
--설정한 연도 데이터 일괄 입력
--휴일에 등록되어 있는 날은 제외한다. 

use dentop

DECLARE @iDate VARCHAR(10), @iDW VARCHAR(10)
SELECT @iDate ='2016', @iDW='5' --ex 1=일 2=월 3=화 4=수 5=목 6=금 7=토

--기간안에 필요한 요일만 찾는다. 

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
       
-- #TempDate 안의 데이터 insert

INSERT INTO	Holiday(HolDate,HolName,Remarks,SundayYn,Valid,AddID,AddDate,UpdID,UpdDate, InxTreatFlag)
SELECT a.HolDate, a.HolName, '', 'N', 'Y', 'cwjoen',GetDate(),'','', 'N'
  FROM #TempDate a			
 WHERE NOT EXISTS (SELECT 'x' FROM Holiday c WHERE c.HolDate = a.HolDate)	
 
 DROP TABLE #TempDate