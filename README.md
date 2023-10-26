# Dapr Actor Timeout

This repository tries to reproduce the actor timeout occurring when receiving too many parallel HTTP requests.
The expected behavior is that the HTTP Client timeout occurs after 100 seconds either on Actor side, or on the caller side.

## Run

Run the application using this command:
`dotnet run`

In a separate terminal, run this:
`bash run.sh`

And you should see either a `System.Threading.Tasks.TaskCanceledException: The request was canceled due to the configured HttpClient.Timeout of 100 seconds elapsing.` or a `curl: (28) Connection timed out after 100000 milliseconds` exception.

The assumption is, that "queueing" too many HTTP requests into the Dapr Actor leads to this exception, proving that the actual service execution time is not responsible for the occurring timeout.
Therefore, the ActorTimeout was set to `10 seconds` and the request load was set to `n=100`.

## System Information

**Dapr**
CLI version: 1.12.0 
Runtime version: 1.12.0

**Operation System**
Distributor ID: Ubuntu
Description:    Ubuntu 22.04.2 LTS
Release:        22.04
Codename:       jammy
