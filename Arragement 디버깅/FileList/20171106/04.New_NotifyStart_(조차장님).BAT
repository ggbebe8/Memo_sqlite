@echo off
SqlCmd -S localhost\ipro -U "sa" -P "ecnad" -Q "alter database dentop set enable_broker with rollback immediate;"
