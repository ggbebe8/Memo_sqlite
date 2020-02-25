@echo off
SqlCmd -S localhost\ipro -U "sa" -P "ecnad" -Q "alter database dentop set DISABLE_BROKER with rollback immediate;"
