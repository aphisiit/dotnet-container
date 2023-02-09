#!/bin/sh

PGPASSWORD=admin psql -U admin test --command "CREATE TABLE todo ( todo_id  SERIAL primary key, subject varchar(20), description varchar(100) );"
PGPASSWORD=admin psql -U admin test --command "INSERT INTO todo(subject, description) VALUES('QDoc-PoC', 'Proof concept of qdoc for moving architecture from .NET Framework to .NET Standard.')"
PGPASSWORD=admin psql -U admin test --command "INSERT INTO todo(subject, description) VALUES('API-Consolidate', 'Centrailzed Enterprise API.')"
PGPASSWORD=admin psql -U admin test --command "INSERT INTO todo(subject, description) VALUES('BPMS', 'Business Process Management System.')"


exit