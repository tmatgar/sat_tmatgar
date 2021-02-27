# SAT

El objetivo es refactorizar el código de este proyecto. Se puede realizar cualquier cambio que considere necesario en el código y en los test.

# Getting Started

## Requisitos

* Todos los test deben pasar.
* El código debe seguir los principios de la programación orientada a objetos (SOLID, DRY, etc...).
* El código resultante debe ser mantenible y extensible.

## Solución

* El repositorio se puede clonar desde este enlace: [link](https://github.com/tmatgar/sat_tmatgar.git)
* SWAGGER: http://localhost:65492/swagger/index.html

La solución consta de una parte: _back_, integrada en una aplicación ASP.NET Core. Se está empleando el patrón CQRS con MediatR.
* El _back_ está desarrollado con ASP.NET Core 3.1.
* DESCARGAR Y ESTABLECER COMO PROYECTO DE INICIO: Sat.Recruitment.Host

## Solución en BACK

Como ya mencioné anteriormente la solución está desarrollada en ASP.NET Core 3.1. La solución _Sat.Recruitment.sln_ se encuentra en la raíz del directorio está separada en los diferentes proyectos _.csproj_. Estos proyectos se encuentran separados por capas en su correspondiente carpeta a partir de _src_, excepto los tests, que tienen su propia carpeta _test_. Las capas de la aplicación son:

* __Host__: ESTABLECER COMO PROYECTO DE INICIO. Es la capa que se encarga del despliegue del proyecto. Aquí tendremos todo lo relativo a la puesta en marcha de los diferentes entornos.
* __Api__: Es la capa de la entrada y respuesta de las peticiones HTTP. Por tanto, aquí tendremos lo relativo a la configuración del _pipeline_ de ASP.NET Core que no tenga que ver con el despliegue y si con nuestra aplicación. También será donde encontremos los controladores de ASP.NET Core.
* __Application__: Esta es la capa de negocio. Aquí implementaremos la acción de negocio correspondiente a la petición que nos han enviado. Estarán los _handlers_ de _mediatr_ para realizar la o las operaciones de negocio correspondientes. También se encontrarán los validadores de entrada de las _request_. Aunque sea la capa de negocio de la aplicación, la implementación de las operaciones de negocio es están en el Dominio, en los objetos de las entidades de Dominio.
* __Domain__: Es la capa donde tendremos nuestros Objetos de Dominio. Representa la abstracción de nuestro negocio.
* __Infrastructure__: La capa donde tendremos las operaciones de acceso a datos. Está separada en dos partes: Data y Statements.
  * __Data__: Repositorio genérico para acceso a la base de datos (en este caso un fichero .txt)
  * __Statements__: Operaciones contra la base de datos.
* __Tests__: Por último en la carpeta test se encuentran los tests de la aplicación. Los tests que he diseñado para la aplicación son funcionales y prueban todo a partir del API de la aplicación.

### Requisitos

Para el funcionamiento de la aplicación hay que instalar la versión 3.1 de .NET Core.

* __.NET CORE__: instalarlo globalmente https://dotnet.microsoft.com/download

El IDE que se usa para el desarrollo es Visual Studio 2019:

* [Visual Studio 2019](https://visualstudio.microsoft.com/es/vs/)

### Project setup

* En tu Visual Studio puedes compilar y ejecutar el proyecto. Esto te bajará los paquetes _nugets_ que hagan falta automáticamente.
* La aplicación se ejecuta en el perfil de Sat.Recruitment.Host en el puerto 65492.
* Al ejecutar la aplicación se puede acceder al Swagger de la misma en http://localhost:65492/swagger/index.html

### Back Featuring

* [.NET CORE](https://dotnet.microsoft.com/download)
* [Nuget](https://www.nuget.org/) como repositorio de librerías.
* [Mediatr](https://github.com/jbogard/MediatR) as library to connect application and api.
* [Fluent Validation](https://fluentvalidation.net) para las validaciones de las _requests_
* [Problem Details](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.problemdetails?view=aspnetcore-3.1) para la gestión de excepciones en el API.
* [XUnit](https://docs.microsoft.com/es-es/dotnet/core/testing/unit-testing-with-dotnet-test) como librería de tests.
* [TestHost](https://docs.microsoft.com/es-es/aspnet/core/test/integration-tests?view=aspnetcore-3.1) como librería de tests para ASP.NET Core