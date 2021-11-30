
[![LinkedIn][linkedin-shield-zajaczkowski]][linkedin-url-zajaczkowski]

# Templates

## Table of Contents

* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Development](#development)

## Getting Started
These instructions will help you understand how to use .NET project templates.

### Prerequisites
- [.NET 5.0 SDK](https://dotnet.microsoft.com/download) or a later version.

### How to use templates

#### Command line / PowerShell / Terminal
Clone repository
```
git clone https://github.com/krzysztofzajaczkowski/templates
```
Install desired template using .NET CLI by passing path that contains *.template.config* directory as a parameter
```
dotnet new -i templates/windows-service-worker/WindowsServiceWorker
```
You should see something like this, *windows-service* is a template name that you want to use when creating new project
```
Templates                 Short Name       Language  Tags
------------------------  ---------------  --------  --------------
Windows Service Template  windows-service  [C#]      Common/Console
```
Create new project using installed template and custom solution/project name
```
dotnet new windows-service -n MyWindowsService -o MyWindowsService
```

[linkedin-shield-zajaczkowski]: https://img.shields.io/badge/LinkedIn-Zajączkowski-blue?logo=linkedin
[linkedin-url-zajaczkowski]: https://www.linkedin.com/in/krzysztof-m-zajaczkowski/