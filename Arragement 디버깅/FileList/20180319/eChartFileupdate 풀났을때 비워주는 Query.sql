/* 
eChartFileupdate Ǯ������ ����ִ� Query _arlee
*/

--�������� ����ְ�
SELECT MAX(Version) version, FileName
  INTO #temp
  FROM dbo.eChartFileUpdate
Group BY FileName

--Ȯ��
select *
  from #Temp

--������
SELECT * --DELETE a
  FROM eChartFileUpdate a
  JOIN #Temp b ON a.FileName = b.FileName
 WHERE a.Version <> b.Version




