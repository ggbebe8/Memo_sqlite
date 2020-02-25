--dbSystem ���� ���̴� �������(���ʻＺ)
USE dbSystem

--  1. �����α��� ����� �ִ� �뷮Ȯ��
SELECT *
  FROM dbo.tbQueryLog
 WHERE adddate < '2015-01-01 00:00:00.000'


-- 2. dbSystem �� ����Ȯ��
sp_helpdb dbsystem

-- 3. dbo.tbQueryLog�� ������ ����
-- ������� �ϴ� ���� ���� ��� dbSystem_log(sp_helpdb system �ؼ� ������ ������� �ϴ��� 2������ name�÷��̸�)�� 
-- ������ ���߿� ������ ���� �� �ִ�. ��¥���� �߶� �۾� ����
-- �����߻��ϸ� 5�� ������ ��¥�� ©�� �ٽ� �õ�
DELETE 
  FROM tbQuerylog
 WHERE AddDate < '2015-01-01 00:00:00.000' 

-- 4. 3���� �۾��� dbSystem_log�� �뷮Ȯ��
sp_helpdb dbsystem

-- 5. dbSystem_log�� �뷮����(SQL �������� ��� �ٸ�)
	-- SQL 2005���� ���
	BACKUP LOG dbSystem WITH no_log --sp_helpdb system �ؼ� ������ ������� ����� name�÷��̸�
	DBCC ShrinkFile(dbSystem_log,1) --sp_helpdb system �ؼ� ������ ������� �ϴ��� 2������ name�÷��̸�

	-- SQL 2008���� ���
	ALTER DATABASE dbSystem SET RECOVERY SIMPLE   --sp_helpdb system �ؼ� ������ ������� ����� name�÷��̸�
	USE dbSystem DBCC SHRINKFILE(dbSystem_log, 10)  --sp_helpdb system �ؼ� ������ ������� �ϴ��� 2������ name�÷��̸�
	ALTER DATABASE dbSystem SET RECOVERY FULL     --sp_helpdb system �ؼ� ������ ������� ����� name�÷��̸�

-- 6. 3�� 4�� 5�� �۾��� �ݺ��Ͽ� �����ͻ���
-- 7. dbSysTem DB�� �����ͺ��̽��� ������ ����۾�����

