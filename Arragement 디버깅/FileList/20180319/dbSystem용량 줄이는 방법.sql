--dbSystem 파일 줄이는 진행과정(서초삼성)
USE dbSystem

--  1. 쿼리로그의 지울수 있는 용량확인
SELECT *
  FROM dbo.tbQueryLog
 WHERE adddate < '2015-01-01 00:00:00.000'


-- 2. dbSystem 의 상태확인
sp_helpdb dbsystem

-- 3. dbo.tbQueryLog의 데이터 삭제
-- 지우고자 하는 행이 많은 경우 dbSystem_log(sp_helpdb system 해서 나오는 결과값중 하단의 2번열의 name컬럼이름)가 
-- 꽉차서 도중에 에러가 생길 수 있다. 날짜별로 잘라서 작업 진행
-- 에러발생하면 5번 시행후 날짜를 짤라서 다시 시도
DELETE 
  FROM tbQuerylog
 WHERE AddDate < '2015-01-01 00:00:00.000' 

-- 4. 3번의 작업후 dbSystem_log의 용량확인
sp_helpdb dbsystem

-- 5. dbSystem_log의 용량조절(SQL 버전별로 방법 다름)
	-- SQL 2005에서 사용
	BACKUP LOG dbSystem WITH no_log --sp_helpdb system 해서 나오는 결과값중 상단의 name컬럼이름
	DBCC ShrinkFile(dbSystem_log,1) --sp_helpdb system 해서 나오는 결과값중 하단의 2번열의 name컬럼이름

	-- SQL 2008에서 사용
	ALTER DATABASE dbSystem SET RECOVERY SIMPLE   --sp_helpdb system 해서 나오는 결과값중 상단의 name컬럼이름
	USE dbSystem DBCC SHRINKFILE(dbSystem_log, 10)  --sp_helpdb system 해서 나오는 결과값중 하단의 2번열의 name컬럼이름
	ALTER DATABASE dbSystem SET RECOVERY FULL     --sp_helpdb system 해서 나오는 결과값중 상단의 name컬럼이름

-- 6. 3번 4번 5번 작업을 반복하여 데이터삭제
-- 7. dbSysTem DB의 데이터베이스와 파일의 축소작업진행

