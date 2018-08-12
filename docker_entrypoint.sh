#!/bin/bash

set -e
run_cmd="dotnet run todo-mvc-csharp-problem-sankalpjohri"

cd todo-mvc-csharp-problem-sankalpjohri

until dotnet ef database update; do
	>&2 echo "SQL Server is starting up"
	sleep 1
done


>&2 echo "SQL Server is up - executing command"

exec $run_cmd
