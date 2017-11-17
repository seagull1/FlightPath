<h2>GPS for small aircraft pilot</h2>
<div>
<p>
Flight Path optimization solution for small aircraft pilot.
Small aircraft might need make some stops in order to reach final distance.
This solution provides shortest flying route between departure and arrival airport.
The route is a list of airport, landing and take off along the list help reduce flying time.
</p>
<pre>
Architecture<br />
┌──────────────────────────┐        ┌──────────────────────────┐        ┌──────────────────────────┐<br />
│  Web                     │        │  Apple App               │        │  Android APP             │<br />
│  ASP.NET Core 2 + React  │        │  NET Core + Xamarin      │        │  NET Core + Xamarin      │<br />
└─────────────+────────────┘        └─────────────+────────────┘        └─────────────+────────────┘<br />
              |                                   |                                   |             <br />
--------------------------------------------------+------------------------------------------------ <br />
                                                  |                                                 <br />
                           ┌──────────────────────+────────────────┐<br />
                           │ WEB API                               │<br />
                           │ .NET core 2 + Entity Framework Core 2 │<br />
                           └───────────────────────────────────────┘<br />

</pre>
<p>
Current only API and Database projects available.<br />
Deploy flightpath.database project to a SQL Server to create database, then import data from csv files. <br />
Update DefaultConnection value in appsettings.json in flightpath.api project, then run!<br />
</p>
<p><a href="http://flightpathapi.azurewebsites.net/index.html">API Demo</a></p>
</div>
<footer><a href="https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm">Dijkstra Algorithm used</a></footer>
