/* 
eChartFileupdate 풀났을때 비워주는 Query _arlee
*/

--최종버전 담아주고
SELECT MAX(Version) version, FileName
  INTO #temp
  FROM dbo.eChartFileUpdate
Group BY FileName

--확인
select *
  from #Temp

--지우자
SELECT * --DELETE a
  FROM eChartFileUpdate a
  JOIN #Temp b ON a.FileName = b.FileName
 WHERE a.Version <> b.Version




